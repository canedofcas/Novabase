using Flunt.Notifications;
using Novabase.Domain.Commands;
using Novabase.Domain.Commands.Contracts;
using Novabase.Domain.Commands.Package;
using Novabase.Domain.Entities;
using Novabase.Domain.Handlers.Contracts;
using Novabase.Domain.Helper;
using Novabase.Domain.Repositories;
using System;

namespace Novabase.Domain.Handlers
{
    public class PackageHandler : Notifiable,
        IHandler<CreatePackageCommand>,
        IHandler<UpdateCheckPointCommand>,
        IHandler<UpdatePackageCommand>
    {
        private readonly IPackageRepository _repository;
        private readonly ICountryCodeRepository _countryCodeRepository;
        private readonly IIndicatorRepository _indicatorRepository;
        private readonly ICheckpointRepository _checkpointRepository;

        public PackageHandler(IPackageRepository repository,
            ICountryCodeRepository countryCodeRepository,
            IIndicatorRepository indicatorRepository,
            ICheckpointRepository checkpointRepository)
        {
            _repository = repository;
            _countryCodeRepository = countryCodeRepository;
            _indicatorRepository = indicatorRepository;
            _checkpointRepository = checkpointRepository;
        }

        public ICommandResult Handle(CreatePackageCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Check this informations", command.Notifications);

            //create the package
            var obj = new Package(command.HasValueToPay, command.CodeArea, command.Description, command.Weight, command.Price, command.IdSize);

            //get the country with iso codes
            var codesCountry = _countryCodeRepository.GetAllByName(command.CountryOrigin);
            
            if (codesCountry == null)
                return new GenericCommandResult(false, "Country not found", command.Notifications);

            var trackingCode = Helpers.GenerateTrackingCode(codesCountry.IsoAlpha2, codesCountry.NumericCode, command.CodeArea.ToString(), DateTime.Now );

            if (trackingCode == null)
                return new GenericCommandResult(false, "Could not generate tracking code", command.Notifications);

            var idPlaceType = _indicatorRepository.GetAllByInitial("PASSAGE");
            var idTypeControl = _indicatorRepository.GetAllByInitial("STATION");
            var idStatus = _indicatorRepository.GetAllByInitial("RECEIVED");

            //set tracking code to package
            obj.GetTrackingCode(trackingCode);
            
            //save the package
            _repository.Create(obj);

            //get package to add a new checkpoint
             var package = _repository.GetByTracking(trackingCode);
            
            if (package != null)
            {
                var checkpoint = new Checkpoint(command.CountryOrigin, command.City, package.Id, idStatus.Id, idTypeControl.Id, idPlaceType.Id);
                _checkpointRepository.Create(checkpoint);
            }

            return new GenericCommandResult(true, "Succesus.", new
            {
                trackingCode
            });

        }

        public ICommandResult Handle(UpdateCheckPointCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Check this informations", command.Notifications);

            //get package by tracking code
            var package = _repository.GetByTracking(command.TrackingCode);

            if (package == null)
                return new GenericCommandResult(false, "Package not found", Notifications);

            //create a new checkpoint
            var newCheckpodint = new Checkpoint(command.Country, command.City, package.Id, command.IdStauts, command.IdTypeControl, command.IdPlaceType);
            
            //save the checkpoint
            _checkpointRepository.Create(newCheckpodint);

            return new GenericCommandResult(true, "Succesus.", new
            {
                package.TrackingCode
            });
        }

        public ICommandResult Handle(UpdatePackageCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Check this informations", command.Notifications);

            //Get package 
            var pack = _repository.GetByTracking(command.TrackingCode);
            
            if (pack == null)
                return new GenericCommandResult(false, "Package not found", Notifications);

            //create the package update
            var updatePack = new Package(pack.Id, command.HasValueToPay, pack.CodeArea, command.Description, command.Weight, command.Price, command.IdSize);

            //update the package
            _repository.Update(updatePack);

            return new GenericCommandResult(true, "Succesus.", new
            {
                pack.TrackingCode
            });

        }

    }
}

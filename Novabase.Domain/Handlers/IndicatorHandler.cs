using Flunt.Notifications;
using Novabase.Domain.Commands;
using Novabase.Domain.Commands.Contracts;
using Novabase.Domain.Commands.Indicator;
using Novabase.Domain.Entities;
using Novabase.Domain.Handlers.Contracts;
using Novabase.Domain.Repositories;

namespace Domain.Handlers
{
    public class IndicatorHandler : Notifiable, IHandler<CreateIndicatorCommand>
    {
        private readonly IIndicatorRepository _repository;
        public IndicatorHandler(IIndicatorRepository repository)
        {
            _repository = repository;
        }
        public ICommandResult Handle(CreateIndicatorCommand cmd)
        {
            // Fail Fast Validation
            cmd.Validate();
            if (cmd.Invalid)
                return new GenericCommandResult(false, "Check this informations", cmd.Notifications);

            //create the entitie
            var obj = new Indicator(cmd.Value, cmd.IdIndicatorType, cmd.Name, cmd.Initial,  cmd.Description);

            //save the indicator
            _repository.Create(obj);

            return new GenericCommandResult(true, "Succesus.", new
            {
                obj.Name
            });
        }
    }
}

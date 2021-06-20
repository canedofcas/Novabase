using System;
using Flunt.Notifications;
using Flunt.Validations;
using Novabase.Domain.Commands.Contracts;

namespace Novabase.Domain.Commands.Package
{
    public class UpdatePackageCommand : Notifiable, ICommand
    {
        public string TrackingCode { get; set; }
        public bool HasValueToPay { get; set; }
        public int CodeArea { get; set; }
        public string CountryOrigin { get; set; }
        public string Description { get; set; }
        public double Weight { get; set; }
        public decimal Price { get; set; }
        public int IdStatus { get; set; }
        public int IdSize { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(CountryOrigin, 3, "CountryOrigin", "Name must contain at least 3 character!")
            );
        }
    }
}

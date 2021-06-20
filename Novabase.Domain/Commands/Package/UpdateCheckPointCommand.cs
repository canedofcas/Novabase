using System;
using Flunt.Notifications;
using Flunt.Validations;
using Novabase.Domain.Commands.Contracts;

namespace Novabase.Domain.Commands.Package
{
    public class UpdateCheckPointCommand : Notifiable, ICommand
    {
        public string Country { get; set; }
        public string City { get; set; }
        public int IdStauts { get; set; }
        public int IdTypeControl { get; set; }
        public int IdPlaceType { get; set; }
        public string TrackingCode { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Country, 3, "CountryOrigin", "Name must contain at least 3 character!")
                    .HasMinLen(City, 3, "City", "Name must contain at least 3 character!")
            );
        }
    }
}

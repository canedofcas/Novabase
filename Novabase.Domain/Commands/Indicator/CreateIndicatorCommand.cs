using System;
using Flunt.Notifications;
using Flunt.Validations;
using Novabase.Domain.Commands.Contracts;

namespace Novabase.Domain.Commands.Indicator
{
    public class CreateIndicatorCommand : Notifiable, ICommand
    {
        public int Value { get; set; }
        public int IdIndicatorType { get; set; }
        public string Name { get; set; }
        public string Initial { get; set; }
        public string Description { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(Name, 3, "Name", "Name must contain at least 3 character!")
                    .HasMinLen(Initial, 2, "Initial", "Initial must contain at least 3 character!")
            );
        }

    }
}

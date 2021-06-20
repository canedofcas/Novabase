using Flunt.Notifications;
using Flunt.Validations;
using Novabase.Domain.Commands.Contracts;

namespace Novabase.Domain.Commands.Package
{
    public class CreatePackageCommand : Notifiable, ICommand
    {
        public CreatePackageCommand(){}

        public CreatePackageCommand(bool hasValueToPay, int codeArea, string countryOrigin, string city, string description, double weight, decimal price, int idSize)
        {
            
            HasValueToPay = hasValueToPay;
            CodeArea = codeArea;
            CountryOrigin = countryOrigin;
            City = city;
            Description = description;
            Weight = weight;
            Price = price;
            IdSize = idSize;
        }

        public int Id { get; set; }
        public bool HasValueToPay { get;  set; }
        public int CodeArea { get;  set; }
        public string CountryOrigin { get;  set; }
        public string City { get;  set; }
        public string Description { get;  set; }
        public double Weight { get;  set; }
        public decimal Price { get;  set; }
        public int IdSize { get;  set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .HasMinLen(CountryOrigin, 3, "CountryOrigin", "Name must contain at least 3 character!")
                    .HasMinLen(City, 3, "City", "Name must contain at least 3 character!")
            );
        }
    }
}

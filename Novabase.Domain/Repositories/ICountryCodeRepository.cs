using Novabase.Domain.Entities;

namespace Novabase.Domain.Repositories
{
    public interface ICountryCodeRepository
    {
        CountryCode GetAllByName(string name);
    }
}

using Microsoft.EntityFrameworkCore;
using System.Linq;
using Novabase.Domain.Entities;
using Novabase.Domain.Repositories;
using Novabase.Domain.Infra.Contexts;

namespace Novabase.Repository.Repositories
{
    public class CountryCodeRepository : ICountryCodeRepository
    {
        private readonly DataContext _context;

        public CountryCodeRepository(DataContext context)
        {
            _context = context;
        }

        public CountryCode GetAllByName(string name)
        {
            return _context.CountryCodes
                .AsNoTracking()
                .Where(x => x.Name == name).FirstOrDefault();

        }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Linq;
using Novabase.Domain.Entities;
using Novabase.Domain.Repositories;
using Novabase.Domain.Infra.Contexts;
using System.Collections.Generic;


namespace Novabase.Repository.Repositories
{
    public class IndicatorTypeRepository : IIndicatorTypeRepository
    {
        private readonly DataContext _context;

        public IndicatorTypeRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(IndicatorType item)
        {
            _context.IndicatorTypes.Add(item);
            _context.SaveChanges();
        }

        public  IEnumerable<IndicatorType> GetAll()
        {
            return _context.IndicatorTypes.AsNoTracking();
        }

        public IndicatorType GetAllByInitial(string initial)
        {
            return _context.IndicatorTypes
                .AsNoTracking()
                .Where(x => x.Initials == initial).FirstOrDefault();
        }
    }
}

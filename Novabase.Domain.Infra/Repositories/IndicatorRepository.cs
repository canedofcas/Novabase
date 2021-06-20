using Microsoft.EntityFrameworkCore;
using System.Linq;
using Novabase.Domain.Entities;
using Novabase.Domain.Repositories;
using Novabase.Domain.Infra.Contexts;
using System;
using System.Collections.Generic;

namespace Novabase.Repository.Repositories
{
    public class IndicatorRepository : IIndicatorRepository
    {
        private readonly DataContext _context;

        public IndicatorRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Indicator item)
        {
            try
            {
                _context.Indicators.Add(item);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }
        public  IEnumerable<Indicator> GetAll()
        {
            return  _context.Indicators.AsNoTracking();
        }
        public Indicator GetAllByInitial(string initial)
        {
            return _context.Indicators.AsNoTracking().Where(x => x.Initial == initial).FirstOrDefault();

        }
    }
}

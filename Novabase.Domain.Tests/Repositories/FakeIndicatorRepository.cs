using Novabase.Domain.Entities;
using Novabase.Domain.Queries;
using Novabase.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Novabase.Domain.Tests.Repositories
{
    public class FakeIndicatorRepository : IIndicatorRepository
    {
        public void Create(Indicator obj)
        {
            
        }

        public IEnumerable<Indicator> GetAll()
        {
            throw new NotImplementedException();
        }

        public Indicator GetAllByInitial(string initial)
        {
            return new Indicator(2, 2, "TESTE_INDICADOR", "T_I", "TESTES");
        }
    }
}

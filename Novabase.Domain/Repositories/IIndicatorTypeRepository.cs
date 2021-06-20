using Novabase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Novabase.Domain.Repositories
{
    public interface IIndicatorTypeRepository
    {
        void Create(IndicatorType item);
        IEnumerable<IndicatorType> GetAll();
        IndicatorType GetAllByInitial(string initial);
    }
}

using Novabase.Domain.Entities;
using System.Collections.Generic;


namespace Novabase.Domain.Repositories
{
    public interface IIndicatorRepository
    {
        void Create(Indicator obj);
        IEnumerable<Indicator> GetAll();
        Indicator GetAllByInitial(string initial);
    }
}

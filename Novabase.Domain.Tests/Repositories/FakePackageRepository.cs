using Novabase.Domain.Entities;
using Novabase.Domain.Queries;
using Novabase.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Novabase.Domain.Tests.Repositories
{
    public class FakePackageRepository : IPackageRepository
    {
        public void Create(Package obj)
        {
            
        }

        public IEnumerable<Package> GetAll()
        {
            throw new NotImplementedException();
        }

        public Package GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PackageQueryResult> GetByLocalization(string parameter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PackageQueryResult> GetByStatus(int IdStatus)
        {
            throw new NotImplementedException();
        }

        public Package GetByTracking(string code)
        {
            return new Package(1, true, 25468, "TESTES", 125.5, 185, 7);
        }

        public string GetByTrackingCode(string code)
        {
            throw new NotImplementedException();
        }

        public double GetByValueInTransit()
        {
            throw new NotImplementedException();
        }

        public void Update(Package obj)
        {
           
        }
    }
}

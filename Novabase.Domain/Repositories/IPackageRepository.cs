using Novabase.Domain.Entities;
using Novabase.Domain.Queries;
using System;
using System.Collections.Generic;

namespace Novabase.Domain.Repositories
{
    public interface IPackageRepository
    {
        void Create(Package obj);
        void Update(Package obj);
        Package GetById(Guid id);
        IEnumerable<Package> GetAll();
        string GetByTrackingCode(string code);
        Package GetByTracking(string code);
        IEnumerable<PackageQueryResult> GetByStatus(int IdStatus);
        IEnumerable<PackageQueryResult> GetByLocalization(string parameter);
        double GetByValueInTransit();



    }
}

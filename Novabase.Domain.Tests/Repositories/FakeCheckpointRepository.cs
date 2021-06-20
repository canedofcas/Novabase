using Novabase.Domain.Entities;
using Novabase.Domain.Queries;
using Novabase.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Novabase.Domain.Tests.Repositories
{
    public class FakeCheckpointRepository : ICheckpointRepository
    {
        public void Create(Checkpoint obj)
        {}

        public Checkpoint GetByIdPackage(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Checkpoint obj)
        {
            throw new NotImplementedException();
        }
    }
}

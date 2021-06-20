using Novabase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Novabase.Domain.Repositories
{
    public interface ICheckpointRepository
    {
        void Create(Checkpoint obj);
        void Update(Checkpoint obj);
        Checkpoint GetByIdPackage(int id);

    }
}

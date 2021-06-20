using Microsoft.EntityFrameworkCore;
using System.Linq;
using Novabase.Domain.Entities;
using Novabase.Domain.Repositories;
using Novabase.Domain.Infra.Contexts;

namespace Novabase.Repository.Repositories
{

    public class CheckpointRepository : ICheckpointRepository
    {
        private readonly DataContext _context;
        public CheckpointRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Checkpoint obj)
        {
            _context.Checkpoints.Add(obj);
            _context.SaveChanges();
        }

        public void Update(Checkpoint obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Checkpoint GetByIdPackage(int id)
        {
            return _context.Checkpoints.AsNoTracking().Where(c => c.IdPackage == id).OrderByDescending(x => x.Id).FirstOrDefault();
        }
    }
}

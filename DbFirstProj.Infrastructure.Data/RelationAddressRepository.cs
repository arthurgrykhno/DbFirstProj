using DbFirstProj.Domain.Interfaces.Repositories;
using DbFirstProj.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DbFirstProj.Infrastructure.Data
{
    public class RelationAddressRepository : IGenericRepository<RelationAddress>
    {
        private ApplicationDbContext context;

        public RelationAddressRepository()
        {
            context = new ApplicationDbContext();
        }

        public void Create(RelationAddress relation)
        {
            context.RelationAddress.Add(relation);

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var relation = context.RelationAddress.Find(id);

            if (relation != null)
            {
                context.RelationAddress.Remove(relation);
            }

            context.SaveChanges();
        }

        public IEnumerable<RelationAddress> GetAll()
        {
            return context.RelationAddress.ToList();
        }

        public RelationAddress Get(int id)
        {
            return context.RelationAddress.Find(id);
        }

        public void Update(RelationAddress relation)
        {
            context.Entry(relation).State = EntityState.Modified;
        }
    }
}

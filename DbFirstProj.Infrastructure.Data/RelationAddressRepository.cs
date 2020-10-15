using DbFirstProj.Domain.Interfaces.Repositories;
using DbFirstProj.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DbFirstProj.Infrastructure.Data
{
    public class RelationAddressRepository : IGenericRepository<RelationAddress>
    {
        private testContext context;

        public RelationAddressRepository()
        {
            context = new testContext();
        }

        public void Create(RelationAddress relation)
        {
            context.Add(relation);

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var relation = context.TblRelationAddress.Find(id);

            if (relation != null)
            {
                context.TblRelationAddress.Remove(relation);
            }

            context.SaveChanges();
        }

        public IEnumerable<RelationAddress> GetAll()
        {
            return context.TblRelationAddress.ToList();
        }

        public RelationAddress Get(int id)
        {
            return context.TblRelationAddress.Find(id);
        }

        public void Update(RelationAddress relation)
        {
            context.Entry(relation).State = EntityState.Modified;
        }
    }
}

using DbFirstProj.Domain.Interfaces.Repositories;
using DbFirstProj.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DbFirstProj.Infrastructure.Data
{
    public class RelationAddressRepository : IRelationAddressRepository
    {
        private testContext context;

        public RelationAddressRepository()
        {
            context = new testContext();
        }

        public void Create(TblRelationAddress relation)
        {
            context.Add(relation);

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            TblRelationAddress relation = context.TblRelationAddress.Find(id);

            if (relation != null)
                context.TblRelationAddress.Remove(relation);

            context.SaveChanges();
        }

        public IEnumerable<TblRelationAddress> GetAll()
        {
            return context.TblRelationAddress.ToList();
        }

        public TblRelationAddress Get(int id)
        {
            return context.TblRelationAddress.Find(id);
        }

        public void Update(TblRelationAddress relation)
        {
            context.Entry(relation).State = EntityState.Modified;
        }
    }
}

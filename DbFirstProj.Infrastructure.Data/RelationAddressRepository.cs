using DbFirstProj.Domain.Interfaces.Repositories;
using DbFirstProj.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbFirstProj.Infrastructure.Data
{
    public class RelationAddressRepository : IGenericRepository<RelationAddress>
    {
        private readonly ApplicationDbContext context;

        public RelationAddressRepository()
        {
            context = new ApplicationDbContext();
        }

        public void Create(RelationAddress relation)
        {
            context.RelationAddress.Add(relation);

            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var relation = context.RelationAddress.Find(id);

            if (id != null)
            {
                context.RelationAddress.Remove(relation);
            }

            context.SaveChanges();
        }

        public IEnumerable<RelationAddress> GetAll(string sortingCondition = "", bool isDesc = false)
        {
            return context.RelationAddress.ToList();
        }

        public RelationAddress Get(Guid id)
        {
            return context.RelationAddress.Find(id);
        }

        public void Update(RelationAddress relation)
        {
            context.RelationAddress.Update(relation);

            context.SaveChanges();
        }
    }
}

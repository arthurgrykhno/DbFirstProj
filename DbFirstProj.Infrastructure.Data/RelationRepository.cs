using DbFirstProj.Domain.Interfaces.Repositories;
using DbFirstProj.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbFirstProj.Infrastructure.Data
{
    public class RelationRepository : IGenericRepository<Relation>
    {
        private ApplicationDbContext context;

        public RelationRepository()
        {
            context = new ApplicationDbContext();
        }

        public void Create(Relation relation)
        {
            context.Relation.Add(relation);

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var relation = context.Relation.Find(id);

            if (relation != null)
            {
                context.Relation.Remove(relation);
            }

            context.SaveChanges();
        }

        public IEnumerable<Relation> GetAll()
        {
            return context.Relation.ToList();
        }

        public Relation Get(int id)
        {
            return context.Relation.Find(id);
        }

        public void Update(Relation relation)
        {
            context.Entry(relation).State = EntityState.Modified;
        }
    }
}

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
        private testContext context;

        public RelationRepository()
        {
            context = new testContext();
        }

        public void Create(Relation relation)
        {
            context.Add(relation);

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var relation = context.TblRelation.Find(id);

            if (relation != null)
            {
                context.TblRelation.Remove(relation);
            }

            context.SaveChanges();
        }

        public IEnumerable<Relation> GetAll()
        {
            return context.TblRelation.ToList();
        }

        public Relation Get(int id)
        {
            return context.TblRelation.Find(id);
        }

        public void Update(Relation relation)
        {
            context.Entry(relation).State = EntityState.Modified;
        }
    }
}

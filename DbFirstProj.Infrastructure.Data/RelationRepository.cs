using DbFirstProj.Domain.Interfaces.Repositories;
using DbFirstProj.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbFirstProj.Infrastructure.Data
{
    public class RelationRepository : IRelationRepository
    {
        private testContext context;

        public RelationRepository()
        {
            context = new testContext();
        }

        public void Create(TblRelation relation)
        {
            context.Add(relation);

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            TblRelation relation = context.TblRelation.Find(id);

            if (relation != null)
                context.TblRelation.Remove(relation);

            context.SaveChanges();
        }

        public IEnumerable<TblRelation> GetAll()
        {
            return context.TblRelation.ToList();
        }

        public TblRelation Get(int id)
        {
            return context.TblRelation.Find(id);
        }

        public void Update(TblRelation relation)
        {
            context.Entry(relation).State = EntityState.Modified;
        }
    }
}

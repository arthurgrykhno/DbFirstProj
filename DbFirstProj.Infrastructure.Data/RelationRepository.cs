﻿using DbFirstProj.Domain.Interfaces.Repositories;
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
        private readonly ApplicationDbContext context;

        public RelationRepository()
        {
            context = new ApplicationDbContext();
        }

        public void Create(Relation relation)
        {
            context.Relation.Add(relation);

            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var relation = context.Relation.Find(id);
            relation.IsDisabled = true;

            context.SaveChanges();
        }

        public IEnumerable<Relation> GetAll()
        {
            var a = context.Relation.Include(r => r.RelationAddresses).ThenInclude(e => e.Country).ToList();
            return a;
        }

        public Relation Get(Guid id)
        {
            return context.Relation.Find(id);
        }

        public void Update(Relation relation)
        {
            context.Relation.Update(relation);
            context.SaveChanges();
        }
    }
}

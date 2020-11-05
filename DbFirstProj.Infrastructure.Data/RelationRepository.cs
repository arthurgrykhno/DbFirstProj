using DbFirstProj.Domain.Interfaces.Repositories;
using DbFirstProj.Entities;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using DbFirstProj.Infrastructure.Data.Classes;

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
            relation.RelationAddresses[0].PostalCode = CodeParser.ChangeCode(relation, context);

            context.Relation.Add(relation);

            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity = context.Relation.FirstOrDefault(item => item.Id == id);

                if (entity != null)
                {
                    entity.IsDisabled = true;
                    //context.Relation.Update(entity);

                    context.SaveChanges();
                }
            }
        }

        public IEnumerable<Relation> GetAll(string sortingCondition = "", bool isDesc = false)
        {
            Func<Relation, string> keySelector = this.GetSortingCondition(sortingCondition);

            var all = context.Relation.Include(r => r.RelationAddresses).ThenInclude(e => e.Country);

            var result = isDesc ? all.OrderByDescending(keySelector) : all.OrderBy(keySelector);

            return result.ToList();
        }

        public IEnumerable<Relation> GetFiltredRelations(Guid id)
        {
            var all = context.Relation.Include(r => r.RelationCategories).Include(r => r.RelationAddresses).ThenInclude(e => e.Country)
                .Where(r => r.RelationCategories.Any(r => r.CategoryId == id));

            return all.ToList();
        }

        public Relation Get(Guid id)
        {
            return context.Relation.Find(id);
        }

        public void Update(Relation relation)
        {
            relation.RelationAddresses[0].PostalCode = CodeParser.ChangeCode(relation, context);
            context.Relation.Update(relation);

            context.SaveChanges();
        }

        private Func<Relation, string> GetSortingCondition(string sortingCondition)
        {
            Func<Relation, string> keySelector = r => r.Name;

            keySelector = sortingCondition switch
            {
                "name" => r => r.Name,
                "fullname" => r => r.FullName,
                "telephoneNumber" => r => r.TelephoneNumber,
                "eMailAddress" => r => r.EmailAddress,
                "country" => r => r.RelationAddresses[0].Country.Name,
                "city" => r => r.RelationAddresses[0].City,
                "street" => r => r.RelationAddresses[0].Street,
                "postalCode" => r => r.RelationAddresses[0].PostalCode,
                "number" => r => r.RelationAddresses[0].Number.ToString(),
                _ => r => r.Name,
            };
            return keySelector;
        }
    }
}

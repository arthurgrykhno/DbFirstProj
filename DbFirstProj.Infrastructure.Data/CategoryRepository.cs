using DbFirstProj.Domain.Interfaces.Repositories;
using DbFirstProj.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbFirstProj.Infrastructure.Data
{
    public class CategoryRepository : IGenericRepository<Category>
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository()
        {
            context = new ApplicationDbContext();
        }

        public void Create(Category category)
        {
            context.Category.Add(category);

            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var category = context.Category.Find(id);

            if (id != null)
            {
                context.Category.Remove(category);
            }

            context.SaveChanges();
        }

        public Category Get(Guid id)
        {
            return context.Category.Find(id);
        }

        public IEnumerable<Category> GetAll(string sortingCondition = "", bool isDesc = false)
        {
            return context.Category.ToList();
        }

        public void Update(Category category)
        {
            context.Entry(category).State = EntityState.Modified;
        }
    }
}

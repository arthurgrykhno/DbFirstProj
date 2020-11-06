using DbFirstProj.Domain.Interfaces.Repositories;
using DbFirstProj.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbFirstProj.Infrastructure.Data
{
    public class CountryRepository : IGenericRepository<Country>
    {
        private ApplicationDbContext context;

        public CountryRepository()
        {
            context = new ApplicationDbContext();
        }

        public void Create(Country country)
        {
            context.Country.Add(country);

            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var country = context.Country.Find(id);

            if (id != null)
            {
                context.Country.Remove(country);
            }

            context.SaveChanges();
        }

        public Country Get(Guid id)
        {
            return context.Country.Find(id);
        }

        public IEnumerable<Country> GetAll()
        {
            return context.Country.ToList();
        }
            
        public void Update(Country country)
        {
            context.Entry(country).State = EntityState.Modified;
        }
    }
}

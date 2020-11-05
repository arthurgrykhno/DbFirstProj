using DbFirstProj.Domain.Interfaces.Repositories;
using DbFirstProj.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbFirstProj.Infrastructure.Data
{
    public class AddressTypeRepository : IGenericRepository<AddressType>
    {
        private readonly ApplicationDbContext context;

        public AddressTypeRepository()
        {
            context = new ApplicationDbContext();
        }

        public void Create(AddressType addressType)
        {
            context.AddressType.Add(addressType);

            context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var addressType = context.AddressType.Find(id);

            if (id != null)
            {
                context.AddressType.Remove(addressType);
            }

            context.SaveChanges();
        }

        public AddressType Get(Guid id)
        {
            return context.AddressType.Find(id);
        }

        public IEnumerable<AddressType> GetAll(string sortingCondition = "", bool isDesc = false)
        {
            return context.AddressType.ToList();
        }

        public void Update(AddressType addressType)
        {
            context.Entry(addressType).State = EntityState.Modified;
        }
    }
}

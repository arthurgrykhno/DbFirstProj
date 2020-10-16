using DbFirstProj.Domain.Interfaces.Repositories;
using DbFirstProj.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbFirstProj.Infrastructure.Data
{
    public class AddressTypeRepository : IGenericRepository<AddressType>
    {
        private ApplicationDbContext context;

        public AddressTypeRepository()
        {
            context = new ApplicationDbContext();
        }

        public void Create(AddressType addressType)
        {
            context.AddressType.Add(addressType);

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var addressType = context.AddressType.Find(id);

            if (addressType != null)
            {
                context.AddressType.Remove(addressType);
            }

            context.SaveChanges();
        }

        public AddressType Get(int id)
        {
            return context.AddressType.Find(id);
        }

        public IEnumerable<AddressType> GetAll()
        {
            return context.AddressType.ToList();
        }

        public void Update(AddressType addressType)
        {
            context.Entry(addressType).State = EntityState.Modified;
        }
    }
}

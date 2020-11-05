using System;
using Xunit;
using DbFirstProj.Infrastructure.Data.Classes;
using Moq;
using DbFirstProj.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DbFirstProj.Infrastructure.Data.Tests
{
    public class CodeParserTests
    {
        private static readonly Guid SharedCountryId = Guid.Parse("00000000-0000-0000-0000-000000000004");

        private Relation relation = new Relation
        {
            Name = "Artur",
            FullName = "Artur Grihno",
            RelationAddresses = new List<RelationAddress>
            {
                new RelationAddress
                {
                    PostalCode = "",
                    CountryId = SharedCountryId
                }
            }
        };

        private Country country = new Country
        {
            Id = SharedCountryId,
            PostalCodeFormat = "NNNN_ll"
        };

        [Theory]
        [InlineData("8965Og", "8965_og")]
        [InlineData("kfig7851", "kfig7851")]
        [InlineData("7777 CF", "7777_cf")]
        public void IfCodeMatchesMask_Then_True(string actual, string expected)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "test")
                .Options;
            relation.RelationAddresses[0].PostalCode = actual;

            using var context = new ApplicationDbContext(options);

            if (context.Country.Find(country.Id) == null)
            {
                context.Country.Add(country);
            }

            context.Relation.Add(relation);
            context.SaveChanges();
            actual = CodeParser.ChangeCode(relation, context);
                
            Assert.Equal(expected, actual);
        }
    }
}

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Data;
using OnlineMarketingTools.DataExternal.Entities;
using OnlineMarketingTools.DataExternal.Repositories;
using Xunit;

namespace OnlineMarketingTools.Tests.DataExternal.Repositories
{
    public class PersonProductExternalRepositoryTest
    {
        private readonly DbContextOptions<PersonProductDbContext> _dbOptions =
            new DbContextOptionsBuilder<PersonProductDbContext>().UseInMemoryDatabase("hobby-db")
                .Options;

        private PersonProductDbContext GetNonRandomDataContext()
        {
            var context = new PersonProductDbContext(_dbOptions, false);
            return context;
        }
        
        private PersonProductExternalRepository GetRepo(PersonProductDbContext context)
        {
            return new (context);
        }
        
        [Fact]
        private async void GetAllFieldNames()
        {
            var context = GetNonRandomDataContext();
            var repo = GetRepo(context);
            var properties = typeof(PersonProduct).GetProperties();
            var repoAllPropertyNames = await repo.GetAllPropertyNames();

            var allPropertyNames = repoAllPropertyNames.ToList();
            Assert.Equal(properties.Length,allPropertyNames.Count());
            foreach (var prop in properties)
            {
                Assert.Contains(prop.Name, allPropertyNames);
            }

            await context.Database.EnsureDeletedAsync();
        }

        [Fact
        ]
        private async void GetAll()
        {
            var context = GetNonRandomDataContext();
            var repo = GetRepo(context);
            var hobbyPersons = context.PersonProducts.ToList();
            var repoHobbyPersons = (await repo.GetAll()).ToList();

            Assert.Equal(hobbyPersons.Count,repoHobbyPersons.Count());
            foreach (var person in hobbyPersons)
            {
                Assert.Contains(person.Id, repoHobbyPersons.Select(p=>p.Id));
            } 
            
            await context.Database.EnsureDeletedAsync();
        }

        [Fact]
        private async void GetByPropertyNameAndValue()
        {
            var context = GetNonRandomDataContext();
            var repo = GetRepo(context);
            var hobbyPersons = context.PersonProducts.ToList();

            var propertyNames = (await repo.GetAllPropertyNames()).ToList();
            foreach (var person in hobbyPersons)
            {
                foreach (var propertyName in propertyNames)
                {
                    var value = person.GetType().GetProperty(propertyName)?.GetValue(person)?.ToString();
                    var repoProductPersons = await repo.GetAllByPropertyNameAndValue(value, propertyName);

                    Assert.NotEmpty(repoProductPersons); 
                }
            }

            await context.Database.EnsureDeletedAsync();
        }
    }
}
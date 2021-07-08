using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Data;
using OnlineMarketingTools.DataExternal.Entities;
using OnlineMarketingTools.DataExternal.Repositories;
using Xunit;

namespace OnlineMarketingTools.Tests.DataExternal.Repositories
{
    public class PersonHobbyExternalRepositoryTest
    {
        private readonly DbContextOptions<PersonHobbyDbContext> _dbOptions =
            new DbContextOptionsBuilder<PersonHobbyDbContext>().UseInMemoryDatabase("hobby-db")
                .Options;

        private PersonHobbyDbContext GetNonRandomDataContext()
        {
            var context = new PersonHobbyDbContext(_dbOptions, false);
            return context;
        }

        private PersonHobbyExternalRepository GetRepo(PersonHobbyDbContext context)
        {
            return new(context);
        }

        [Fact]
        private async void GetAllFieldNames()
        {
            var context = GetNonRandomDataContext();
            var repo = GetRepo(context);
            var properties = typeof(PersonHobby).GetProperties();
            var repoAllPropertyNames = await repo.GetAllPropertyNames();

            var allPropertyNames = repoAllPropertyNames.ToList();
            Assert.Equal(properties.Length, allPropertyNames.Count());
            foreach (var prop in properties) Assert.Contains(prop.Name, allPropertyNames);

            await context.Database.EnsureDeletedAsync();
        }

        [Fact
        ]
        private async void GetAll()
        {
            var context = GetNonRandomDataContext();
            var repo = GetRepo(context);
            var hobbyPersons = context.PersonHobbies.ToList();
            var repoHobbyPersons = (await repo.GetAllAsync()).ToList();

            Assert.Equal(hobbyPersons.Count, repoHobbyPersons.Count());
            foreach (var person in hobbyPersons) Assert.Contains(person.Id, repoHobbyPersons.Select(p => p.Id));

            await context.Database.EnsureDeletedAsync();
        }

        [Fact]
        private async void GetByPropertyNameAndValue()
        {
            var context = GetNonRandomDataContext();
            var repo = GetRepo(context);
            var hobbyPersons = context.PersonHobbies.ToList();

            var propertyNames = (await repo.GetAllPropertyNamesAsync()).ToList();
            foreach (var person in hobbyPersons)
            foreach (var propertyName in propertyNames)
            {
                var value = person.GetType().GetProperty(propertyName)?.GetValue(person)?.ToString();
                var repoHobbyPersons = await repo.GetAllByPropertyNameAndValueAsync(value, propertyName);

                Assert.NotEmpty(repoHobbyPersons);
            }

            await context.Database.EnsureDeletedAsync();
        }
    }
}
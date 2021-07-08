using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.DataExternal.Data;
using OnlineMarketingTools.DataExternal.Entities;
using OnlineMarketingTools.DataExternal.Repositories;
using Xunit;

namespace OnlineMarketingTools.Tests.DataExternal.Repositories
{
    public class PersonMedicalExternalRepositoryTest
    {
        private readonly DbContextOptions<PersonMedicalDbContext> _dbOptions =
            new DbContextOptionsBuilder<PersonMedicalDbContext>().UseInMemoryDatabase("hobby-db")
                .Options;

        private PersonMedicalDbContext GetNonRandomDataContext()
        {
            var context = new PersonMedicalDbContext(_dbOptions, false);
            return context;
        }

        private PersonMedicalExternalRepository GetRepo(PersonMedicalDbContext context)
        {
            return new(context);
        }

        [Fact]
        private async void GetAllFieldNames()
        {
            var context = GetNonRandomDataContext();
            var repo = GetRepo(context);
            var properties = typeof(PersonMedical).GetProperties();
            var repoAllPropertyNames = await repo.GetAllPropertyNamesAsync();

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
            var hobbyPersons = context.MedicalPersons.ToList();
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
            var hobbyPersons = context.MedicalPersons.ToList();

            var propertyNames = (await repo.GetAllPropertyNamesAsync()).ToList();
            foreach (var person in hobbyPersons)
            foreach (var propertyName in propertyNames)
            {
                var value = person.GetType().GetProperty(propertyName)?.GetValue(person)?.ToString();
                var repoMedicalPersons = await repo.GetAllByPropertyNameAndValueAsync(value, propertyName);

                Assert.NotEmpty(repoMedicalPersons);
            }

            await context.Database.EnsureDeletedAsync();
        }
    }
}
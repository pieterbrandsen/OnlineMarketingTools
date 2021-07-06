using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.Core.Entities;
using OnlineMarketingTools.Core.Interfaces;
using OnlineMarketingTools.Database;
using OnlineMarketingTools.DataExternal.Data;
using OnlineMarketingTools.DataExternal.Entities;
using System.Linq;
using OnlineMarketingTools.Database.Data;

namespace OnlineMarketingTools.Database.Repositories
{
    public class PersonIntegratedRepositoy : IPersonIntegratedRepository
    {
        private readonly PersonIntegratedDbContext context;
        public PersonIntegratedRepositoy(PersonIntegratedDbContext context)
        {
            this.context = context;
        }

        //Todo

        /// <summary>
        ///     Gets an IEnumerable<PersonHobby> of All entity's in this DB
        /// </summary>
        /// <returns>Task<IEnumerable<PersonHobby>></returns>
        public async Task<IEnumerable<PersonIntegrated>> GetAll()
{
            return await context.PersonsIntegrated.ToListAsync();
        }

        /// <summary>
        ///     Gets a list of people by fieldname
        /// </summary>
        /// <param name="fieldName"> The name of the field you want to search for </param>
        /// <returns>Task<IEnumerable<PersonHobby>></returns>
        public async Task<IEnumerable<PersonIntegrated>> GetAllByPropertyNameAndValue(string value, string propertyName)
        {
            var result = context.PersonsIntegrated
               .Where(string.Format("{0} == {1}", propertyName, value))
               .AsEnumerable<PersonIntegrated>();

            return await Task.FromResult(result);
        }

        /// <summary>
        ///     Gets a single person based on the following 3 fields
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="postCode"></param>
        /// <returns>Task<PersonHobby></returns>
        public Task<PersonIntegrated> GetByFirstNameLastNameAndPostCode(string firstName, string lastName,
            string postCode)
        {
            var result = context.PersonsIntegrated
                .First(p => p.FirstName == firstName &&
                            p.LastName == lastName && 
                            p.PostCode == postCode);

            return Task.FromResult(result);
        }

        /// <summary>
        ///     Gets a single person based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task<PersonHobby></returns>
        public async Task<PersonIntegrated> GetById(int id)
        {
            var result = await context.PersonsIntegrated.FindAsync(id);

            return result;
        }

        /// <summary>
        /// Returns a bool weither adding succeeded or not.
        /// </summary>
        /// <param name="person">The PersonIntergrated object to add</param>
        /// <returns></returns>
        public async Task<bool> AddPerson(PersonIntegrated person)
        {
            if (!(GetByFirstNameLastNameAndPostCode(person.FirstName, person.LastName, person.PostCode) == null))
            {
                return false;
            }
            else
            {
                context.PersonsIntegrated.Add(person);
                await context.SaveChangesAsync();

                return true;
            }
        }

        /// <summary>
        /// Returns a bool weither updating succeeded or not.
        /// </summary>
        /// <param name="PersonToUpdate">The PersonIntergrated object to update</param>
        /// <returns></returns>
        public async Task<bool> UpdatePerson(PersonIntegrated PersonToUpdate)
        {
            if (GetByFirstNameLastNameAndPostCode(PersonToUpdate.FirstName, PersonToUpdate.LastName, PersonToUpdate.PostCode) == null)
            {
                return false;
            }
            else
            {
                context.Update(PersonToUpdate);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<IEnumerable<string>> GetAllPropertyNames()
        {
            var result = new List<string>();

            foreach (var entity in context.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    result.Add(property.Name);
                }
            }

            return await Task.FromResult(result);
        }

        public async Task<bool> AddRange(IEnumerable<PersonIntegrated> people)
        {
            var newPeople = new List<PersonIntegrated>();
            foreach (var person in people)
            {
                var result = !(await GetByFirstNameLastNameAndPostCode(person.FirstName, person.LastName, person.PostCode) == null);
                if (result == true)
                {
                    newPeople.Add(person);
                }
            }

            if (newPeople.Count() <= 0)
            {
                return false;
            }

            await context.AddRangeAsync(newPeople);

            context.SaveChanges();

            return true;
        }

        public async Task<bool> UpdateRange(IEnumerable<PersonIntegrated> PeopleToUpdate)
        {
            var peopleThatCanBeUpdated = new List<PersonIntegrated>();
            foreach (var person in PeopleToUpdate)
            {
                var result = await GetByFirstNameLastNameAndPostCode(person.FirstName, person.LastName, person.PostCode) == null;
                if (result == false)
                {
                    peopleThatCanBeUpdated.Add(person);
                }
            }

            if (peopleThatCanBeUpdated.Count() <= 0)
            {
                return false;
            }

            context.UpdateRange(peopleThatCanBeUpdated);

            context.SaveChanges();

            return true;
        }
    }
}
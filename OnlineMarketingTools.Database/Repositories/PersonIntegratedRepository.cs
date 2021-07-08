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
    public class PersonIntegratedRepositoy : IPersonIntegratedRepository, IDisposable
    {
        private readonly PersonIntegratedDbContext context;

        public PersonIntegratedRepositoy(PersonIntegratedDbContext context)
        {
            this.context = context;
        }

        //Todo

		/// <summary>
		/// Gets an IEnumerable<PersonHobby> of All entity's in this DB
		/// </summary>
		/// <returns>Task<IEnumerable<PersonHobby>></returns>
		public async Task<ICollection<PersonIntegrated>> GetAllAsync()
		{
			return await context.PersonsIntegrated.ToListAsync();
		}

        /// <summary>
        ///     Gets a list of people by fieldname
        /// </summary>
        /// <param name="fieldName"> The name of the field you want to search for </param>
        /// <returns>Task<IEnumerable<PersonHobby>></returns>
        public async Task<ICollection<PersonIntegrated>> GetAllByPropertyNameAndValueAsync(string value, string propertyName)
        {
            var result = context.PersonsIntegrated
                .Where(string.Format("{0} == {1}", propertyName, value))
                .AsEnumerable<PersonIntegrated>();

			return (ICollection<PersonIntegrated>)await Task.FromResult(result);
		}

        /// <summary>
        ///     Gets a single person based on the following 3 fields
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="postCode"></param>
        /// <returns>Task<PersonHobby></returns>
        public Task<PersonIntegrated> GetByFirstNameLastNameAndPostCodeAsync(string firstName, string lastName,
            string postCode)
        {
            var result = context.PersonsIntegrated
                .Where(p => p.FirstName == firstName &&
                            p.LastName == lastName &&
                            p.PostCode == postCode)
                .FirstOrDefault();

            return Task.FromResult(result);
        }

        /// <summary>
        ///     Gets a single person based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task<PersonHobby></returns>
        public async Task<PersonIntegrated> GetByIdAsync(int id)
        {
            var result = await context.PersonsIntegrated.FindAsync(id);

            return result;
        }

        /// <summary>
        /// Returns a bool weither adding succeeded or not.
        /// </summary>
        /// <param name="person">The PersonIntergrated object to add</param>
        /// <returns></returns>
        public async Task<bool> AddAsync(PersonIntegrated person)
        {
            if (!(await GetByFirstNameLastNameAndPostCodeAsync(person.FirstName, person.LastName, person.PostCode) == null))
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
        public async Task<bool> UpdateAsync(PersonIntegrated PersonToUpdate)
        {
            if (await GetByFirstNameLastNameAndPostCodeAsync(PersonToUpdate.FirstName, PersonToUpdate.LastName, PersonToUpdate.PostCode) == null)
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

        public async Task<ICollection<string>> GetAllPropertyNamesAsync()
        {
            var result = new List<string>();

            foreach (var entity in context.Model.GetEntityTypes())
            foreach (var property in entity.GetProperties())
                result.Add(property.Name);

            return await Task.FromResult(result);
        }

        public async Task<bool> AddRangeAsync(ICollection<PersonIntegrated> people)
        {
            var newPeople = new List<PersonIntegrated>();
            foreach (var person in people)
            {
                var result = await GetByFirstNameLastNameAndPostCodeAsync(person.FirstName, person.LastName, person.PostCode) == null;
                if (result == true)
                {
                    newPeople.Add(person);
                }
            }

            if (newPeople.Count() <= 0) return false;

            await context.AddRangeAsync(newPeople);

            context.SaveChanges();

            return true;
        }

        public async Task<bool> UpdateRangeAsync(ICollection<PersonIntegrated> PeopleToUpdate)
        {
            var peopleThatCanBeUpdated = new List<PersonIntegrated>();
            foreach (var person in PeopleToUpdate)
            {
                var result = await GetByFirstNameLastNameAndPostCodeAsync(person.FirstName, person.LastName, person.PostCode) == null;
                if (result == false)
                {
                    peopleThatCanBeUpdated.Add(person);
                }
            }

            if (peopleThatCanBeUpdated.Count() <= 0) return false;

            context.UpdateRange(peopleThatCanBeUpdated);

            context.SaveChanges();

            return true;
        }

        public void Dispose()
        {
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        public Task<ICollection<PersonIntegrated>> GetICollectionByFieldNameAndValue(string value, string fieldName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> FieldNames()
        {
            throw new NotImplementedException();
        }
    }
}
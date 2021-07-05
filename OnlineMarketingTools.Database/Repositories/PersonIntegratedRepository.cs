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

namespace OnlineMarketingTools.DataExternal.Repositories
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
        /// Gets an IEnumerable<PersonHobby> of All entity's in this DB
        /// </summary>
        /// <returns>Task<IEnumerable<PersonHobby>></returns>
        public async Task<IEnumerable<PersonIntegrated>> GetAll()
{
            return await context.PersonsIntegrated.ToListAsync();
        }

        /// <summary>
        /// Gets a list of people by fieldname
        /// </summary>
        /// <param name="fieldName"> The name of the field you want to search for </param>
        /// <returns>Task<IEnumerable<PersonHobby>></returns>
        public async Task<IEnumerable<PersonIntegrated>> GetIEnumerableByFieldNameAndValue(string value, string fieldName)
        {
            var result = context.PersonsIntegrated
               .Where(string.Format("{0} == {1}", fieldName, value))
               .AsEnumerable<PersonIntegrated>();

            return await Task.FromResult(result);
        }

        /// <summary>
        /// Gets a single person based on the following 3 fields
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="postCode"></param>
        /// <returns>Task<PersonHobby></returns>
        public Task<PersonIntegrated> GetByFirstNameLastNameAndPostCode(string firstName, string lastName, string postCode)
        {
            var result = context.PersonsIntegrated
                .Where(p => p.FirstName == firstName &&
                p.LastName == lastName && 
                p.PostCode == postCode)
                .First();

            return Task.FromResult(result);
        }

        /// <summary>
        /// Gets a single person based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task<PersonHobby></returns>
        public async Task<PersonIntegrated> GetById(int id)
        {
            var result = await context.PersonsIntegrated.FindAsync(id);

            return result;
        }
    }
}

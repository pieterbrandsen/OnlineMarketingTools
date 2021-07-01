using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineMarketingTools.Core.Interfaces;
using OnlineMarketingTools.DataExternal.Data;
using OnlineMarketingTools.DataExternal.Entities;

namespace OnlineMarketingTools.Database.Repositories.External
{
	public class PersonHobbyExternalRepository : IExternalRepository<PersonHobby>
    {
        private readonly PersonHobbyDbContext context;
        public PersonHobbyExternalRepository(PersonHobbyDbContext context)
        {
            this.context = context;
        }

        //Todo

        /// <summary>
        /// Gets an IEnumerable<PersonHobby> of All entity's in this DB
        /// </summary>
        /// <returns>Task<IEnumerable<PersonHobby>></returns>
        public Task<IEnumerable<PersonHobby>> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a list of people by fieldname
        /// </summary>
        /// <param name="fieldName"> The name of the field you want to search for </param>
        /// <returns>Task<IEnumerable<PersonHobby>></returns>
        public Task<IEnumerable<PersonHobby>> GetAllByFieldName(string value, string fieldName)
        {
            throw new NotImplementedException();
        }

    }
}

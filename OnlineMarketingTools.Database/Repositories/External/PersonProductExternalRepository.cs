using OnlineMarketingTools.Core.Interfaces;
using OnlineMarketingTools.DataExternal.Data;
using OnlineMarketingTools.DataExternal.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Database.Repositories.External
{
	public class PersonProductExternalRepository : IExternalRepository<PersonProduct>
    {
        private readonly PersonProductDbContext context;
        public PersonProductExternalRepository(PersonProductDbContext context)
        {
            this.context = context;
        }
        //Todo

        /// <summary>
        /// Gets an IEnumerable<PersonProduct> of All entity's in this DB
        /// </summary>
        /// <returns>Task<IEnumerable<PersonProduct>></returns>
        public Task<IEnumerable<PersonProduct>> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a list of people by fieldname
        /// </summary>
        /// <param name="fieldName"> The name of the field you want to search for </param>
        /// <returns>Task<IEnumerable<PersonProduct>></returns>
        public Task<IEnumerable<PersonProduct>> GetAllByFieldName(string value, string fieldName)
        {
            throw new NotImplementedException();
        }
    }
}

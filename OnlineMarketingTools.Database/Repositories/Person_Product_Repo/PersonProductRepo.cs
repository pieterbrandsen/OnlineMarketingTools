using OnlineMarketingTools.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineMarketingTools.Database.Data;

namespace OnlineMarketingTools.Database.Repositories.Person_Product_Repo
{
    public class PersonProductRepo : IPersonProductRepo
    {
        private readonly PersonProductDbContext context;
        public PersonProductRepo(PersonProductDbContext context)
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

        /// <summary>
        /// Gets a single person based on the following 3 fields
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="postCode"></param>
        /// <returns>Task<PersonProduct></returns>
        public Task<PersonProduct> GetByFirstNameLastNameAndPostCode(string firstName, string lastName, string postCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a single person based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task<PersonProduct></returns>
        public Task<PersonProduct> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

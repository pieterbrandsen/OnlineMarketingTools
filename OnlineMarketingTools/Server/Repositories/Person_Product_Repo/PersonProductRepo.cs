using OnlineMarketingTools.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Server.Repositories.Person_Product_Repo
{
    public class PersonProductRepo : IPersonProductRepo
    {
        //Todo
        public Task<IEnumerable<PersonProduct>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PersonProduct>> GetAllByFieldName(string fieldName)
        {
            throw new NotImplementedException();
        }

        public Task<PersonProduct> GetByFirstNameLastNameAndPostCode(string firstName, string lastName, string postCode)
        {
            throw new NotImplementedException();
        }

        public Task<PersonProduct> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

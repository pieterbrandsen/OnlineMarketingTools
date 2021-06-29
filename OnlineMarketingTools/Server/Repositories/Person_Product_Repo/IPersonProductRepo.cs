using OnlineMarketingTools.Core.Models.Hobby;
using OnlineMarketingTools.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Server.Repositories.Person_Product_Repo
{
    public interface IPersonProductRepo
    {
        public Task<IEnumerable<PersonProduct>> GetAll();
        public Task<IEnumerable<PersonProduct>> GetAllByFieldName(string fieldName);
        public Task<PersonProduct> GetByFirstNameLastNameAndPostCode(string firstName, string lastName, string postCode);
        public Task<PersonProduct> GetById(int id);
    }
}

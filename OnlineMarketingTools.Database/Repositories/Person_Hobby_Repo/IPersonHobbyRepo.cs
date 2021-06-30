using OnlineMarketingTools.Core.Models.Hobby;
using OnlineMarketingTools.Core.Models.Medical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Database.Repositories.Person_Hobby_Repo
{
    public interface IPersonHobbyRepo
    {
        public Task<IEnumerable<PersonHobby>> GetAll();
        public Task<IEnumerable<PersonHobby>> GetAllByFieldName(string value, string fieldName);
        public Task<PersonHobby> GetByFirstNameLastNameAndPostCode(string firstName, string lastName, string postCode);
        public Task<PersonHobby> GetById(int id);
    }
}

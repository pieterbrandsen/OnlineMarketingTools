using OnlineMarketingTools.Core.Models.Hobby;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Server.Repositories.Person_Hobby_Repo
{
    public class PersonHobbyRepo : IPersonHobbyRepo
    {
        //Todo
        public Task<IEnumerable<PersonHobby>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PersonHobby>> GetAllByFieldName(string fieldName)
        {
            throw new NotImplementedException();
        }

        public Task<PersonHobby> GetByFirstNameLastNameAndPostCode(string firstName, string lastName, string postCode)
        {
            throw new NotImplementedException();
        }

        public Task<PersonHobby> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

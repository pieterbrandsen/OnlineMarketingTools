using OnlineMarketingTools.Core.Models.Medical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Server.Repositories.Person_Medical_Repo
{
    public class PersonMedicalRepo : IPersonMedicalRepo
    {
        //Todo
        public Task<IEnumerable<PersonMedical>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PersonMedical>> GetAllByFieldName(string fieldName)
        {
            throw new NotImplementedException();
        }

        public Task<PersonMedical> GetByFirstNameLastNameAndPostCode(string firstName, string lastName, string postCode)
        {
            throw new NotImplementedException();
        }

        public Task<PersonMedical> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

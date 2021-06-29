using OnlineMarketingTools.Core.Models.Medical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Server.Repositories.Person_Medical_Repo
{
    public interface IPersonMedicalRepo
    {
        public Task<IEnumerable<PersonMedical>> GetAll();
        public Task<IEnumerable<PersonMedical>> GetAllByFieldName(string fieldName);
        public Task<PersonMedical> GetByFirstNameLastNameAndPostCode(string firstName, string lastName, string postCode);
        public Task<PersonMedical> GetById(int id);
    }
}

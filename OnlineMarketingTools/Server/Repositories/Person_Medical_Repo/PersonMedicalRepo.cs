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

        /// <summary>
        /// Gets an IEnumerable<PersonMedical> of All entity's in this DB
        /// </summary>
        /// <returns>Task<IEnumerable<PersonMedical>></returns>
        public Task<IEnumerable<PersonMedical>> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a list of people by fieldname
        /// </summary>
        /// <param name="fieldName"> The name of the field you want to search for </param>
        /// <returns>Task<IEnumerable<PersonMedical>></returns>
        public Task<IEnumerable<PersonMedical>> GetAllByFieldName(string fieldName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a single person based on the following 3 fields
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="postCode"></param>
        /// <returns>Task<PersonMedical></returns>
        public Task<PersonMedical> GetByFirstNameLastNameAndPostCode(string firstName, string lastName, string postCode)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a single person based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task<PersonMedical></returns>
        public Task<PersonMedical> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

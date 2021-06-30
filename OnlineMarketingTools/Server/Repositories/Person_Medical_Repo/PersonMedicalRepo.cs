using OnlineMarketingTools.Core.Models.Medical;
using OnlineMarketingTools.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Server.Repositories.Person_Medical_Repo
{
    public class PersonMedicalRepo : IPersonMedicalRepo
    {
        private readonly PersonMedicalDbContext context;
        public PersonMedicalRepo(PersonMedicalDbContext context)
        {
            this.context = context;
        }

        //Todo

        /// <summary>
        /// Gets an IEnumerable<PersonMedical> of All entity's in this DB
        /// </summary>
        /// <returns>Task<IEnumerable<PersonMedical>></returns>
        public async Task<IEnumerable<PersonMedical>> GetAll()
        {
            return await Task.FromResult(context.PersonMedicals);
        }

        /// <summary>
        /// Gets a list of people by fieldname
        /// </summary>
        /// <param name="fieldName"> The name of the field you want to search for </param>
        /// <returns>Task<IEnumerable<PersonMedical>></returns>
        public async Task<IEnumerable<PersonMedical>> GetAllByFieldName(string value, string fieldName)
        {
            var result = context.PersonMedicals.Where(string.Format($"{fieldName}=={value}"));

            return await Task.FromResult(result);
        }

        /// <summary>
        /// Gets a single person based on the following 3 fields
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="postCode"></param>
        /// <returns>Task<PersonMedical></returns>
        public async Task<PersonMedical> GetByFirstNameLastNameAndPostCode(string firstName, string lastName, string postCode)
        {
            var result = context.PersonMedicals.Where(p => p.FirstName == firstName && p.LastName == lastName && p.PostCode == postCode).First();

            return await Task.FromResult(result);
        }

        /// <summary>
        /// Gets a single person based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Task<PersonMedical></returns>
        public Task<PersonMedical> GetById(int id)
        {
            return Task.FromResult(context.PersonMedicals.Find(id));
        }
    }
}

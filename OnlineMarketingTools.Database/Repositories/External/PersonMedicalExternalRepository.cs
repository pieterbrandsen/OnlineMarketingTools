using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.Core.Interfaces;
using OnlineMarketingTools.DataExternal.Data;
using OnlineMarketingTools.DataExternal.Entities;

namespace OnlineMarketingTools.Database.Repositories.External
{
    public class PersonMedicalExternalRepository : IExternalRepository<PersonMedical>
    {
        private readonly PersonMedicalDbContext _context;

        public PersonMedicalExternalRepository(PersonMedicalDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<string>> FieldNames()
        {
            var result = new List<string>();

            foreach (var entity in _context.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    result.Add(property.Name);
                }
            }

            return await Task.FromResult(result);
        }

        /// <summary>
        ///     Gets an IEnumerable<PersonMedical> of All entity's in this DB
        /// </summary>
        /// <returns>Task<IEnumerable<PersonMedical>></returns>
        public async Task<IEnumerable<PersonMedical>> GetAll()
        {
            return await _context.MedicalPersons.ToListAsync();
        }

        /// <summary>
        ///     Gets a IEnumerable<PersonMedical> based on the name of the field and the value that field should have.
        /// </summary>
        /// <param name="value">The value of the field you want</param>
        /// <param name="fieldName">The name of the field you want to check</param>
        /// <returns></returns>
        public async Task<IEnumerable<PersonMedical>> GetIEnumerableByFieldNameAndValue(string value, string fieldName)
        {
            var result = _context.MedicalPersons
                .Where(string.Format("{0} == {1}", fieldName, value))
                .AsEnumerable<PersonMedical>();

            return await Task.FromResult(result);
        }
    }
}
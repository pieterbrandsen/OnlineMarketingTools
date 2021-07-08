using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.Core.Interfaces;
using OnlineMarketingTools.DataExternal.Data;
using OnlineMarketingTools.DataExternal.Entities;

namespace OnlineMarketingTools.DataExternal.Repositories
{
    public class PersonMedicalExternalRepository : IExternalRepository<PersonMedical>
    {
        private readonly PersonMedicalDbContext _context;

        public PersonMedicalExternalRepository(PersonMedicalDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<string>> GetAllPropertyNamesAsync()
        {
            var result = new List<string>();

            foreach (var entity in _context.Model.GetEntityTypes())
            foreach (var property in entity.GetProperties())
                result.Add(property.Name);

            return await Task.FromResult(result);
        }

        /// <summary>
        ///     Gets an IEnumerable<PersonMedical> of All entity's in this DB
        /// </summary>
        /// <returns>Task<IEnumerable<PersonMedical>></returns>
        public async Task<ICollection<PersonMedical>> GetAllAsync()
        {
            return await _context.MedicalPersons.ToListAsync();
        }

        /// <summary>
        ///     Gets a IEnumerable<PersonMedical> based on the name of the field and the value that field should have.
        /// </summary>
        /// <param name="value">The value of the field you want</param>
        /// <param name="fieldName">The name of the field you want to check</param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public async Task<ICollection<PersonMedical>> GetAllByPropertyNameAndValueAsync(string value,
            string propertyName)
        {
            var result = _context.MedicalPersons
                .Where(string.Format("{0} == {1}", propertyName, Expression.Constant(value)))
                .AsEnumerable<PersonMedical>();

            var lenght = result.Count();
            return (ICollection<PersonMedical>) await Task.FromResult(result);
        }

        Task<ICollection<PersonMedical>> IExternalRepository<PersonMedical>.GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<PersonMedical>> GetICollectionByFieldNameAndValue(string value, string fieldName)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<string>> FieldNames()
        {
            throw new System.NotImplementedException();
        }
    }
}
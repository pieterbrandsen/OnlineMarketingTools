using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.Core.Interfaces;
using OnlineMarketingTools.DataExternal.Data;
using OnlineMarketingTools.DataExternal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Database.Repositories.External
{
	public class PersonProductExternalRepository : IExternalRepository<PersonProduct>
    {
        private readonly PersonProductDbContext _context;
        public PersonProductExternalRepository(PersonProductDbContext context)
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
        /// Gets an IEnumerable<PersonProduct> of All entity's in this DB
        /// </summary>
        /// <returns>Task<IEnumerable<PersonProduct>></returns>
        public async Task<IEnumerable<PersonProduct>> GetAll()
{
            return await _context.PersonProducts.ToListAsync();
        }

        /// <summary>
        /// Gets a IEnumerable<PersonHobby> based on the name of the field and the value that field should have.
        /// </summary>
        /// <param name="value">The value of the field you want</param>
        /// <param name="fieldName">The name of the field you want to check</param>
        /// <returns></returns>
        public async Task<IEnumerable<PersonProduct>> GetIEnumerableByFieldNameAndValue(string value, string fieldName)
        {
            var result = _context.PersonProducts
               .Where(string.Format("{0} == {1}", fieldName, value))
               .AsEnumerable<PersonProduct>();

            return await Task.FromResult(result);
        }
    }
}

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
    public class PersonProductExternalRepository : IExternalRepository<PersonProduct>
    {
        private readonly PersonProductDbContext _context;

        public PersonProductExternalRepository(PersonProductDbContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Gets an IEnumerable<PersonProduct> of All entity's in this DB
        /// </summary>
        /// <returns>Task<IEnumerable<PersonProduct>></returns>
        public async Task<IEnumerable<PersonProduct>> GetAll()
        {
            return await _context.PersonProducts.ToListAsync();
        }

        /// <summary>
        ///     Gets a IEnumerable<PersonHobby> based on the name of the field and the value that field should have.
        /// </summary>
        /// <param name="value">The value of the field you want</param>
        /// <param name="fieldName">The name of the field you want to check</param>
        /// <returns></returns>
        public async Task<IEnumerable<PersonProduct>> GetAllByFieldName(string value, string fieldName)
        {
            var result = _context.PersonProducts
                .Where(string.Format("{0} == {1}", fieldName, value))
                .AsEnumerable<PersonProduct>();

            return await Task.FromResult(result);
        }
    }
}
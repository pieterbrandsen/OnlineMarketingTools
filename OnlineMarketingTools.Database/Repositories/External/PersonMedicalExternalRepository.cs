using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineMarketingTools.Core.Interfaces;
using OnlineMarketingTools.DataExternal.Data;
using OnlineMarketingTools.DataExternal.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace OnlineMarketingTools.Database.Repositories.External
{
	public class PersonMedicalExternalRepository : IExternalRepository<PersonMedical>
    {
        private readonly PersonMedicalDbContext _context;
        public PersonMedicalExternalRepository(PersonMedicalDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Gets an IEnumerable<PersonMedical> of All entity's in this DB
        /// </summary>
        /// <returns>Task<IEnumerable<PersonMedical>></returns>
        public async Task<IEnumerable<PersonMedical>> GetAll()
        {
            return await _context.PersonMedicals.ToListAsync();
        }

        /// <summary>
        /// Gets a IEnumerable<PersonMedical> based on the name of the field and the value that field should have.
        /// </summary>
        /// <param name="value">The value of the field you want</param>
        /// <param name="fieldName">The name of the field you want to check</param>
        /// <returns></returns>
        public async Task<IEnumerable<PersonMedical>> GetIEnumerableByFieldNameAndValue(string value, string fieldName)
        {
            var result = _context.PersonMedicals
                .Where(string.Format("{0} == {1}", fieldName, value))
                .AsEnumerable<PersonMedical>();

            return await Task.FromResult(result);
        }
	}
}

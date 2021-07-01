using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            this._context = context;
        }

        //Todo

        /// <summary>
        /// Gets an IEnumerable<PersonMedical> of All entity's in this DB
        /// </summary>
        /// <returns>Task<IEnumerable<PersonMedical>></returns>
        public async Task<IEnumerable<PersonMedical>> GetAll()
        {
            return await Task.FromResult(_context.PersonMedicals.ToList<PersonMedical>());
        }

        /// <summary>
        /// Gets a list of people by fieldname
        /// </summary>
        /// <param name="fieldName"> The name of the field you want to search for </param>
        /// <returns>Task<IEnumerable<PersonMedical>></returns>
        public async Task<IEnumerable<PersonMedical>> GetAllByFieldName(string value, string fieldName)
        {
            //TODO: select on value and fieldname
            var result = _context.PersonMedicals.Where(p => p.MedicalState.ToString() == fieldName);

            return await Task.FromResult(result);
        }
	}
}

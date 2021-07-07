using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.Core.Interfaces;
using OnlineMarketingTools.DataExternal.Data;
using OnlineMarketingTools.DataExternal.Entities;

gTools.DataExternal.Entities;

namespace OnlineMarketingTools.DataExternal.Repositories
{
    public class PersonHobbyExternalRepository : IExternalRepository<PersonHobby>
    {
        private readonly PersonHobbyDbContext _context;

        public PersonHobbyExternalRepository(PersonHobbyDbContext context)
        {
          await Task/// <summary>
        ///     Gets an IEnumerable<PersonHobby> of All entity's in this DB
        /// </summary>
        /// <returns>Task<IEnumerable<PersonHobby>></returns>Task<IEnumerable<PersonHobby>></returns>
        public async Task<IEnumerable<PersonHobby>> GetAll()
        {
            return await _contex

        public async Task<IEnumerable<string>> FieldNames()
        {
            var result = new List<string>();

            foreach (var entity in _context.Model.GetEntityTypes())
            foreach (var property in entity.GetProperties())
                result.Add(property.Name);

            return await Task.FromResult(result);
        }t.PersonHo/// <summary>
        ///     Gets a IEnumerable<PersonHobby> based on the name of the field and the value that field should have.
        /// </summary>
        /// <param name="value">The value of the field you want</param>
        /// <param name="fieldName">The name of the field you want to check</param>
        /// <returns></returns></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PersonHobby>> GetAllByPropertyNameAndValue(string value, string propertyName)
        {
            var result = _context.PersonHobbies
                .Where(string.Format("{0} == {1}", propertyName, Expression.Constant(value
                   .AsEnumerable<PersonHobby>();

            return await Task.FromResult(result);
        }

		Task<ICollection<PersonHobby>> IExternalRepository<PersonHobby>.GetAll()
		{
			throw new System.NotImplementedException();
		}

		public Task<ICollection<PersonHobby>> GetICollectionByFieldNameAndValue(string value, string fieldName)
		{
			throw new System.NotImplementedException();
		}

		public Task<IEnumerable<string>> FieldNames()
		{
			throw new System.NotImplementedException();
		}
	}
}
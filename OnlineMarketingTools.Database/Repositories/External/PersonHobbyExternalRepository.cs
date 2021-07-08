using System;
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
    public class PersonHobbyExternalRepository : IExternalRepository<PersonHobby>
    {
        private readonly PersonHobbyDbContext _context;

        public PersonHobbyExternalRepository(PersonHobbyDbContext context)
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
        /// Gets an IEnumerable<PersonHobby> of All entity's in this DB
        /// </summary>
        /// <returns>Task<IEnumerable<PersonHobby>></returns>
        public async Task<ICollection<PersonHobby>> GetAllAsync()
        {
            return await _context.PersonHobbies.ToListAsync();
        }

        public Task<ICollection<PersonHobby>> GetICollectionByFieldNameAndValue(string value, string fieldName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a IEnumerable<PersonHobby> based on the name of the field and the value that field should have.
        /// </summary>
        /// <param name="value">The value of the field you want</param>
        /// <param name="fieldName">The name of the field you want to check</param>
        /// <returns></returns>
		public async Task<ICollection<PersonHobby>> GetAllByPropertyNameAndValueAsync(string value, string fieldName)
        {
            var result = _context.PersonHobbies
                .Where(string.Format("{0} == {1}", fieldName, value))
                .AsEnumerable<PersonHobby>();

            return (ICollection<PersonHobby>)await Task.FromResult(result);
        }

        Task<ICollection<PersonHobby>> IExternalRepository<PersonHobby>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
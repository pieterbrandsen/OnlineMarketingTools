using OnlineMarketingTools.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Core.Interfaces
{
    public interface IPersonIntegratedRepository : IExternalRepository<PersonIntegrated>
    {
        public Task<PersonIntegrated> GetByFirstNameLastNameAndPostCodeAsync(string firstName, string lastName,
            string postCode);

        public Task<PersonIntegrated> GetByIdAsync(int id);
        public Task<bool> AddAsync(PersonIntegrated person);
        public Task<bool> AddRangeAsync(ICollection<PersonIntegrated> persons);
        public Task<bool> UpdateAsync(PersonIntegrated updatedPerson);
        public Task<bool> UpdateRangeAsync(ICollection<PersonIntegrated> updatedPersons);
        public void Dispose();
    }
}
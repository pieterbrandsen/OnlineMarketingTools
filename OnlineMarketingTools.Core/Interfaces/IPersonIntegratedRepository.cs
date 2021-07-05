using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Core.Interfaces
{
	public interface IPersonIntegratedRepository : IExternalRepository<PersonIntegrated>
	{
        public Task<PersonIntegrated> GetByFirstNameLastNameAndPostCode(string firstName, string lastName, string postCode);
        public Task<PersonIntegrated> GetById(int id);
        public Task<bool> AddPerson(PersonIntegrated person);
        public Task<bool> AddRange(IEnumerable<PersonIntegrated> people);
        public Task<bool> UpdatePerson(PersonIntegrated PersonToUpdate);
        public Task<bool> UpdateRange(IEnumerable<PersonIntegrated> PeopleToUpdate);
    }
}

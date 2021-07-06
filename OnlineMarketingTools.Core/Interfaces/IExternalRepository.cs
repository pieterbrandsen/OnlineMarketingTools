using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Core.Interfaces
{
	//Repositories for external data should at least have the ability to fill the integration database
	//and perhaps? a specialized get by fiels/demography
	public interface IExternalRepository<T> where T :class
	{
		public Task<ICollection<T>> GetAll();
		public Task<ICollection<T>> GetICollectionByFieldNameAndValue(string value, string fieldName);
		public Task<IEnumerable<string>> FieldNames();
	}
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Core.Interfaces
{
	//Repositories for external data should at least have the ability to fill the integration database
	//and perhaps? a specialized get by fiels/demography
	public interface IExternalRepository<T> where T :class
	{
		public Task<ICollection<T>> GetAllAsync();
		public Task<ICollection<T>> GetAllByPropertyNameAndValueAsync(string value, string propertyName);
		public Task<ICollection<string>> GetAllPropertyNamesAsync();
	}
}
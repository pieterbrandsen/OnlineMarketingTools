using OnlineMarketingTools.Core.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Core.Models.Product
{
    public interface IPersonProduct
    {
        public ProductGenreEnum ProductGenre { get; set; }
    }
    public class PersonProduct : PersonBase, IPersonProduct
    {
        public ProductGenreEnum ProductGenre { get; set; }
    }

    public enum ProductGenreEnum
    {
        Sport,
        Gaming,
        Birdwatching,
        Food,
        Medical
    }
}

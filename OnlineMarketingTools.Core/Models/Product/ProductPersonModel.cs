using OnlineMarketingTools.Core.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Core.Models.Product
{
    class ProductPersonModel : BasePersonModel
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

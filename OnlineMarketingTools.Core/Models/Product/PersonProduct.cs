using OnlineMarketingTools.Core.Models.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Core.Models.Product
{
    public class PersonProduct : PersonBase
    {
        public ProductGenreEnum ProductGenre { get; set; }
    }
}

using OnlineMarketingTools.Core.Models.General;
using OnlineMarketingTools.Core.Models.Hobby;
using OnlineMarketingTools.Core.Models.Medical;
using OnlineMarketingTools.Core.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Core.Models.Completed
{
    public class PersonCompleted : PersonBase, IPersonHobby, IPersonMedical, IPersonProduct
    {
        // Hobby
        public HobbyEnum Hobby {get; set; }
        
        // Medical
        public MedicalEnum MedicalState {get; set; }
        
        // Product
        public ProductGenreEnum ProductGenre {get; set; }
    }
}

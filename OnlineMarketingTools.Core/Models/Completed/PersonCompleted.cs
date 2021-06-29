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
    public class PersonCompleted : IPersonHobby, IPersonMedical, IPersonProduct, IPersonBase
    {
        // Hobby
        public HobbyEnum Hobby {get; set; }
        
        // Medical
        public MedicalEnum MedicalState {get; set; }
        
        // Product
        public ProductGenreEnum ProductGenre {get; set; }
    
        // Base
        public int Key {get; set; }
        public string FirstName {get; set; }
        public string MiddleName {get; set; }
        public string LastName {get; set; }
        public string Email {get; set; }
        public string PhoneNumber {get; set; }
        public string Adress {get; set; }
        public int HouseNumber {get; set; }
        public string PostCode {get; set; }
        public string Country {get; set; }
    }
}

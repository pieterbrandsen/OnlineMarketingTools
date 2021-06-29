using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Core.Models.General
{
    public class BasePersonModel
    {
        public int Key { get;set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Adress { get; set; }
        public int HouseNumber { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }
}

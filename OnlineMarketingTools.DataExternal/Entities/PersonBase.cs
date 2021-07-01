using System.ComponentModel.DataAnnotations;

namespace OnlineMarketingTools.DataExternal.Entities
{
    public class PersonBase
    {
        public int Key { get;set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        public int HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}

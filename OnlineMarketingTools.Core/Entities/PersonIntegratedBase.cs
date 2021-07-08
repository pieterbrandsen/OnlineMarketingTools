using System.ComponentModel.DataAnnotations;

namespace OnlineMarketingTools.Core.Entities
{
    public class PersonIntegratedBase
    {
        public int Id { get; set; }
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
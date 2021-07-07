using OnlineMarketingTools.Core.Entities;
using OnlineMarketingTools.DataExternal.Data;
using OnlineMarketingTools.DataExternal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Database.Data
{
    public static class IntergratedMockDataGenerator
    { 

        public static IEnumerable<PersonIntegrated> InterGratedPersonData()
        {
            var persons = new List<PersonIntegrated>();
            for (var i = 0; i < 10; i++)
                persons.Add(new PersonIntegrated()
                {
                    Key = MockDataGenerator.Ids[i],
                    Adress = MockDataGenerator.Addresses[i],
                    Country = MockDataGenerator.Countries[i],
                    Email = MockDataGenerator.Emails[i],
                    FirstName = MockDataGenerator.FirstNames[i],
                    MiddleName = MockDataGenerator.MiddleNames[i],
                    LastName = MockDataGenerator.LastNames[i],
                    HouseNumber = i,
                    PhoneNumber = MockDataGenerator.PhoneNumbers[i],
                    PostCode = MockDataGenerator.PostalCodes[i],
                    Hobby = MockDataGenerator.HobbyEnumValues[i].ToString(),
                    MedicalState = MockDataGenerator.MedicalEnumValues[i].ToString(),
                    ProductGenre = MockDataGenerator.ProductGenreEnumValues[i].ToString()
                });

            return persons;
        }
    }
}

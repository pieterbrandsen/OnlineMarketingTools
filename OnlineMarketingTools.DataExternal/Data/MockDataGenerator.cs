using System;
using System.Collections.Generic;
using OnlineMarketingTools.DataExternal.Entities;

namespace OnlineMarketingTools.DataExternal.Data
{
    public static class MockDataGenerator
    {
        private static readonly Random Rnd = new ();

        private static IEnumerable<PersonBase> PersonData(int amount)
        {
            var adresses = new List<string>()
            {
                "7905 Kensington Court",
                "7 Badeau Parkway",
                "0104 Holmberg Lane",
                "24 Charing Cross Parkway",
                "50835 Loeprich Hill",
                "39571 Saint Paul Court",
                "43 Anthes Avenue",
                "16 Beilfuss Way",
                "9041 Melvin Terrace",
                "4430 Buena Vista Circle",
            };
            var countries = new List<string>()
            {
                "Philippines",
                "Greece",
                "Sweden",
                "China",
                "Czech Republic",
                "Colombia",
                "Denmark",
                "Indonesia",
                "Israel",
                "Argentina",
            };

            var emails = new List<string>()
            {
                "hkibby0@nbcnews.com",
                "cklimkovich1@chronoengine.com",
                "nsyder4@g.co",
                "bsoot5@harvard.edu",
                "wlally7@ycombinator.com",
                "cpedro8@flavors.me",
                "cbarnewell9@ehow.com",
                "fbrentona@prweb.com",
                "mgabbatb@xing.com",
                "schampc@prweb.com",
            };

            var firstNames = new List<string>()
            {
                "Oswell",
                "Myron",
                "Keeley",
                "Rori",
                "Floyd",
                "Bret",
                "Retha",
                "Zack",
                "Amalita",
                "Westley",
            };
            
            var lastNames = new List<string>()
            {
                "Kibby",
                "Klimkovich",
                "Gianetti",
                "Cawkill",
                "Syder",
                "Soot",
                "Hiskey",
                "Lally",
                "Pedro",
                "Barnewell",
            };
            
            var middleNames = new List<string>()
            {
                "Haley",
                "Carleton",
                "Hervey",
                "Ripley",
                "Nappie",
                "Dominick",
                "Winifield",
                "Clive",
                "Colver",
                "Finlay",
            };
            
            var phoneNumbers = new List<string>()
            {
                "(115) 4055413",
                "(766) 8489121",
                "(922) 9770036",
                "(567) 1771772",
                "(505) 9496337",
                "(534) 4101214",
                "(105) 6483636",
                "(814) 5145528",
                "(320) 4010865",
                "(213) 7148680",
                "(476) 7629808",
            };
            
            var postalCodes = new List<string>()
            {
                "4055413",
                "8489121",
                "9770036",
                "1771772",
                "9496337",
                "4101214",
                "6483636",
                "5145528",
                "4010865",
                "7148680",
                "7629808",
            };
            
            var persons = new List<PersonBase>();
            for (var i = amount - 1; i >= 0; i--)
            {
                persons.Add(new PersonBase
                {
                    Key = i, 
                    Address = adresses[Rnd.Next(adresses.Count)],
                    Country = countries[Rnd.Next(countries.Count)],
                    Email =  emails[Rnd.Next(emails.Count)],
                    FirstName = firstNames[Rnd.Next(firstNames.Count)],
                    MiddleName = middleNames[Rnd.Next(middleNames.Count)],
                    LastName = lastNames[Rnd.Next(lastNames.Count)],
                    HouseNumber = i,
                    PhoneNumber = phoneNumbers[Rnd.Next(phoneNumbers.Count)],
                    PostalCode = postalCodes[Rnd.Next(postalCodes.Count)]
                });
            }

            return persons;
        }

        public static List<PersonMedical> PersonMedicalData(int amount)
        {
            if (PersonData(amount) is not List<PersonMedical> persons) return null;
            foreach (var person in persons)
            {
                person.MedicalState = (MedicalEnum) Rnd.Next(Enum.GetValues<MedicalEnum>().Length);
            }

            return persons;
        }

        public static List<PersonHobby> PersonHobbiesData(int amount)
        {
            if (PersonData(amount) is not List<PersonHobby> persons) return null;
            foreach (var person in persons)
            {
                person.Hobby = (HobbyEnum) Rnd.Next(Enum.GetValues<HobbyEnum>().Length);
            }

            return persons;
        }
        
        public static List<PersonProduct> PersonProductData(int amount)
        {
            if (PersonData(amount) is not List<PersonProduct> persons) return null;
            foreach (var person in persons)
            {
                person.ProductGenre = (ProductGenreEnum) Rnd.Next(Enum.GetValues<ProductGenreEnum>().Length);
            }

            return persons;
        }
    }
}
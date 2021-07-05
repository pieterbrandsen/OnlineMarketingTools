using System;
using System.Collections.Generic;
using System.Linq;
using OnlineMarketingTools.DataExternal.Entities;

namespace OnlineMarketingTools.DataExternal.Data
{
    public static class MockDataGenerator
    {
        private static readonly Random Rnd = new ();
        
        public static List<int> Ids = new()
        {
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8,
            9,
            10,
        };
            public static List<string> addresses = new()
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
            public static List<string> countries = new()
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

            public static List<string> emails = new()
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

            public static List<string> firstNames = new()
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
            
            public static List<string> lastNames = new()
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
            
            public static List<string> middleNames = new()
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
            
            public static List<string> phoneNumbers = new()
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
            
            public static List<string> postalCodes = new()
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
            
            public static List<string> medicalEnumValues = new()
            {
                "0",
                "1",
                "2",
                "3",
                "4",
                "0",
                "1",
                "2",
                "3",
                "4",
            };
            
            public static List<string> hobbyEnumValues = new()
            {
                "0",
                "1",
                "2",
                "0",
                "1",
                "2",
                "0",
                "1",
                "2",
                "0",
            };
            
            public static List<string> productGenreEnumValues = new()
            {
                "0",
                "1",
                "2",
                "3",
                "4",
                "0",
                "1",
                "2",
                "3",
                "4",
            };

            private static IEnumerable<TPerson> PersonData<TPerson>() where TPerson: PersonBase, new()
            {
                var persons = new List<TPerson>();
                for (var i = 0; i < 10; i++)
                {
                    persons.Add(new()
                    {
                        Id = Ids[i],
                        Address = addresses[i],
                        Country = countries[i],
                        Email = emails[i],
                        FirstName = firstNames[i],
                        MiddleName = middleNames[i],
                        LastName = lastNames[i],
                        HouseNumber = i,
                        PhoneNumber = phoneNumbers[i],
                        PostalCode = postalCodes[i]
                    });
                }

                return persons;
            }
            private static IEnumerable<TPerson> PersonRandomData<TPerson>(int amount) where TPerson: PersonBase, new()
            {
                var persons = new List<TPerson>();
                for (var i = amount - 1; i >= 0; i--)
                {
                    persons.Add(new ()
                    {
                        Id = Ids[i],
                        Address = addresses[Rnd.Next(addresses.Count)],
                        Country = countries[Rnd.Next(countries.Count)],
                        Email = emails[Rnd.Next(emails.Count)],
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

        public static IEnumerable<PersonMedical> PersonMedicalData()
        {
            if (PersonData<PersonMedical>() is not List<PersonMedical> persons) return null;
            for (int i = 0; i < persons.Count; i++)
            {
                var person = persons[i];
                var medicalEnumValue = medicalEnumValues[i];
                person.MedicalState = (MedicalEnum) Convert.ToInt32(medicalEnumValue);
            }

            return persons;
        }
        
        public static IEnumerable<PersonMedical> PersonMedicalRandomData(int amount = 10000)
        {
            if (PersonRandomData<PersonMedical>(amount) is not List<PersonMedical> persons) return null;
            foreach (var person in persons)
            {
                person.MedicalState = (MedicalEnum) Rnd.Next(Enum.GetValues<MedicalEnum>().Length);
            }

            return persons;
        }

        public static IEnumerable<PersonHobby> PersonHobbiesData()
        {
            if (PersonData<PersonHobby>() is not List<PersonHobby> persons) return null;
            for (int i = 0; i < persons.Count; i++)
            {
                var person = persons[i];
                var hobbyEnumValue = hobbyEnumValues[i];
                person.Hobby = (HobbyEnum) Convert.ToInt32(hobbyEnumValue);
            }

            return persons;
        }
        
        public static IEnumerable<PersonHobby> PersonHobbiesRandomData(int amount = 10000)
        {
            if (PersonRandomData<PersonHobby>(amount) is not List<PersonHobby> persons) return null;
            foreach (var person in persons)
            {
                person.Hobby = (HobbyEnum) Rnd.Next(Enum.GetValues<HobbyEnum>().Length);
            }

            return persons;
        }
        
        public static IEnumerable<PersonProduct> PersonProductData()
        {
            if (PersonData<PersonHobby>() is not List<PersonProduct> persons) return null;
            for (int i = 0; i < persons.Count; i++)
            {
                var person = persons[i];
                var productGenreEnumValue = productGenreEnumValues[i];
                person.ProductGenre = (ProductGenreEnum) Convert.ToInt32(productGenreEnumValue);
            }

            return persons;
        }
        
        public static IEnumerable<PersonProduct> PersonProductRandomData(int amount = 10000)
        {
            if (PersonRandomData<PersonProduct>(amount) is not List<PersonProduct> persons) return null;
            foreach (var person in persons)
            {
                person.ProductGenre = (ProductGenreEnum) Rnd.Next(Enum.GetValues<HobbyEnum>().Length);
            }

            return persons;
        }
    }
}
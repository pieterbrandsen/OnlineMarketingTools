using System;
using System.Collections.Generic;
using System.Linq;
using OnlineMarketingTools.DataExternal.Entities;

namespace OnlineMarketingTools.DataExternal.Data
{
    public static class MockDataGenerator
    {
        private static readonly Random Rnd = new();

        public static readonly List<int> Ids = new()
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
            10
        };

        public static readonly List<string> Addresses = new()
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
            "4430 Buena Vista Circle"
        };

        public static readonly List<string> Countries = new()
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
            "Argentina"
        };

        public static readonly List<string> Emails = new()
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
            "schampc@prweb.com"
        };

        public static readonly List<string> FirstNames = new()
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
            "Westley"
        };

        public static readonly List<string> LastNames = new()
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
            "Barnewell"
        };

        public static readonly List<string> MiddleNames = new()
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
            "Finlay"
        };

        public static readonly List<string> PhoneNumbers = new()
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
            "(213) 7148680"
        };

        public static readonly List<string> PostalCodes = new()
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
            "7148680"
        };

        public static readonly List<MedicalEnum> MedicalEnumValues = new()
        {
            MedicalEnum.Critical,
            MedicalEnum.Fair,
            MedicalEnum.Good,
            MedicalEnum.Serious,
            MedicalEnum.Undetermined,
            MedicalEnum.Critical,
            MedicalEnum.Fair,
            MedicalEnum.Good,
            MedicalEnum.Serious,
            MedicalEnum.Undetermined
        };

        public static readonly List<HobbyEnum> HobbyEnumValues = new()
        {
            HobbyEnum.Gaming,
            HobbyEnum.Sport,
            HobbyEnum.BirdWatching,
            HobbyEnum.Gaming,
            HobbyEnum.Sport,
            HobbyEnum.BirdWatching,
            HobbyEnum.Gaming,
            HobbyEnum.Sport,
            HobbyEnum.BirdWatching,
            HobbyEnum.Gaming
        };

        public static readonly List<ProductGenreEnum> ProductGenreEnumValues = new()
        {
            ProductGenreEnum.Birdwatching,
            ProductGenreEnum.Food,
            ProductGenreEnum.Gaming,
            ProductGenreEnum.Medical,
            ProductGenreEnum.Sport,
            ProductGenreEnum.Birdwatching,
            ProductGenreEnum.Food,
            ProductGenreEnum.Gaming,
            ProductGenreEnum.Medical,
            ProductGenreEnum.Sport
        };

        private static IEnumerable<TPerson> PersonData<TPerson>() where TPerson : PersonBase, new()
        {
            var persons = new List<TPerson>();
            for (var i = 0; i < 10; i++)
                persons.Add(new TPerson
                {
                    Id = Ids[i],
                    Address = Addresses[i],
                    Country = Countries[i],
                    Email = Emails[i],
                    FirstName = FirstNames[i],
                    MiddleName = MiddleNames[i],
                    LastName = LastNames[i],
                    HouseNumber = i,
                    PhoneNumber = PhoneNumbers[i],
                    PostalCode = PostalCodes[i]
                });

            return persons;
        }

        private static IEnumerable<TPerson> PersonRandomData<TPerson>(int amount) where TPerson : PersonBase, new()
        {
            var persons = new List<TPerson>();
            for (var i = amount; i >= 1; i--)
                persons.Add(new TPerson
                {
                    Id = i,
                    Address = Addresses[Rnd.Next(Addresses.Count)],
                    Country = Countries[Rnd.Next(Countries.Count)],
                    Email = Emails[Rnd.Next(Emails.Count)],
                    FirstName = FirstNames[Rnd.Next(FirstNames.Count)],
                    MiddleName = MiddleNames[Rnd.Next(MiddleNames.Count)],
                    LastName = LastNames[Rnd.Next(LastNames.Count)],
                    HouseNumber = i,
                    PhoneNumber = PhoneNumbers[Rnd.Next(PhoneNumbers.Count)],
                    PostalCode = PostalCodes[Rnd.Next(PostalCodes.Count)]
                });

            return persons;
        }

        public static IEnumerable<PersonMedical> PersonMedicalData()
        {
            var persons = PersonData<PersonMedical>().ToList();
            for (var i = 0; i < persons.Count; i++)
            {
                var person = persons[i];
                person.MedicalState = MedicalEnumValues[i];
            }

            return persons;
        }

        public static IEnumerable<PersonMedical> PersonMedicalRandomData(int amount = 10000)
        {
            var persons = PersonRandomData<PersonMedical>(amount).ToList();
            foreach (var person in persons)
                person.MedicalState = (MedicalEnum) Rnd.Next(Enum.GetValues<MedicalEnum>().Length);

            return persons;
        }

        public static IEnumerable<PersonHobby> PersonHobbiesData()
        {
            var persons = PersonData<PersonHobby>().ToList();
            for (var i = 0; i < persons.Count; i++)
            {
                var person = persons[i];
                var hobbyEnumValue = HobbyEnumValues[i];
                person.Hobby = HobbyEnumValues[i];
            }

            return persons;
        }

        public static IEnumerable<PersonHobby> PersonHobbiesRandomData(int amount = 10000)
        {
            var persons = PersonRandomData<PersonHobby>(amount).ToList();
            foreach (var person in persons) person.Hobby = (HobbyEnum) Rnd.Next(Enum.GetValues<HobbyEnum>().Length);

            return persons;
        }

        public static IEnumerable<PersonProduct> PersonProductData()
        {
            var persons = PersonData<PersonProduct>().ToList();
            for (var i = 0; i < persons.Count; i++)
            {
                var person = persons[i];
                person.ProductGenre = ProductGenreEnumValues[i];
            }

            return persons;
        }

        public static IEnumerable<PersonProduct> PersonProductRandomData(int amount = 10000)
        {
            var persons = PersonRandomData<PersonProduct>(amount).ToList();
            foreach (var person in persons)
                person.ProductGenre = (ProductGenreEnum) Rnd.Next(Enum.GetValues<HobbyEnum>().Length);

            return persons;
        }
    }
}
using OnlineMarketingTools.Core.Interfaces;
using OnlineMarketingTools.DataExternal.Entities;
using OnlineMarketingTools.Server.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineMarketingTools.Core.Entities;

namespace OnlineMarketingTools.Server.Services
{
    public class CombiningLogic : ICombiningLogic
    {
        private readonly IExternalRepository<PersonHobby> hobbyContext;
        private readonly IExternalRepository<PersonMedical> medicalContext;
        private readonly IExternalRepository<PersonProduct> productContext;
        private readonly IPersonIntegratedRepository intergratedContext;

        public CombiningLogic
        (IExternalRepository<PersonHobby> hobbyContext,
            IExternalRepository<PersonMedical> medicalContext,
            IExternalRepository<PersonProduct> productContext,
            IPersonIntegratedRepository intergratedContext)
        {
            this.hobbyContext = hobbyContext;
            this.medicalContext = medicalContext;
            this.productContext = productContext;
            this.intergratedContext = intergratedContext;
        }

        public async Task GetAndCombine()
        {
            var hobbyList = await hobbyContext.GetAllAsync();
            var medicalList = await medicalContext.GetAllAsync();
            var productList = await productContext.GetAllAsync();

            var combined = new List<PersonIntegrated>();

            foreach (var person in hobbyList)
            {
                PersonIntegrated newPerson = new();
                newPerson.FirstName = person.FirstName;
                newPerson.LastName = person.LastName;
                newPerson.Hobby = person.Hobby.ToString();
                newPerson.Adress = person.Address;
                newPerson.MiddleName = person.MiddleName;
                newPerson.Country = person.Country;
                newPerson.Email = person.Email;
                newPerson.PhoneNumber = person.PhoneNumber;
                newPerson.PostCode = person.PostalCode;
                newPerson.MedicalState = medicalList
                    .First(p => p.FirstName == person.FirstName &&
                                p.LastName == person.LastName &&
                                p.PostalCode == person.PostalCode).MedicalState.ToString();
                newPerson.ProductGenre = productList
                    .First(p => p.FirstName == person.FirstName &&
                                p.LastName == person.LastName &&
                                p.PostalCode == person.PostalCode).ProductGenre.ToString();

                combined.Add(newPerson);
            }

            await intergratedContext.AddRangeAsync(combined);
        }
    }
}
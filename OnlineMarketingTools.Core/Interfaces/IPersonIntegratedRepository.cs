﻿using OnlineMarketingTools.Core.Entities;
using OnlineMarketingTools.Core.Entities.;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Core.Interfaces
{
	public interface IPersonIntegratedRepository : IExternalRepository<PersonIntegrated>
	{
        public Task<PersonIntegrated> GetByFirstNameLastNameAndPostCode(string firstName, string lastName, string postCode);
        public Task<PersonIntegrated> GetById(int id);
    }
}

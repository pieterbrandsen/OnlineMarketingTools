using Microsoft.AspNetCore.Mvc;
using OnlineMarketingTools.Core.Entities;
using OnlineMarketingTools.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Client.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonController : ControllerBase
	{
		private readonly IPersonIntegratedRepository _repository;

		public PersonController(IPersonIntegratedRepository personIntegratedRepository)
		{
			_repository = personIntegratedRepository;
		}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ICollection<PersonIntegrated> persons = await _repository.GetAll();
			if (persons.Count() is not 0)
				return Ok(persons);
			else
			{
				persons.Add(new PersonIntegrated { Id = 1, FirstName = "No Persons" });
				return Ok(persons);
				//return NoContent();
			}
		}
    }
}

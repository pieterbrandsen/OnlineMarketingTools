using Microsoft.AspNetCore.Mvc;
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
            var persons = await _repository.GetAll();
			if (persons.Count() is not 0)
				return Ok(persons);
			else
				return NoContent();
        }
    }
}

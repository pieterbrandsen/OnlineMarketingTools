﻿using Microsoft.EntityFrameworkCore;
using OnlineMarketingTools.Core.Entities;
using OnlineMarketingTools.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace OnlineMarketingTools.Database.Repositories
{
	public class PersonIntegratedRepositoy : IPersonIntegratedRepository
	{
		private readonly PersonIntegratedDbContext context;
		public PersonIntegratedRepositoy(PersonIntegratedDbContext context)
		{
			this.context = context;
		}

		//Todo

		/// <summary>
		/// Gets an IEnumerable<PersonHobby> of All entity's in this DB
		/// </summary>
		/// <returns>Task<IEnumerable<PersonHobby>></returns>
		public async Task<ICollection<PersonIntegrated>> GetAll()
		{
			return await context.PersonsIntegrated.ToListAsync();
		}

		/// <summary>
		/// Gets a list of people by fieldname
		/// </summary>
		/// <param name="fieldName"> The name of the field you want to search for </param>
		/// <returns>Task<IEnumerable<PersonHobby>></returns>
		public async Task<IEnumerable<PersonIntegrated>> GetIEnumerableByFieldNameAndValue(string value, string fieldName)
		{
			var result = context.PersonsIntegrated
			   .Where(string.Format("{0} == {1}", fieldName, value))
			   .AsEnumerable<PersonIntegrated>();

			return await Task.FromResult(result);
		}

		/// <summary>
		/// Gets a single person based on the following 3 fields
		/// </summary>
		/// <param name="firstName"></param>
		/// <param name="lastName"></param>
		/// <param name="postCode"></param>
		/// <returns>Task<PersonHobby></returns>
		public Task<PersonIntegrated> GetByFirstNameLastNameAndPostCode(string firstName, string lastName, string postCode)
		{
			var result = context.PersonsIntegrated
				.Where(p => p.FirstName == firstName &&
				p.LastName == lastName &&
				p.PostCode == postCode)
				.First();

			return Task.FromResult(result);
		}

		/// <summary>
		/// Gets a single person based on Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns>Task<PersonHobby></returns>
		public async Task<PersonIntegrated> GetById(int id)
		{
			var result = await context.PersonsIntegrated.FindAsync(id);

			return result;
		}

		/// <summary>
		/// Returns a bool weither adding succeeded or not.
		/// </summary>
		/// <param name="person">The PersonIntergrated object to add</param>
		/// <returns></returns>
		public async Task<bool> AddPerson(PersonIntegrated person)
		{
			if (!(GetByFirstNameLastNameAndPostCode(person.FirstName, person.LastName, person.PostCode) == null))
			{
				return false;
			}
			else
			{
				context.PersonsIntegrated.Add(person);
				await context.SaveChangesAsync();

				return true;
			}
		}

		/// <summary>
		/// Returns a bool weither updating succeeded or not.
		/// </summary>
		/// <param name="PersonToUpdate">The PersonIntergrated object to update</param>
		/// <returns></returns>
		public async Task<bool> UpdatePerson(PersonIntegrated PersonToUpdate)
		{
			if (!(GetByFirstNameLastNameAndPostCode(PersonToUpdate.FirstName, PersonToUpdate.LastName, PersonToUpdate.PostCode) == null))
			{
				return false;
			}
			else
			{
				context.Update(PersonToUpdate);
				await context.SaveChangesAsync();

				return true;
			}
		}

		public async Task<IEnumerable<string>> FieldNames()
		{
			var result = new List<string>();

			foreach (var entity in context.Model.GetEntityTypes())
			{
				foreach (var property in entity.GetProperties())
				{
					result.Add(property.Name);
				}
			}

			return await Task.FromResult(result);
		}

		Task<ICollection<PersonIntegrated>> IExternalRepository<PersonIntegrated>.GetICollectionByFieldNameAndValue(string value, string fieldName)
		{
			throw new System.NotImplementedException();
		}
	}
}

using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineMarketingTools.Core.Entities;
using System.Reflection;

namespace OnlineMarketingTools.Client.Components
{
	public class PersonTableComponent : ComponentBase
	{
		[Parameter]
		public ICollection<PersonIntegrated> Persons { get; set; }

		protected override void BuildRenderTree(RenderTreeBuilder builder)
		{
			PersonIntegratedBase personIntegratedBase = new();
			List<PropertyInfo> properties = personIntegratedBase.GetType()
																.GetRuntimeProperties()
																.ToList();
			List<PropertyInfo> derivedProperties = Persons.FirstOrDefault()
														  .GetType()
														  .GetProperties(BindingFlags.DeclaredOnly |
																		 BindingFlags.Public |
																		 BindingFlags.Instance)
														  .ToList();
			properties.AddRange(derivedProperties);

			int index = 0;

			base.BuildRenderTree(builder);
			builder.OpenElement(index, "table");
			builder.AddAttribute(index++, "class", "table table-striped small table-sm");
			builder.AddMarkupContent(index++, "<thead><tr>");
			foreach (var property in properties)
			{
				builder.OpenElement(index++, "th");
				builder.AddContent(index++, property.Name);
				builder.CloseComponent();
			}
			builder.AddMarkupContent(index++, "</thead></tr>");
			builder.OpenElement(index++, "tbody");
			foreach (var person in Persons)
			{
				builder.OpenElement(index++, "tr");
				foreach (var property in properties)
				{
					builder.OpenElement(index++, "td");
					builder.AddContent(index++, person.GetType().GetProperty(property.Name).GetValue(person, null));
					builder.CloseElement();
				}
				builder.CloseElement();
			}
			builder.CloseElement();
			builder.CloseElement();
		}
	}
}

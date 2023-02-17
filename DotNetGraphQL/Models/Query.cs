using DotNetGraphQL.Database;
using Microsoft.EntityFrameworkCore;

namespace DotNetGraphQL.Models
{
	public sealed class Query
	{
		[GraphQLName("find_contacts")]
		public async Task<ContactFindResult> GetContacts([Service] ContactContext context, ContactFindFilter? filter = null)
		{
			IQueryable<Contact> contacts = context.Contacts;
			
			if (filter != null)
			{
				contacts = contacts.Where(contact =>
					(!filter.Id.HasValue || contact.Id == filter.Id)
					&& (filter.Title == null || contact.Title == filter.Title)
					&& (filter.Forename == null || contact.Forename == filter.Forename)
					&& (filter.Surname == null || contact.Surname == filter.Surname)
				);
			}

			var docs = await contacts.ToListAsync();

			return new ContactFindResult
			{
				Success = true,
				Message = "Matching records.",
				Docs = docs
			};
		}
	}
}

using DotNetGraphQL.Database;

namespace DotNetGraphQL.Models
{
	public sealed class Mutation
	{
		[GraphQLName("insert_contact")]
		public async Task<ContactInsertResult> AddContact([Service] ContactContext context, ContactInsertInput contact)
		{
			var result = context.Contacts.Add(new Contact 
			{ 
				Title = contact.Title, 
				Forename = contact.Forename, 
				Surname = contact.Surname 
			});

			await context.SaveChangesAsync();

			return new ContactInsertResult {
				Success = result.IsKeySet,
				Message =  "1 record inserted." 
			};
		}
	}
}

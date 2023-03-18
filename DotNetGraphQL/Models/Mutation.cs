using DotNetGraphQL.Database;

namespace DotNetGraphQL.Models
{
	public sealed class Mutation
	{
		[GraphQLName("insert_contact")]
		public async Task<ContactInsertResult> AddContact([Service] ContactContext context, ContactInsertInput input)
		{
			var result = context.Contacts.Add(new Contact 
			{ 
				Title = input.Title, 
				Forename = input.Forename, 
				Surname = input.Surname 
			});

			await context.SaveChangesAsync();

			return new ContactInsertResult {
				Success = result.IsKeySet,
				Message =  "1 record inserted." 
			};
		}

		[GraphQLName("remove_contact")]
		public async Task<ContactRemoveResult> RemoveContact([Service] ContactContext context, ContactRemoveInput input)
		{
			var contacts = context.Contacts.Where(contact => input.Ids.Contains(contact.Id));

			context.Contacts.RemoveRange(contacts);

			var result = await context.SaveChangesAsync();

			return new ContactRemoveResult
			{
				Success = true,
				Message = $"{result} record(s) removed."
			};
		}
	}
}

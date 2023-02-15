using DotNetGraphQL.Database;
using Microsoft.EntityFrameworkCore;

namespace DotNetGraphQL.Models
{
    public sealed class Query
    {
        [GraphQLName("find_contacts")]
        public async Task<ContactFindResult> GetContacts([Service] ContactContext context)
        {
            var contacts = await context.Contacts.ToListAsync();

            return new ContactFindResult {
                Success = true,
                Message = "Matching records.",
                Docs = contacts
            };
		}		
    }
}

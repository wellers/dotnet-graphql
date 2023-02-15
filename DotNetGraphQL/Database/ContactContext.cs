using DotNetGraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetGraphQL.Database
{
	public class ContactContext : DbContext
	{
		public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }

		public DbSet<Contact> Contacts { get; set; }
	}
}

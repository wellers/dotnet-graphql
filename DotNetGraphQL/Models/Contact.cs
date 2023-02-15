namespace DotNetGraphQL.Models
{
	public sealed class Contact
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Forename { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
	}
}

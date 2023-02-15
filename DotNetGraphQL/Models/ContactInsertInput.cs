namespace DotNetGraphQL.Models
{
	public class ContactInsertInput
	{
		public string Title { get; set; } = string.Empty;
		public string Forename { get; set; } = string.Empty;
		public string Surname { get; set; } = string.Empty;
	}	
}

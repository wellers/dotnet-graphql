namespace DotNetGraphQL.Models
{	
	public class ContactFindResult
	{
		public bool Success { get; set; }
		public string Message { get; set; } = string.Empty;
		public List<Contact> Docs { get; set; } = new List<Contact>();
	}
}

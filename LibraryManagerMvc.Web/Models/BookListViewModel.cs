using LibraryManagerMvc.Data.Entities;
using System.ComponentModel;

namespace LibraryManagerMvc.Web.Models
{
	public class BookListViewModel
	{
		[DisplayName("Search")]
		public string SearchTerm { get; set; }

		public IEnumerable<Book> Books { get; set; }
	}
}

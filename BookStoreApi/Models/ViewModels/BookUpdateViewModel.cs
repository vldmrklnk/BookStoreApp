using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.Models.ViewModels
{
	public class BookUpdateViewModel : BookCreateViewModel
	{
		public string NewName { get; set; }
	}
}

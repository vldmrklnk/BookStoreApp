using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.Models.ViewModels
{
	public class BookUpdateViewModel : BookCreateViewModel
	{
		[RegularExpression("^[\\w ]+$", ErrorMessage = "Valid Charactors include (A-Z) (a-z) (' space -)")]
		public string NewName { get; set; }
	}
}

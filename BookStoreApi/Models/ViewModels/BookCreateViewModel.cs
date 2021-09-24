using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.Models.ViewModels
{
	public class BookCreateViewModel
	{
		public string Name { get; set; }

		public IFormFile Image { get; set; }
	}
}

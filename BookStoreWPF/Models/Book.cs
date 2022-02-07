using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.Models.DatabaseModels
{
	public class Book
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		public string Path { get; set; }
	}
}

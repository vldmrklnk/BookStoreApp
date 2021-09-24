using BookStoreApi.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.Models
{
	public class ApplicationDbcontext : DbContext
	{
		public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options)
			: base(options)
		{
		}

		public DbSet<Book> Books { get; set; }
	}
}

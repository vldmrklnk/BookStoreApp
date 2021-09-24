using BookStoreApi.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.Services.Contracts
{
	public interface IBooksService
	{
		public void Create(Book book);

		public List<Book> GetAll();

		public Book GetByName(string name);

		public void Update(string newName, Book book);

		public void Delete(string name);
	}
}

using BookStoreApi.Models;
using BookStoreApi.Models.DatabaseModels;
using BookStoreApi.Services.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.Services.Implementations
{
	public class BooksService : IBooksService
	{
		private readonly ApplicationDbcontext _context;
		private readonly IWebHostEnvironment _appEnvironment;
		public BooksService(ApplicationDbcontext context, IWebHostEnvironment appEnvironment)
		{
			_context = context;
			_appEnvironment = appEnvironment;
		}
		public void Create(Book book)
		{
			if (book.Image != null)
				book.Path = SaveImage(book.Image);

			_context.Books.Add(book);
			_context.SaveChanges();
		}

		public void Update(string newName, Book model)
		{
			var book = _context.Books
				.FirstOrDefault(x => x.Name == model.Name);

			if (newName != null)
				book.Name = newName;

			if (model.Image != null)
				DeleteImage(book.Path);
				book.Path = SaveImage(model.Image);

			_context.Update(book);
			_context.SaveChanges();
		}

		public void Delete(string name)
		{
			var book = _context.Books
				.FirstOrDefault(x => x.Name == name);

			if (book == null)
				throw new Exception("This book doesn't exist");

			DeleteImage(book.Path);

			_context.Remove(book);
			_context.SaveChanges();

		}

		public List<Book> GetAll()
		{
			var books = _context.Books.ToList();

			return books;
		}

		public Book GetByName(string name)
		{
			var book = _context.Books
				.FirstOrDefault(x => x.Name == name);

			if (book == null)
				throw new Exception("This book doesn't exist");

			return book;
		}

		private string GenerateImageName(string fileName)
		{
			string imageName = new String(Path.GetFileNameWithoutExtension(fileName).Take(10).ToArray()).Replace(' ', '-');
			imageName = imageName + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(fileName);

			return imageName;
		}

		private string SaveImage(IFormFile Image)
		{
			var generatedName = GenerateImageName(Image.FileName);

			string path = "/Files/" + generatedName;

			using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
			{
				Image.CopyTo(fileStream);
			}

			return path;
		}

		private void DeleteImage(string path)
		{
			var image = new FileInfo(_appEnvironment.WebRootPath+path);

			if(image.Exists)
			{
				image.Delete();
			}
			else
			{
				throw new Exception("This image doesn't exist");
			}
		}
	}
}

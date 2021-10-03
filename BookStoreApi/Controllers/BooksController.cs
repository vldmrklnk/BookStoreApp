using AutoMapper;
using BookStoreApi.Models.DatabaseModels;
using BookStoreApi.Models.ViewModels;
using BookStoreApi.Services.Contracts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.Controllers
{
	[Route("api/books")]
	[ApiController]
	public class BooksController : ControllerBase
	{
		private readonly IBooksService _booksService;
		private readonly IWebHostEnvironment _env;
		private readonly IMapper _mapper;

		public BooksController(IBooksService booksService, IMapper mapper, IWebHostEnvironment env)
		{
			_booksService = booksService;
			_mapper = mapper;
			_env = env;
		}

		[HttpPost]
		public IActionResult Post([FromForm] BookCreateViewModel model)
		{
			var book = _mapper.Map<BookCreateViewModel, Book>(model);

			_booksService.Create(book);

			return Ok();
		}

		[HttpGet]
		public IActionResult Get()
		{
			var books = _booksService.GetAll();

			var models = _mapper.Map(books, new List<BookViewModel>());

			foreach (var model in models)
			{
				model.Path = String.Format("{0}://{1}{2}{3}", Request.Scheme, Request.Host,Request.PathBase, model.Path);
			}

			return new JsonResult(models);
		}

		[HttpGet ("{name}")]
		public IActionResult Get(string name)
		{
			var book = _booksService.GetByName(name);

			var model = _mapper.Map<Book, BookViewModel>(book);

			model.Path = String.Format("{0}://{1}{2}{3}", Request.Scheme, Request.Host, Request.PathBase, model.Path);

			return new JsonResult(model);
		}

		[HttpPut]
		public IActionResult Put([FromForm] BookUpdateViewModel model)
		{
			var book = _mapper.Map<BookUpdateViewModel, Book>(model);

			_booksService.Update(model.NewName, book);

			return Ok();
		}

		[HttpDelete("{name}")]
		public IActionResult Delete(string name)
		{
			_booksService.Delete(name);

			return Ok();
		}
	}
}

using AutoMapper;
using BookStoreApi.Models.DatabaseModels;
using BookStoreApi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApi.Mapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<BookCreateViewModel, Book>();
			CreateMap<Book, BookViewModel>();
			CreateMap<BookUpdateViewModel, Book>();
		}
	}
}

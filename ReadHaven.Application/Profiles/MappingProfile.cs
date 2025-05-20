using AutoMapper;
using ReadHaven.Application.Features.Books.Commands.CreateBook;
using ReadHaven.Application.Features.Books.Queries;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, CreateBookCommand>().ReverseMap();
            CreateMap<Book, CreateBookDto>().ReverseMap();
            CreateMap<Book, BookListVm>().ReverseMap();
        }
    }
}

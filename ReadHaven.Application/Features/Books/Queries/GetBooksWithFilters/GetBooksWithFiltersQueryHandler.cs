using MediatR;
using ReadHaven.Application.Features.Books.Common;
using AutoMapper;
using System.Linq;
using ReadHaven.Application.Contracts.Persistence;
using System.Linq.Dynamic.Core;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Features.Books.Queries.GetBooksWithFilters
{
    internal class GetBooksWithFiltersQueryHandler : IRequestHandler<GetBooksWithFiltersQuery, PagedResult<BookDto>>
    {
        private readonly IAsyncRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public GetBooksWithFiltersQueryHandler(IAsyncRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BookDto>> Handle(GetBooksWithFiltersQuery request, CancellationToken cancellationToken)
        {
            var query = _bookRepository.Query();

            if (!string.IsNullOrWhiteSpace(request.Parameters.Searches)) 
            {
                var searchText = request.Parameters.Searches.ToLower();

                query = query.Where(b =>
                    b.Title.ToLower().Contains(searchText) ||
                    b.Genre.ToLower().Contains(searchText) ||
                    b.Price.ToString().Contains(searchText)
                );
            }

            var totalCount = await Task.FromResult(query.Count()); // need to async


            if (request.Parameters.Sorts != null && request.Parameters.Sorts.Any())
            {
                var sorting = string.Join(",", request.Parameters.Sorts.Select(s =>
                    s.PropertyName + (s.IsDescending ? " descending" : " ascending")));

                query = query.OrderBy(sorting);
            }
            else
            {
                query = query.OrderBy("Title");
            }

            var skip = (request.Parameters.PageNumber - 1) * request.Parameters.PageSize;
            var books = query.Skip(skip).Take(request.Parameters.PageSize).ToList(); // need to async   

            var bookDtos = _mapper.Map<List<BookDto>>(books);

            return new PagedResult<BookDto>
            {
                Items = bookDtos,
                TotalCount = totalCount,
                PageNumber = request.Parameters.PageNumber,
                PageSize = request.Parameters.PageSize
            };
        }
    }
}

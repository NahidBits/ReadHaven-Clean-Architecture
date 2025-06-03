using MediatR;
using ReadHaven.Application.Features.Books.Common;
using System.Collections.Generic;

namespace ReadHaven.Application.Features.Books.Queries.GetBooksWithFilters
{
    public class GetBooksWithFiltersQuery : IRequest<PagedResult<BookDto>>
    {
        public BookQueryParameters Parameters { get; }

        public GetBooksWithFiltersQuery(BookQueryParameters parameters)
        {
            Parameters = parameters;
        }
    }
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}

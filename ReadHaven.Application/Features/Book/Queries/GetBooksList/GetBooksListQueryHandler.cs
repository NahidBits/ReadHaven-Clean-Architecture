using AutoMapper;
using MediatR;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Features.Books.Queries.GetBooksList
{
    public class GetBooksListQueryHandler : IRequestHandler<GetBooksListQuery, List<BookListVm>>
    {
        private readonly IAsyncRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public GetBooksListQueryHandler(IMapper mapper, IAsyncRepository<Book> bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<List<BookListVm>> Handle(GetBooksListQuery request, CancellationToken cancellationToken)
        {
            var allBooks = (await _bookRepository.ListAllAsync()).OrderBy(x => x.Title);  // Changed from Name to Title
            return _mapper.Map<List<BookListVm>>(allBooks);
        }
    }
}

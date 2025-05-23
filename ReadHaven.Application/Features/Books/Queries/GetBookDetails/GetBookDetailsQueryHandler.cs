using AutoMapper;
using MediatR;
using ReadHaven.Application.Contracts.Persistence;
using ReadHaven.Application.Exceptions;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Application.Features.Books.Queries.GetBookDetails
{
    public class GetBookDetailsQueryHandler
        : IRequestHandler<GetBookDetailsQuery, BookDetailsVm>
    {
        private readonly IAsyncRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public GetBookDetailsQueryHandler(
            IAsyncRepository<Book> bookRepository,
            IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDetailsVm> Handle(
            GetBookDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByIdAsync(request.BookId);
            if (book == null)
                throw new NotFoundException(nameof(Book), request.BookId);

            return _mapper.Map<BookDetailsVm>(book);
        }
    }
}

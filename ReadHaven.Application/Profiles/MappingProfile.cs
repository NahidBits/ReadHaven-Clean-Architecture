using AutoMapper;
using ReadHaven.Application.Features.Books.Commands.CreateBook;
using ReadHaven.Application.Features.Books.Queries.GetBookDetails;
using ReadHaven.Application.Features.Books.Queries.GetBooksList;
using ReadHaven.Application.Features.Books.Queries.GetBooksWithFilters;
using ReadHaven.Application.Features.BooksRatingReview.Commands.CreateRatingReview;
using ReadHaven.Application.Features.BooksRatingReview.Queries.GetRatingReviewByBook;
using ReadHaven.Application.Features.Cartitems.Commands.CreateCartItem;
using ReadHaven.Application.Features.CartItems.Queries.GetMyCartItemList;
using ReadHaven.Application.Features.Orders.Commands.CreateOrder;
using ReadHaven.Application.Features.Orders.Queries.GetMyOrderList;
using ReadHaven.Application.Features.Orders.Queries.GetOrderList;
using ReadHaven.Application.Features.PaymentTransactions.Commands.CreatePaymentTransaction;
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
            CreateMap<Book, BookDetailsVm>().ReverseMap();
            CreateMap<BookRatingReview, CreateRatingReviewCommand>().ReverseMap();
            CreateMap<BookRatingReview, CreateRatingReviewDto>().ReverseMap();
            CreateMap<BookRatingReview, RatingReviewVm>().ReverseMap();
            CreateMap<CartItem, CreateCartItemDto>().ReverseMap();
            CreateMap<CartItem, CartItemListVm>().ReverseMap();
            CreateMap<Order, CreateOrderCommand>().ReverseMap();
            CreateMap<Order, CreateOrderDto>().ReverseMap();
            CreateMap<Order, OrderListVm>().ReverseMap();
            CreateMap<Order, MyOrderListVm>().ReverseMap();
            CreateMap<PaymentTransaction, CreatePaymentTransactionCommand>().ReverseMap();
            CreateMap<PaymentTransaction, CreatePaymentTransactionDto>().ReverseMap();
            CreateMap<Book,BookDto>().ReverseMap();
        }
    }
}

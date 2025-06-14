﻿namespace ReadHaven.Application.Features.Books.Commands.CreateBook;

public class CreateBookDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? ImagePath { get; set; } = null;
}

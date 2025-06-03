namespace ReadHaven.Application.Features.Books.Common
{
    public class BookQueryParameters
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public List<SortDescriptor> Sorts { get; set; } = new();
        public string Searches { get; set; } = string.Empty;
    }

    public class SortDescriptor
    {
        public string PropertyName { get; set; } = string.Empty;
        public bool IsDescending { get; set; } = false;
    }
   
}

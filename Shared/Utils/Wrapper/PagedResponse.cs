
namespace Shared.Utils.Wrapper
{
    public class PagedResponse<T> : IPagedResponse<T>
    {
        public T Data { get; init; }
        public string? Messages { get; set; }
        public bool Succeeded { get; set; }
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public int TotalRecords { get; init; }
        public int TotalPages => (int)Math.Ceiling((double)TotalRecords / PageSize);
        public string? SortColumn { get; init; }
        public string? SortDirection { get; init; }
        public IDictionary<string, string>? Filters { get; init; }

        public PagedResponse(T data, int pageNumber, int pageSize, int totalRecords)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            Succeeded = true;
        }
    }
}

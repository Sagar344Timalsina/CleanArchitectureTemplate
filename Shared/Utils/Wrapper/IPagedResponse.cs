using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Utils.Wrapper
{
    public interface IPagedResponse<out T>:IResponse<T>
    {
        int PageNumber { get; }
        int PageSize { get; }
        int TotalRecords { get; }
        int TotalPages { get; }
        string? SortColumn{ get; }
        string? SortDirection{ get; }
        IDictionary<string, string>? Filters { get; }
    }
}

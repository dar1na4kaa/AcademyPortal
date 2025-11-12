using Shared.Models.Contracts;

namespace Shared.Models;

public class QueryParameters<TFilter, TSorting> where TSorting : SortingParameters where TFilter : FilterParameters
{
    public TSorting? SortingParameters { get; set; }
    
    public TFilter? FilterParameters { get; set; }
    
    public PagingParameters? PagingParameters { get; set; }
}
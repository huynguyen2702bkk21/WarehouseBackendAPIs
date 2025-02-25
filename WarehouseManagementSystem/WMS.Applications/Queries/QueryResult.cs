namespace WMS.Application.Queries
{
    public class QueryResult <T> 
    {
        public IEnumerable<T> Results { get; set; }
        public int TotalItems { get; set; }

        public QueryResult(IEnumerable<T> results, int totalItems)
        {
            Results = results;
            TotalItems = totalItems;
        }
    }
}

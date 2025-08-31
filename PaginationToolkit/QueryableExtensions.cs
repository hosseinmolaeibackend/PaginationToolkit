
namespace PaginationToolkit
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedList<T>> ToPaginatedListAsync<T>(
            this IQueryable<T> source,
            int pageNumber,
            int pageSize)
        {
            return await PaginatedList<T>.CreateAsync(source, pageNumber, pageSize);
        }

        public static IQueryable<T> Paginate<T>(
            this IQueryable<T> source,
            int pageNumber,
            int pageSize)
        {
            return source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}

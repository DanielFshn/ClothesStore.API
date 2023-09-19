
using System.Linq;

namespace ClothesStrore.Application.Helpers;

public static class IQueryableExtensions
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, PaginationDTO pagination)
    {
        int page = pagination.Page < 1 ? 1 : pagination.Page + 1;
        int recordsPerPage = pagination.RecordsPerPage;

        return queryable
            .Skip((page - 1) * recordsPerPage)
            .Take(recordsPerPage);
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ClothesStrore.Application.Helpers;

public static class HttpContextExtensions
{
    public async static Task InsertPagiationHeader<T>(this HttpContext httpContext, IQueryable<T> queryable)
    {
        if (httpContext == null)
            throw new ArgumentNullException(nameof(httpContext));
        double count = await queryable.CountAsync();
        httpContext.Response.Headers.Add("totalAmountOfRecores", count.ToString());
    }
}

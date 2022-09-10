using System.Linq.Expressions;

namespace FinStarTestTask.Infrastructure.Extensions;

public static class IOrderedQueryableExtensions
{
    public static IOrderedQueryable<T>
        OrderBy<T>(this IQueryable<T> source, string propertyName, bool ascending = true)
    {
        return ascending
            ? source.OrderBy(ToLambda<T>(propertyName))
            : source.OrderByDescending(ToLambda<T>(propertyName));
    }

    private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
    {
        var parameter = Expression.Parameter(typeof(T));
        var property = Expression.Property(parameter, propertyName);
        var propAsObject = Expression.Convert(property, typeof(object));

        return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
    }
}
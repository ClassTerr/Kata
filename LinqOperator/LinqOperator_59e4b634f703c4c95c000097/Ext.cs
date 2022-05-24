using System;
using System.Collections.Generic;

namespace LinqOperator_59e4b634f703c4c95c000097;

public static class Ext
{
    public static IEnumerable<TResult> SelectConsecutive<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, TSource, TResult> selector)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (selector == null) throw new ArgumentNullException(nameof(selector));

        return SelectConsecutiveIterator(source, selector);
    }

    private static IEnumerable<TResult> SelectConsecutiveIterator<TSource, TResult>(
        this IEnumerable<TSource> source,
        Func<TSource, TSource, TResult> selector)
    {
        using var enumerator = source.GetEnumerator();
        enumerator.MoveNext();
        var previous = enumerator.Current;

        while (enumerator.MoveNext())
        {
            var current = enumerator.Current;
            yield return selector(previous, current);
            previous = current;
        }
    }
}

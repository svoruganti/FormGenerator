using System;
using System.Collections.Generic;
using System.Linq;

namespace FormGenerator.Service
{
    public static class EnumerableExtensions
    {
        public static string ToQueryString(this IEnumerable<KeyValuePair<string, string>> enumerator)
        {
            var queryString = String.Empty;

            if (!enumerator.Any())
                return queryString;

            foreach (var keyValuePair in enumerator)
            {
                if (queryString == String.Empty)
                    queryString = $"{keyValuePair.Key}={keyValuePair.Value}";
                else
                    queryString += $"&{keyValuePair.Key}={keyValuePair.Value}";
            }
            return queryString;
        }
    }
}
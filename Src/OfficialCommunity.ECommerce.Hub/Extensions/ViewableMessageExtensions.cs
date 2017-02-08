using System;
using System.Collections.Generic;
using System.Linq;
using OfficialCommunity.ECommerce.Hub.Domains.Viewable;

namespace OfficialCommunity.ECommerce.Hub.Extensions
{
    public static class ViewableMessageExtensions
    {
        public static IList<ViewableMessage> ToViewableMessages(this string document)
        {
            var result = new List<ViewableMessage>();

            if (string.IsNullOrWhiteSpace(document))
                return result;

            var lines = document.Split(new[] {"\r\n", "\n"}, StringSplitOptions.None).ToList();
            if (!lines.Any()) return result;
            var index = 0;
            result.AddRange(lines.Select(x => new ViewableMessage
            {
                Id = index++,
                Message = x
            }));
            return result;
        }
    }
}

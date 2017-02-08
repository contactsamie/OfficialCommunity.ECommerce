using System;
using System.Linq;
using OfficialCommunity.ECommerce.Hub.Domains.Infrastructure;

namespace OfficialCommunity.ECommerce.Hub.Extensions
{
    public static class IBaseEntityExtensions
    {
        public static void Timestamp(this IBaseEntity entity, string identity = null)
        {
            var now = DateTime.UtcNow;

            if (!entity.CreatedUtc.HasValue)
            {
                entity.CreatedBy = identity;
                entity.CreatedUtc = now;
            }
        }

        public static TOrig UpdateProperties<TOrig, TDto>(this TOrig original, TDto dto)
        {
            var origProps = typeof(TOrig).GetProperties();
            var dtoProps = typeof(TDto).GetProperties();

            foreach (var dtoProp in dtoProps)
            {
                origProps
                    .Single(origProp => origProp.Name == dtoProp.Name)
                    .SetMethod.Invoke(original, new[]
                        {
                            dtoProp.GetMethod.Invoke(dto, null)
                        });
            }

            return original;
        }
    }
}

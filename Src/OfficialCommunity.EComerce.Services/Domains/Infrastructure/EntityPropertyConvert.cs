using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;

namespace OfficialCommunity.ECommerce.Services.Domains.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property)]
    public class EntityPropertyConverterAttribute : Attribute
    {
        public Type ConvertToType;

        public EntityPropertyConverterAttribute()
        {

        }
        public EntityPropertyConverterAttribute(Type convertToType)
        {
            ConvertToType = convertToType;
        }
    }

    public static class EntityPropertyConvert
    {
        public static void Serialize<TEntity>(TEntity entity, IDictionary<string, EntityProperty> results)
        {
            foreach (var property in typeof(TEntity).GetProperties())
            {
                var attributedProperty = (EntityPropertyConverterAttribute)Attribute.GetCustomAttribute(property, typeof(EntityPropertyConverterAttribute));
                if (attributedProperty == null) continue;
                var entityProperty = entity.GetType().GetProperty(property.Name)?.GetValue(entity);
                results.Add(property.Name, new EntityProperty(JsonConvert.SerializeObject(entityProperty)));
            }
        }

        public static void DeSerialize<TEntity>(TEntity entity, IDictionary<string, EntityProperty> properties)
        {
            foreach (var property in typeof(TEntity).GetProperties())
            {
                var attributedProperty = (EntityPropertyConverterAttribute)Attribute.GetCustomAttribute(property, typeof(EntityPropertyConverterAttribute));
                if (attributedProperty == null) continue;
                var resultType = attributedProperty.ConvertToType ?? property.GetType();
                if (!properties.ContainsKey(property.Name)) continue;
                var objectValue = JsonConvert.DeserializeObject(properties[property.Name].StringValue, resultType);
                entity.GetType().GetProperty(property.Name)?.SetValue(entity, objectValue);
            }
        }
    }
}

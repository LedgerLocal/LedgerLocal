using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Common.Core
{
    public static class DynamicToStatic
    {
        public static T ToStatic<T>(object dynamicObject)
        {
            var entity = Activator.CreateInstance<T>();

            var properties = dynamicObject.GetType().GetProperties();

            if (properties == null || properties.Length == 0)
                return entity;

            foreach (var entry in properties)
            {
                var propertyInfo = entity.GetType().GetTypeInfo().GetProperty(entry.Name);
                if (propertyInfo != null)
                    propertyInfo.SetValue(entity, entry.GetValue(dynamicObject, null), null);
            }
            return entity;
        }
    }
}

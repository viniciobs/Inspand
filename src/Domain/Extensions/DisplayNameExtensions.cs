using System.ComponentModel;

namespace Domain.Extensions
{
    public static class DisplayNameExtensions
    {
        public static string GetDisplayName(this object obj, string propertyName) 
        {
            var property = obj
                .GetType()
                .GetProperty(propertyName);
            
            if (property is null)
            {
                return null;
            }

            var attribute = property
                .GetCustomAttributes(typeof(DisplayNameAttribute), true)
                .Cast<DisplayNameAttribute>()
                .SingleOrDefault();
            
            if (attribute is null)
            {
                return null;
            }

            return attribute.DisplayName;
        }
    }
}

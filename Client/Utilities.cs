using System.ComponentModel.DataAnnotations;

namespace Graphene.Front.Client
{
    public static class Utilities
    {
        public static bool IsRequired(this object property, string propertyName)
        {
            return property.GetType().GetProperty(propertyName)?.GetCustomAttributes(false).Any(attr => attr is RequiredAttribute) ?? false;
        }
    }
}
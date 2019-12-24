using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Tests.Unit
{
    internal static class ReflectionExtensions
    {        
        public static void SetPropertyNoSetter(this object obj, string propertyName, [AllowNull]object value)
        {
            if (string.IsNullOrWhiteSpace(propertyName))
                throw new System.ArgumentException("message", nameof(propertyName));

            var type = obj.GetType();
            var field = type.GetField($"<{propertyName}>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic);

            if (field is null)
                throw new NullReferenceException("Unable to find backing field for property " + propertyName);

            field.SetValue(obj, value);
        }
    }
}
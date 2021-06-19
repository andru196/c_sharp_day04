using System;
using System.Reflection;

namespace d04_ex03
{
    public class TypeFactory
    {
        public static T CreateWithConstructor<T>() where T : class
        {
            var type = typeof(T) as Type;
            var constructor = type.GetConstructor(Array.Empty<Type>());
            T entity = null;
            if (constructor != null)
                entity = constructor.Invoke(Array.Empty<object>()) as T;
            return entity;
        }

        public static T CreateWithActivator<T>() where T : class
        {
            try
            {
                return Activator.CreateInstance(typeof(T)) as T;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static T CreateWithParameters<T>(params object[] parameters) where T : class
        {
            try
            {
                return Activator.CreateInstance(typeof(T), parameters) as T;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
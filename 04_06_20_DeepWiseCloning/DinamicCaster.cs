using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace _04_06_20_DeepWiseCloning
{
    public static class DinamicCaster
    {
        private static Func<object, object> MakeCastDelegate(Type from, Type to)
        {
            var p = Expression.Parameter(typeof(object)); //do not inline
            return Expression.Lambda<Func<object, object>>(
                Expression.Convert(Expression.ConvertChecked(Expression.Convert(p, from), to), typeof(object)),
                p).Compile();
        }

        private static readonly Dictionary<Tuple<Type, Type>, Func<object, object>> CastCache
        = new Dictionary<Tuple<Type, Type>, Func<object, object>>();

        public static Func<object, object> GetCastDelegate(Type from, Type to)
        {
            lock (CastCache)
            {
                var key = new Tuple<Type, Type>(from, to);
                Func<object, object> cast_delegate;
                if (!CastCache.TryGetValue(key, out cast_delegate))
                {
                    cast_delegate = MakeCastDelegate(from, to);
                    CastCache.Add(key, cast_delegate);
                }
                return cast_delegate;
            }
        }

        public static object Cast(Type t, object o)
        {
            return GetCastDelegate(o.GetType(), t).Invoke(o);
        }
    }
}

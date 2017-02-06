using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using OfficialCommunity.Necropolis.Domains.Services;
using OfficialCommunity.Necropolis.Exceptions;

namespace OfficialCommunity.Necropolis.Extensions
{
    public static class CacheExtensions
    {
        public static async Task<T> AcquireAsync<T>(this ICacheManager cacheManager
                                                        , string key
                                                        , Expression<Func<Task<T>>> acquire)
                        where T : class
        {
            return await AcquireAsync(cacheManager, key, 60, acquire);
        }

        public static async Task<T> AcquireAsync<T>(this ICacheManager cacheManager
                                                        , string key
                                                        , int cacheTimeInSeconds
                                                        , Expression<Func<Task<T>>> acquire)
            where T : class
        {
            var cached = await cacheManager.GetAsync<T>(key);

            if (cached.HasError)
                throw new ContextException($"Unable to Get Async for Key '{key}' "
                    , new
                    {
                        Key = key,
                        cached.StandardError.Errors
                    });

            if (cached.Response != null)
                return cached.Response;

            MethodInfo method;
            object instance;
            var arguments = new object[]
            {

            };

            ParseExpression(acquire, out method, out instance);

            var result = await ((Task<T>)method.Invoke(instance, arguments)).ConfigureAwait(false);

            if (cacheTimeInSeconds > 0)
                await cacheManager.SetAsync(key, result, cacheTimeInSeconds);

            return result;
        }

        public static async Task<T> AcquireAsync<T, TP1>(this ICacheManager cacheManager
                                                    , string key
                                                    , int cacheTimeInSeconds
                                                    , TP1 p1
                                                    , Expression<Func<TP1, Task<T>>> acquire)
            where T : class
        {
            var cached = await cacheManager.GetAsync<T>(key);

            if (cached.HasError)
                throw new ContextException($"Unable to Get Async for Key '{key}' "
                    , new
                    {
                        Key = key,
                        cached.StandardError.Errors
                    });

            if (cached.Response != null)
                return cached.Response;

            MethodInfo method;
            object instance;
            var arguments = new object[]
            {
                p1
            };

            ParseExpression(acquire, out method, out instance);

            var result = await ((Task<T>)method.Invoke(instance, arguments)).ConfigureAwait(false);

            if (cacheTimeInSeconds > 0)
                await cacheManager.SetAsync(key, result, cacheTimeInSeconds);

            return result;
        }

        public static async Task<T> AcquireAsync<T, TP1, TP2>(this ICacheManager cacheManager
                                                                , string key
                                                                , int cacheTimeInSeconds
                                                                , TP1 p1
                                                                , TP2 p2
                                                                , Expression<Func<TP1, TP2, Task<T>>> acquire)
            where T : class
        {
            var cached = await cacheManager.GetAsync<T>(key);

            if (cached.HasError)
                throw new ContextException($"Unable to Get Async for Key '{key}' "
                    , new
                    {
                        Key = key,
                        cached.StandardError.Errors
                    });

            if (cached.Response != null)
                return cached.Response;

            MethodInfo method;
            object instance;
            var arguments = new object[]
            {
                p1,
                p2
            };

            ParseExpression(acquire, out method, out instance);

            var result = await ((Task<T>)method.Invoke(instance, arguments)).ConfigureAwait(false);

            if (cacheTimeInSeconds > 0)
                await cacheManager.SetAsync(key, result, cacheTimeInSeconds);

            return result;
        }


        public static async Task<T> AcquireAsync<T, TP1, TP2, TP3>(this ICacheManager cacheManager
                                                                , string key
                                                                , int cacheTimeInSeconds
                                                                , TP1 p1
                                                                , TP2 p2
                                                                , TP3 p3
                                                                , Expression<Func<TP1, TP2, TP3, Task<T>>> acquire)
            where T : class
        {
            var cached = await cacheManager.GetAsync<T>(key);

            if (cached.HasError)
                throw new ContextException($"Unable to Get Async for Key '{key}' "
                    , new
                    {
                        Key = key,
                        cached.StandardError.Errors
                    });

            if (cached.Response != null)
                return cached.Response;

            MethodInfo method;
            object instance;
            var arguments = new object[]
            {
                p1,
                p2,
                p3
            };

            ParseExpression(acquire, out method, out instance);

            var result = await ((Task<T>)method.Invoke(instance, arguments)).ConfigureAwait(false);

            if (cacheTimeInSeconds > 0)
                await cacheManager.SetAsync(key, result, cacheTimeInSeconds);

            return result;
        }

        private static void ParseExpression(LambdaExpression expression, out MethodInfo method, out object instance)
        {
            var methodCall = expression.Body as MethodCallExpression;

            method = methodCall.Method;

            instance = methodCall.Object != null ? GetValue(methodCall.Object) : null;
        }

        private static object GetValue(Expression expression)
        {
            switch (expression.NodeType)
            {
                // we special-case constant and member access because these handle the majority of common cases.
                // For example, passing a local variable as an argument translates to a field reference on the closure
                // object in expression land
                case ExpressionType.Constant:
                    return ((ConstantExpression)expression).Value;
                case ExpressionType.MemberAccess:
                    var memberExpression = (MemberExpression)expression;
                    var instance = memberExpression.Expression != null ? GetValue(memberExpression.Expression) : null;
                    var field = memberExpression.Member as FieldInfo;
                    return field != null
                        ? field.GetValue(instance)
                        : ((PropertyInfo)memberExpression.Member).GetValue(instance);
                default:
                    // this should always work if the expression CAN be evaluated (it can't if it references unbound parameters, for example)
                    // however, compilation is slow so the cases above provide valuable performance
                    var lambda = Expression.Lambda<Func<object>>(Expression.Convert(expression, typeof(object)));
                    return lambda.Compile()();
            }
        }
    }
}

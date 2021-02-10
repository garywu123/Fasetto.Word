#region License

// author:         吴经纬
// created:        23:00
// description:

#endregion

using System;
using System.Linq.Expressions;
using System.Reflection;

// ReSharper disable CheckNamespace
namespace Fasetto.Word.Core
{
    /// <summary>
    ///     A helper for expressions
    /// </summary>
    public static class ExpressionHelper
    {
        /// <summary>
        ///     Compiles an expression and gets the functions return value
        /// </summary>
        /// <typeparam name="T"> The type of return value</typeparam> 
        /// <param name="lambdaExpression"> The expression to compile </param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambdaExpression)
        {
            return lambdaExpression.Compile().Invoke();
        }

        /// <summary>
        ///     Set the underlying properties value to the given value,
        ///     from an expression that contains the property
        /// </summary>
        /// <typeparam name="T">The type of value to set</typeparam>
        /// <param name="lambda">The expression</param>
        /// <param name="value">The value to set the property to</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
            // Converts a lambda () => some.Property, to some.Property

            // Get the property information
            if (!(lambda.Body is MemberExpression expression)) return;

            var propertyInfo = (PropertyInfo) expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile()
                .DynamicInvoke();

            // Set the property value
            propertyInfo.SetValue(target, value);
        }
    }
}
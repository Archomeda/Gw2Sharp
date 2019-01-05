using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace Gw2Sharp.Tests.Helpers
{
    public static class AssertArguments
    {
        public static void ThrowsWhenNull(Expression<Action> expression, params bool[] paramsNull)
        {
            // Original: https://www.thomaslevesque.com/2014/11/02/easy-unit-testing-of-null-argument-validation/

            MemberInfo callMethod = null;
            ParameterInfo[] callParams = null;
            IReadOnlyCollection<Expression> callArgs = null;
            Expression callObj = null;
            switch (expression.Body.NodeType)
            {
                case ExpressionType.Call:
                    callMethod = ((MethodCallExpression)expression.Body).Method;
                    callParams = ((MethodCallExpression)expression.Body).Method.GetParameters();
                    callArgs = ((MethodCallExpression)expression.Body).Arguments;
                    callObj = ((MethodCallExpression)expression.Body).Object;
                    break;
                case ExpressionType.New:
                    callMethod = ((NewExpression)expression.Body).Constructor;
                    callParams = ((NewExpression)expression.Body).Constructor.GetParameters();
                    callArgs = ((NewExpression)expression.Body).Arguments;
                    break;
                default:
                    throw new ArgumentException("Expression body is not a method or constructor call", nameof(expression));
            }

            for (int i = 0; i < paramsNull.Length && i < callArgs.Count; i++)
            {
                if (!paramsNull[i])
                    continue;

                var args = callArgs.ToArray();
                args[i] = Expression.Constant(null, callParams[i].ParameterType);
                Expression callExpr = null;
                switch (expression.Body.NodeType)
                {
                    case ExpressionType.Call:
                        callExpr = Expression.Call(callObj, callMethod as MethodInfo, args);
                        break;
                    case ExpressionType.New:
                        callExpr = Expression.New(callMethod as ConstructorInfo, args);
                        break;
                }
                var action = Expression.Lambda<Action>(callExpr).Compile();
                Assert.Throws<ArgumentNullException>(callParams[i].Name, action);
            }
        }

        public static Task ThrowsWhenNullAsync(Expression<Func<Task>> expression, params bool[] paramsNull)
        {
            // Original: https://www.thomaslevesque.com/2014/11/02/easy-unit-testing-of-null-argument-validation/

            MemberInfo callMethod = null;
            ParameterInfo[] callParams = null;
            IReadOnlyCollection<Expression> callArgs = null;
            Expression callObj = null;
            switch (expression.Body.NodeType)
            {
                case ExpressionType.Call:
                    callMethod = ((MethodCallExpression)expression.Body).Method;
                    callParams = ((MethodCallExpression)expression.Body).Method.GetParameters();
                    callArgs = ((MethodCallExpression)expression.Body).Arguments;
                    callObj = ((MethodCallExpression)expression.Body).Object;
                    break;
                case ExpressionType.New:
                    callMethod = ((NewExpression)expression.Body).Constructor;
                    callParams = ((NewExpression)expression.Body).Constructor.GetParameters();
                    callArgs = ((NewExpression)expression.Body).Arguments;
                    break;
                default:
                    throw new ArgumentException("Expression body is not a method or constructor call", nameof(expression));
            }

            var tasks = new List<Task>();
            for (int i = 0; i < paramsNull.Length && i < callArgs.Count; i++)
            {
                if (!paramsNull[i])
                    continue;

                var args = callArgs.ToArray();
                args[i] = Expression.Constant(null, callParams[i].ParameterType);
                Expression callExpr = null;
                switch (expression.Body.NodeType)
                {
                    case ExpressionType.Call:
                        callExpr = Expression.Call(callObj, callMethod as MethodInfo, args);
                        break;
                    case ExpressionType.New:
                        callExpr = Expression.New(callMethod as ConstructorInfo, args);
                        break;
                }
                var action = Expression.Lambda<Func<Task>>(callExpr).Compile();
                tasks.Add(Assert.ThrowsAsync<ArgumentNullException>(callParams[i].Name, action));
            }
            return Task.WhenAll(tasks);
        }

        public static void ThrowsWhenNullConstructor(Type type, Type[] paramTypes, object[] callArgs, bool[] paramsNull)
        {
            var constructorInfo = type.GetConstructor(paramTypes);
            if (constructorInfo == null)
                throw new InvalidOperationException($"No appropriate constructor found with parameters: {string.Join(", ", paramTypes.Select(p => p.FullName))}");

            for (int i = 0; i < paramsNull.Length && i < callArgs.Length && i < paramTypes.Length; i++)
            {
                if (!paramsNull[i])
                    continue;

                object[] args = callArgs.ToArray();
                args[i] = null;
                Assert.Throws<ArgumentNullException>(constructorInfo.GetParameters()[i].Name, () =>
                {
                    try
                    {
                        Activator.CreateInstance(type, args);
                    }
                    catch (TargetInvocationException ex)
                    {
                        throw ex.InnerException;
                    }
                });
            }
        }
    }
}

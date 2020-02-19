﻿using System;
using System.Linq.Expressions;
using System.Reflection;

namespace TableBuilder.Utils
{
    public static class ExpressionExtensions
    {
        public static PropertyInfo GetAccessedMemberInfo<T>(this Expression<T> expression)
        {
            MemberExpression? memberExpression = null;

            if (expression.Body.NodeType == ExpressionType.Convert)
            {
                memberExpression = ((UnaryExpression)expression.Body).Operand as MemberExpression;
            }
            else if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpression = expression.Body as MemberExpression;
            }

            if (memberExpression == null)
            {
                throw new ArgumentException("Not a member access", "expression");
            }

            return memberExpression.Member as PropertyInfo ?? throw new Exception();
        }
    }
}
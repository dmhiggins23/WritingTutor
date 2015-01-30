using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WritingTutor.Web.Domain
{
    public static class GetPropertyName
    {
        public static string GetMemberName<TYPE, PROP>(Expression<Func<TYPE, PROP>> expression) {
            MemberExpression memberExpression = null;
            if (expression.Body.NodeType == ExpressionType.Convert) {
                var body = (UnaryExpression)expression.Body;
                memberExpression = body.Operand as MemberExpression;
            }
            else if (expression.Body.NodeType == ExpressionType.MemberAccess) {
                memberExpression = expression.Body as MemberExpression;
            }
            if (memberExpression == null) {
                throw new ApplicationException("This is not a member expression");
            }
            return memberExpression.Member.Name;
        }

        public static P GetValue<T, P>(T obj, Expression<Func<T, P>> exp) {
            return exp.Compile().Invoke(obj);
        }

    }
}
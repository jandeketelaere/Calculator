using Domain.Expressions;

namespace Domain.Visitors
{
    public abstract class ExpressionVisitor<T> : IExpressionVisitor<T>
    {
        public T Visit(Expression expression)
        {
            return expression.Accept(this);
        }

        public abstract T Visit(ConstantExpression expression);
        public abstract T Visit(BinaryExpression expression);
        public abstract T Visit(UnaryExpression expression);
    }
}
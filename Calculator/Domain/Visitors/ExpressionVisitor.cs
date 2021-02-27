using Domain.Expressions;

namespace Domain.Visitors
{
    public abstract class ExpressionVisitor : IExpressionVisitor
    {
        public void Visit(Expression expression)
        {
            expression.Accept(this);
        }

        public abstract void Visit(ConstantExpression expression);

        public abstract void Visit(BinaryExpression expression);
    }
}
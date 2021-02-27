using Domain.Expressions;

namespace Domain.Visitors
{
    public interface IExpressionVisitor
    {
        void Visit(Expression expression);
        void Visit(ConstantExpression expression);
        void Visit(BinaryExpression expression);
    }
}
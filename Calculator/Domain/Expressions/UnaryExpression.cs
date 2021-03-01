using Domain.Visitors;

namespace Domain.Expressions
{
    public enum UnaryExpressionType
    {
        Plus,
        Minus
    }

    public record UnaryExpression(UnaryExpressionType Type, Expression Right) : Expression
    {
        public override T Accept<T>(IExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
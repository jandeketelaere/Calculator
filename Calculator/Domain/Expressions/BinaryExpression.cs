using Domain.Visitors;

namespace Domain.Expressions
{
    public enum BinaryExpressionType
    {
        Add,
        Subtract
    }

    public record BinaryExpression(BinaryExpressionType Type, Expression Left, Expression Right) : Expression
    {
        public override T Accept<T>(IExpressionVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
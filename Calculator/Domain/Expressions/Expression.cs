using Domain.Visitors;

namespace Domain.Expressions
{
    public abstract record Expression
    {
        public static Expression Constant(int value)
            => new ConstantExpression(value);

        public static Expression Binary(BinaryExpressionType type, Expression left, Expression right)
            => new BinaryExpression(type, left, right);

        public abstract void Accept(IExpressionVisitor visitor);
    }

    public enum BinaryExpressionType
    {
        Add,
        Subtract
    }

    public record ConstantExpression(int Value) : Expression
    {
        public override void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public record BinaryExpression(BinaryExpressionType Type, Expression Left, Expression Right) : Expression
    {
        public override void Accept(IExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
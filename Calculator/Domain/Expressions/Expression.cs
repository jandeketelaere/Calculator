using Domain.Visitors;

namespace Domain.Expressions
{
    public abstract record Expression
    {
        public static Expression Constant(int value)
            => new ConstantExpression(value);

        public static Expression Binary(BinaryExpressionType type, Expression left, Expression right)
            => new BinaryExpression(type, left, right);

        public static Expression Unary(UnaryExpressionType type, Expression right)
            => new UnaryExpression(type, right);

        public abstract T Accept<T>(IExpressionVisitor<T> visitor);
    }
}
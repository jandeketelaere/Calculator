using Domain.Expressions;
using System;

namespace Domain.Visitors
{
    public class CalculationExpressionVisitor : ExpressionVisitor
    {
        public int Result { get; private set; }

        public override void Visit(ConstantExpression expression)
        {
            Result = expression.Value;
        }

        public override void Visit(BinaryExpression expression)
        {
            Visit(expression.Left);
            var left = Result;

            Visit(expression.Right);
            var right = Result;

            var result = expression.Type switch
            {
                BinaryExpressionType.Add => left + right,
                BinaryExpressionType.Subtract => left - right,
                _ => throw new NotImplementedException($"No implementation found for type {expression.Type}"),
            };

            Result = result;
        }
    }
}
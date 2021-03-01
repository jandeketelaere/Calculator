using Domain.Expressions;
using Domain.Tokens;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class ParserTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Parse_Should_Return_Expression(IEnumerable<Token> tokens, Expression expectedExpression)
        {
            var parser = new Parser();

            var expression = parser.Parse(tokens);

            expression.ShouldBe(expectedExpression);
        }

        public static IList<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
                    new[] { Token.Number(5), Token.Plus, Token.Number(5), Token.Minus, Token.Number(5) },
                    Expression.Binary
                    (
                        BinaryExpressionType.Subtract,
                        Expression.Binary
                        (
                            BinaryExpressionType.Add,
                            Expression.Constant(5),
                            Expression.Constant(5)
                        ),
                        Expression.Constant(5)
                    )
                },
                new object[]
                {
                    new[] { Token.Minus, Token.Number(5) },
                    Expression.Unary
                    (
                        UnaryExpressionType.Minus,
                        Expression.Constant(5)
                    )
                },
                new object[]
                {
                    new[] { Token.Minus, Token.Plus, Token.Minus, Token.Number(5) },
                    Expression.Unary
                    (
                        UnaryExpressionType.Minus,
                        Expression.Unary
                        (
                            UnaryExpressionType.Plus,
                            Expression.Unary
                            (
                                UnaryExpressionType.Minus,
                                Expression.Constant(5)
                            )
                        )
                    )
                },
                new object[]
                {
                    new[] { Token.Plus, Token.Plus, Token.Number(5), Token.Plus, Token.Plus, Token.Number(10) },
                    Expression.Binary
                    (
                        BinaryExpressionType.Add,
                        Expression.Unary
                        (
                            UnaryExpressionType.Plus,
                            Expression.Unary
                            (
                                UnaryExpressionType.Plus,
                                Expression.Constant(5)
                            )
                        ),
                        Expression.Unary
                        (
                            UnaryExpressionType.Plus,
                            Expression.Constant(10)
                        )
                    )
                },
            };
    }
}
using Domain.Expressions;
using Domain.Tokens;
using Shouldly;
using Xunit;

namespace Tests
{
    public class ParserTests
    {
        [Fact]
        public void Parse_Should_Return_Expression()
        {
            var tokens = new[] { Token.Number(5), Token.Plus, Token.Number(5), Token.Minus, Token.Number(5) };
            var parser = new Parser();

            var expression = parser.Parse(tokens);

            var expectedExpression = Expression.Binary
            (
                BinaryExpressionType.Subtract,
                Expression.Binary
                (
                    BinaryExpressionType.Add,
                    Expression.Constant(5),
                    Expression.Constant(5)
                ),
                Expression.Constant(5)
            );

            expression.ShouldBe(expectedExpression);
        }
    }
}
using Domain.Expressions;
using Domain.Interpreters;
using Shouldly;
using Xunit;

namespace Tests
{
    public class InterpreterTests
    {
        [Fact]
        public void Interpret_Should_Return_Result()
        {
            var expression = Expression.Binary
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

            var interpreter = new Interpreter();

            var result = interpreter.Interpret(expression);

            result.ShouldBe(5);
        }
    }
}
using Domain.Expressions;
using Domain.Interpreters;
using Shouldly;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class InterpreterTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Interpret_Should_Return_Result(Expression expression, int expectedNumber)
        {
            var interpreter = new Interpreter();

            var result = interpreter.Interpret(expression);

            result.ShouldBe(expectedNumber);
        }

        public static IList<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
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
                    ),
                    5
                },
                new object[]
                {
                    Expression.Binary
                    (
                        BinaryExpressionType.Add,
                        Expression.Unary
                        (
                            UnaryExpressionType.Minus,
                            Expression.Unary
                            (
                                UnaryExpressionType.Plus,
                                Expression.Constant(5)
                            )
                        ),
                        Expression.Unary
                        (
                            UnaryExpressionType.Minus,
                            Expression.Constant(10)
                        )
                    ),
                    -15
                },
            };
    }
}
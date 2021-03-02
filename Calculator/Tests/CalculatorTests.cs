using Domain;
using Domain.Expressions;
using Domain.Interpreters;
using Domain.Tokens;
using Shouldly;
using Xunit;

namespace Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Calculate_Should_Work()
        {
            var input = "-5*(2+10)/5-1";

            var calculator = new Calculator(new Tokenizer(), new Parser(), new Interpreter());

            var result = calculator.Calculate(input);

            result.ShouldBe(-13);
        }
    }
}
using Domain.Expressions;
using Domain.Interpreters;
using Domain.Tokens;

namespace Domain
{
    public class Calculator
    {
        private readonly ITokenizer _tokenizer;
        private readonly IParser _parser;
        private readonly IInterpreter _interpreter;

        public Calculator(ITokenizer tokenizer, IParser parser, IInterpreter interpreter)
        {
            _tokenizer = tokenizer;
            _parser = parser;
            _interpreter = interpreter;
        }

        public int Calculate(string input)
        {
            var tokens = _tokenizer.Tokenize(input);
            var expression = _parser.Parse(tokens);
            var result = _interpreter.Interpret(expression);

            return result;
        }
    }
}
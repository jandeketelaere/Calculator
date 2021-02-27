using Domain.Tokens;
using System;
using System.Collections.Generic;

namespace Domain.Expressions
{
    public class Parser : IParser
    {
        private Enumerator<Token> _enumerator;

        public Expression Parse(IEnumerable<Token> tokens)
        {
            _enumerator = new Enumerator<Token>(tokens);

            return ParseAdditionSubtraction();
        }

        private Expression ParseAdditionSubtraction()
        {
            var expression = ParseNumber();

            while (HasTokenType(TokenType.Plus, TokenType.Minus))
            {
                MoveNext();
                var token = Current();

                var type = token.TokenType == TokenType.Plus
                    ? BinaryExpressionType.Add
                    : BinaryExpressionType.Subtract;

                var right = ParseNumber();

                expression = Expression.Binary(type, expression, right);
            }

            return expression;
        }

        private Expression ParseNumber()
        {
            if (HasTokenType(TokenType.Number))
            {
                MoveNext();
                var token = Current() as NumberToken;

                return Expression.Constant(token.Value);
            }

            throw new Exception("boem");
        }

        private void MoveNext()
            => _enumerator.MoveNext();

        private Token Current()
            => _enumerator.Current;

        private bool HasTokenType(params TokenType[] tokenTypes)
        {
            if (!_enumerator.HasNext())
                return false;

            var token = _enumerator.Peek();

            return token.TokenType.In(tokenTypes);
        }
    }
}
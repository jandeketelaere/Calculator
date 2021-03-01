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

            return ParseAdditionOrSubtraction();
        }

        private Expression ParseAdditionOrSubtraction()
        {
            var expression = ParsePositiveOrNegative();

            while (HasTokenType(TokenType.Plus, TokenType.Minus))
            {
                var token = GetToken();

                var type = token.TokenType == TokenType.Plus
                    ? BinaryExpressionType.Add
                    : BinaryExpressionType.Subtract;

                var right = ParsePositiveOrNegative();

                expression = Expression.Binary(type, expression, right);
            }

            return expression;
        }

        private Expression ParsePositiveOrNegative()
        {
            if (HasTokenType(TokenType.Plus, TokenType.Minus))
            {
                var token = GetToken();

                var type = token.TokenType == TokenType.Plus
                    ? UnaryExpressionType.Plus
                    : UnaryExpressionType.Minus;

                var right = ParsePositiveOrNegative();

                return Expression.Unary(type, right);
            }

            return ParseNumber();
        }

        private Expression ParseNumber()
        {
            if (HasTokenType(TokenType.Number))
            {
                var token = GetToken() as NumberToken;

                return Expression.Constant(token.Value);
            }

            throw new Exception("boem");
        }

        private void MoveNext()
            => _enumerator.MoveNext();

        private Token GetToken()
            => _enumerator.Current;

        private bool HasTokenType(params TokenType[] tokenTypes)
        {
            if (!_enumerator.HasNext())
                return false;

            var token = _enumerator.Peek();

            if (token.TokenType.In(tokenTypes))
            {
                MoveNext();
                return true;
            }

            return false;
        }
    }
}
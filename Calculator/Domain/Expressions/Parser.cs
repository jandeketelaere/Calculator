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

            var expression = Parse();

            return expression;
        }

        private Expression Parse()
        {
            return ParseAdditionOrSubtraction();
        }

        private Expression ParseAdditionOrSubtraction()
        {
            var expression = ParseMultiplicationOrDivision();

            while (HasTokenType(TokenType.Plus, TokenType.Minus))
            {
                var token = GetToken();

                var type = token.TokenType switch
                {
                    TokenType.Plus => BinaryExpressionType.Add,
                    TokenType.Minus => BinaryExpressionType.Subtract,
                    _ => throw new NotImplementedException(),
                };

                var right = ParseMultiplicationOrDivision();

                expression = Expression.Binary(type, expression, right);
            }

            return expression;
        }

        private Expression ParseMultiplicationOrDivision()
        {
            var expression = ParsePositiveOrNegative();

            while (HasTokenType(TokenType.Multiplication, TokenType.Division))
            {
                var token = GetToken();

                var type = token.TokenType switch
                {
                    TokenType.Multiplication => BinaryExpressionType.Multiply,
                    TokenType.Division => BinaryExpressionType.Divide,
                    _ => throw new NotImplementedException(),
                };

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

                var type = token.TokenType switch
                {
                    TokenType.Plus => UnaryExpressionType.Plus,
                    TokenType.Minus => UnaryExpressionType.Minus,
                    _ => throw new NotImplementedException(),
                };

                var right = ParsePositiveOrNegative();

                return Expression.Unary(type, right);
            }

            return ParseNumberOrParenthesis();
        }

        private Expression ParseNumberOrParenthesis()
        {
            if (HasTokenType(TokenType.Number))
            {
                var token = GetToken() as NumberToken;

                return Expression.Constant(token.Value);
            }

            if (HasTokenType(TokenType.LeftParenthesis))
            {
                var expression = Parse();

                if (HasTokenType(TokenType.RightParenthesis))
                    return expression;

                throw new Exception("boem");
            }

            throw new Exception("boem");
        }

        private Token GetToken()
            => _enumerator.Current;

        private bool HasTokenType(params TokenType[] tokenTypes)
        {
            if (!_enumerator.HasNext())
                return false;

            var token = _enumerator.Peek();

            if (token.TokenType.In(tokenTypes))
            {
                _enumerator.MoveNext();
                return true;
            }

            return false;
        }
    }
}
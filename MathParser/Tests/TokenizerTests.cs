using Domain;
using Domain.Tokens;
using Shouldly;
using System;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class TokenizerTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Tokenize_Should_Return_Tokens(string input, IEnumerable<Token> expectedTokens)
        {
            var tokenizer = new Tokenizer();

            var tokens = tokenizer.Tokenize(input);

            tokens.ShouldBe(expectedTokens);
        }

        public static IList<object[]> Data =>
            new List<object[]>
            {
                new object[]{"a", Array.Empty<Token>()},
                new object[]{"5", new[] { Token.Number(5) } },
                new object[]{"55", new[] { Token.Number(55) } },
                new object[]{"+55", new[] { Token.Plus, Token.Number(55) } },
                new object[]{"+55+", new[] { Token.Plus, Token.Number(55), Token.Plus } },
                new object[]{"+55+5", new[] { Token.Plus, Token.Number(55), Token.Plus, Token.Number(5) } },
                new object[]{"+55+55", new[] { Token.Plus, Token.Number(55), Token.Plus, Token.Number(55) } },
                new object[]{"-55", new[] { Token.Minus, Token.Number(55) } },
                new object[]{"-55-", new[] { Token.Minus, Token.Number(55), Token.Minus } },
                new object[]{"-55-5", new[] { Token.Minus, Token.Number(55), Token.Minus, Token.Number(5) } },
                new object[]{"-55-55", new[] { Token.Minus, Token.Number(55), Token.Minus, Token.Number(55) } },
                new object[]{"+5-5-+55++--", new[] { Token.Plus, Token.Number(5), Token.Minus, Token.Number(5), Token.Minus, Token.Plus, Token.Number(55), Token.Plus, Token.Plus, Token.Minus, Token.Minus } }
            };
    }
}
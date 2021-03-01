using System.Collections.Generic;
using System.Linq;

namespace Domain.Tokens
{
    public class Tokenizer : ITokenizer
    {
        public IEnumerable<Token> Tokenize(string input)
        {
            var enumerator = new Enumerator<string>(input.Select(char.ToString));
            string tempNumber = null;

            while (enumerator.HasNext())
            {
                enumerator.MoveNext();
                var character = enumerator.Current;

                if (!IsNumeric(character) && tempNumber != null)
                {
                    yield return Token.Number(int.Parse(tempNumber));
                    tempNumber = null;
                }

                if (IsNumeric(character))
                    tempNumber = $"{tempNumber}{character}";

                if (character == "+")
                    yield return Token.Plus;

                if (character == "-")
                    yield return Token.Minus;
            }

            if (tempNumber != null)
                yield return Token.Number(int.Parse(tempNumber));
        }

        private static bool IsNumeric(string value)
            => int.TryParse(value, out _);
    }
}
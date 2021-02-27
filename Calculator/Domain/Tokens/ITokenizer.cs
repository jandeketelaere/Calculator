using System.Collections.Generic;

namespace Domain.Tokens
{
    public interface ITokenizer
    {
        IEnumerable<Token> Tokenize(string input);
    }
}
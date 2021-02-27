using Domain.Tokens;
using System.Collections.Generic;

namespace Domain.Expressions
{
    public interface IParser
    {
        Expression Parse(IEnumerable<Token> tokens);
    }
}
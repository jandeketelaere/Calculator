using Domain.Expressions;

namespace Domain.Interpreters
{
    public interface IInterpreter
    {
        int Interpret(Expression expression);
    }
}
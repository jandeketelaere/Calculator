﻿using Domain.Expressions;
using Domain.Visitors;

namespace Domain.Interpreters
{
    public class Interpreter : IInterpreter
    {
        public int Interpret(Expression expression)
        {
            var visitor = new CalculatorExpressionVisitor();
            visitor.Visit(expression);

            var result = visitor.Result;

            return result;
        }
    }
}
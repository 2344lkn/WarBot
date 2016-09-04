using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using NCalc;

namespace WarBot
{
    class NCalc
    {
        public static string NCalcInput(string expression)
        {
            if (expression.Contains("a") || expression.Contains("b") || expression.Contains("c") || expression.Contains("d")
                || expression.Contains("e") || expression.Contains("f") || expression.Contains("g") || expression.Contains("h")
                || expression.Contains("i") || expression.Contains("j") || expression.Contains("k") || expression.Contains("l")
                || expression.Contains("m") || expression.Contains("n") || expression.Contains("o") || expression.Contains("p")
                || expression.Contains("q") || expression.Contains("r") || expression.Contains("s") || expression.Contains("t")
                || expression.Contains("u") || expression.Contains("v") || expression.Contains("w") || expression.Contains("x")
                || expression.Contains("y") || expression.Contains("z"))
            {
                return "Invalid Expression.";
            }
            else
            {
                try
                {
                    Expression e = new Expression(expression);
                    if (!e.HasErrors())
                        return (e.Evaluate().ToString());
                }
                catch (EvaluationException e)
                {
                    return ("Error Catched: " + e.Message);
                }
            }
            return "Invalid Expression.";
        }
    }
}

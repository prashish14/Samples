using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Console.Samples
{
    public class LambdaExpressionTreeSample
    {
        public void Run()
        {
            ExprTree.PrintSum();
            ExprTree.PrintExpresstion();
            ExprTree.DifficultExpresstionPrint();
        }
    }

    public static class ExprTree
    {
        public static void PrintSum()
        {
            Expression firstArg = Expression.Constant(2);
            Expression secondArg = Expression.Constant(3);
            BinaryExpression add = Expression.Add(firstArg, secondArg); //BinaryExpression inherit from Expression

            System.Console.WriteLine("Result: {0}", add);
        }

        public static void PrintExpresstion()
        {
            Expression<Func<int>> return5 = () => 5;
            Func<int> compiled = return5.Compile();

            System.Console.WriteLine("Result: {0}", compiled());
        }

        public static void DifficultExpresstionPrint()
        {
            Expression<Func<string, string, bool>> expression = (str1, str2) => str1.StartsWith(str2);
            Func<string, string, bool> compiled = expression.Compile();

            System.Console.WriteLine(compiled("Pasha", "Pa"));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Sample.Application.Console.SamplesSecondPart
{
    public class ExpressionTreeSamples
    {
        public ExpressionTreeSamples()
        {
            //TODO: constructor
        }

        public void Run()
        {
            
        }

        public void BuildExpressionTree()
        {
            Func<int, int, int> function = (a, b) => a + b;
            Expression<Func<int, int, int>> expression = (a, b) => a + b;

        }
    }
}

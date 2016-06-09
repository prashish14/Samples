using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Console.SamplesSecondPart
{
    public class AnonimusFunctionSample
    {
        public AnonimusFunctionSample()
        {
        }

        public void Run()
        {
            Func<string, int> someDelegate = new Func<string, int>(GetStringLength);
            Action<int> someVoidDelegate = new Action<int>(PrintStringLength);
            Func<string, string, int> totalRowLengthDelegate = new Func<string, string, int>(CalcTotalLength);

            Func<string, int> anonimusDeleagate = delegate(string str) { return str.Length; };
            Func<string, int> expression = (string str) => { return str.Length; };
            Func<string, int> lambdaExpression = str => str.Length;

            //call
            someVoidDelegate(someDelegate("Hello"));
            expression("Hello");
            lambdaExpression("Hello");
            totalRowLengthDelegate("Pavel", "Kaliukhovich");
        }

        public int GetStringLength(string str)
        {
            return str.Length;
        }

        public void PrintStringLength(int length)
        {
            System.Console.WriteLine("string length: {0}", length);
        }

        public int CalcTotalLength(string leftString, string rightStrirng)
        {
            int length = GetStringLength(leftString) + GetStringLength(rightStrirng);
            return length;
        }
    }
}

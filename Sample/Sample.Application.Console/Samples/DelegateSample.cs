using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Console.Samples
{
    public class DelegateSample
    {
        public void Run()
        {
            DelegateTest test = new DelegateTest();
            test.Test();
        }
    }

    public class DelegateTest
    {
        internal delegate void Feedback(int value); //delegate(it's just type) for method with int param and void return value

        public void Test()
        {
            Feedback fb1 = new Feedback(Method1); //set method to delegate variable
            Feedback fb2 = new Feedback(Method2);

            Feedback fb = null; //combine all methods in 1 delegate variable
            fb += fb1;
            fb += fb2;

            Method(11, fb); 
        }

        private void Method(int value, Feedback fb)
        {
            if (fb != null)
            {
                fb(value);  //call all methods in delegate variable with value parameter 
            } 
        }

        private void Method1(int value)
        {
            System.Console.WriteLine("Method1: {0}", value);
        }

        private void Method2(int value)
        {
            System.Console.WriteLine("Method2: {0}", value);
        }
    }
}

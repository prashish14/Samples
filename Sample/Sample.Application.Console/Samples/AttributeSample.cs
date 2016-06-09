using System;
using System.Reflection;

namespace Sample.Application.Console.Samples
{
    public class AttributeSample
    {
        public void Run()
        {
            AttributeTest test = new AttributeTest();

            //using System.Reflection
            if (test.GetType().GetMethod("WriteCheck").GetCustomAttribute<CheckAttribute>().Checking == true)
            {
                System.Console.WriteLine(test.WriteCheck());
            }
            else
            {
                System.Console.WriteLine("Can't write check");
            }

            //example of using method is defined
            //if (test.GetType().GetMethod("WriteCheck").IsDefined(typeof (CheckAttribute)))
            //{
            //    System.Console.WriteLine(test.WriteCheck());
            //}
            //else
            //{
            //    System.Console.WriteLine("Cant write check");
            //}
        }
    }

    //test class
    public class AttributeTest
    {
        [CheckAttribute(true)]
        public string WriteCheck()
        {
            return "Checked by Pavel Kaliukhovich";
        }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class CheckAttribute : Attribute
    {
        public bool Checking { get; set; }

        public CheckAttribute(bool chacking)
        {
            Checking = chacking;
        }
    }
}

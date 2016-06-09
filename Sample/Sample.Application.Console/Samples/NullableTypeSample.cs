using System;

namespace Sample.Application.Console.Samples
{
    public class NullableTypeSample
    {
        public void Run()
        {
            NullableTypeTest test = new NullableTypeTest();
            test.PrintNullableValue();
        }
    }

    public class NullableTypeTest
    {
        public void PrintNullableValue()
        {
            Nullable<Int32> age = null;
            int? age2 = null; //the same as previous
            double? weigh = null;
            age = 15;
            System.Console.WriteLine("Test = {0}, HasValue = {1}", age.Value, age.HasValue);

            age = null;

            int newAge = age ?? 0; //if age = null, then newAge = 0 //operator ?? returns age if age not null, else 0
            int newAge2 = age.HasValue ? age.Value : 0; //the same
            int newAge3 = (age != null) ? age.Value : 0; //the same

            System.Console.WriteLine("newAge = {0}", newAge); //should be 0
            System.Console.WriteLine("newAge = {0}", newAge2); //should be 0
            System.Console.WriteLine("newAge = {0}", newAge3); //should be 0

            //CLR makes code of explicit converting type to Int32 then into IComparable, if count = null can be nullreference excption
            int? count = 3;
            int result = ((IComparable) count).CompareTo(3); 
            System.Console.WriteLine("result: {0}", result); //should be 0
        }
    }
}

using System;
using System.Runtime.InteropServices;

namespace Sample.Application.Console.Samples
{
    public class ParametersSample
    {
        public void Run()
        {
            System.Console.WriteLine(ParametersSampleTest.TestMethod());
            System.Console.WriteLine(ParametersSampleTest.GetDateTime());
            System.Console.WriteLine(ParametersSampleTest.GetDateTime(dateTime: DateTime.Now)); //named param
            Int32 param = 1;
            Int32 par = 1;
            ReferenceParamsSampleTest.TestMethod(out param);
            ReferenceParamsSampleTest.Test(ref par);
            System.Console.WriteLine(ReferenceParamsSampleTest.VariableNumberOfArguments(1, 3, 4)); //should return 8
        }
    }

    public static class ParametersSampleTest
    {
        //default param value = Pasha, you can call just TestMethod() without param name
        public static string TestMethod(string name = "Default Name")
        {
            var x = new DateTime();
            return name;
        }

        public static DateTime GetDateTime(DateTime dateTime = default(DateTime))
        {
            return dateTime;
        }
    }

    public static class ReferenceParamsSampleTest
    {
        public static string TestMethod(out Int32 param) //param is the pointer to value-type Int32
        {
            param = 1; // you should initialize this param
            return "";
        }

        public static int Test(ref Int32 par) //you should initialize par befor call
        {
            return par;
        }

        public static int VariableNumberOfArguments(params int[] values)
        {
            int result = 0;
            foreach (var item in values)
            {
                result += item;
            }
            return result;
        }
    }

    public class ParameterlessProperties
    {
        public string Name { get; set; } //short syntax of properties, compiler generate 2 methods
        public int Age { get; set; } //automatic properties

        private int _weight;
        public int Weight {
            get { return _weight;  }
            set
            {
                if (value >= 0)
                    _weight = value;
                else
                    _weight = 0;
            }
        }

        public static int Test()
        {
            return 1;
        }
    }
}

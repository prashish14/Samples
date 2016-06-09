using System;

namespace Sample.Application.Console.Samples
{
    public  class TypeMembersSample
    {
        SomeType type = new SomeType();
    }

    public sealed class SomeType //you can't inherit from sealed class
    {
        //nested class
        private class _someNestedClass
        {
        };

        //constant
        private const Int32 _someConstant = 3;

        //readonly field
        private readonly String _someReadOnlyField = "test";

        //static field (for type, not instance!)
        private static Int32 _someReadWriteField = 3;

        //constructors
        static SomeType()
        {
        }

        //instance method
        private string InstanceMethod()
        {
            return null;
        }

        //static method (for type, not instance!)
        public static string StaticMethod()
        {
            return null;
        }

        private Int32 _someProp;
        
        //not general prop
        public Int32 SomeProp
        {
            get { return 0; }
            set { _someProp = value; }
        }

        //general prop
        public Int32 this[String s]
        {
            get { return 0; }
            set { }
        }

        //instance event 
        public event EventHandler _instanceEvent;
    }
}

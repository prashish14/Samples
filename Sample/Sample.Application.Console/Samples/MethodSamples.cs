using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Console.Samples
{
    public class MethodSamples
    {

    }

    public class SampleType
    {
        public SampleType()
            : base()
        {
        }
    }


    public sealed class TestInitialize
    {
        private Int32 m = 5; //initialize field when object creates
        private String s;

        public TestInitialize()
        {
            m = 5;
            s = "test";
        }

        public TestInitialize(Int32 m) : this() //call initialize constructor then set m 
        {
            this.m = m;
        }

        public TestInitialize(Int32 m, string s) : this()
        {
            this.m = m;
            this.s = s;
        }
        //calling this() constructor decrease IL-code for initialization
    }

    public struct PointTest
    {
        public Int32 x;
        public Int32 y;

        //public PointTest() //you can't create constructor without parameters in value-type
        //{
        //}

        public PointTest(Int32 x, Int32 y)
        {
            this.x = x;
            this.y = y;
        }
    }

    internal sealed class SomeRefType
    {
        static SomeRefType() //constructor will be called once, first time
        {
        }
    }

    public struct ConstructorTest
    {
        static ConstructorTest() //CLR never call this constructor,,  bad practice
        {
        }
    }
}

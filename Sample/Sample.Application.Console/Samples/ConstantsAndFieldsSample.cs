using System;

namespace Sample.Application.Console.Samples
{
    public class ConstantsAndFieldsSample
    {
        //constants is used for primitive types only!
        public const string Name = "Pasha";

        //but you can declare constant with not primitive type using null value
        public const BoxingSample Sample = null;

        //constants are static, constants are inserted into IL, you can't get addres of constant!
        public void Run()
        {
            System.Console.WriteLine(Math.PI);
        }

        //--------------------------------------

        //static filed - associated with type! not instance, readonly - write only in constructor
        public static readonly Int32 ReadOnlyField = 11;
        public const Int32 ReadOnlyConst = 11;

        //writable field
        public static Int32 WritableField = 22;

        //readonly field of instance, write only in constructor
        public readonly Int32 InstanceField = 33;

        //readonly for reference type means unchanging of reference, InvalidChars = A only! (the first element of array)
        //you can't change InvalidChars.
        public static readonly Char[] InvalidChars = new char[]{ 'A', 'B', 'C' };


    }
}

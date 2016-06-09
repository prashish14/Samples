using System;
using System.Security.Policy;

namespace Sample.Application.Console.Samples
{
    public class EnumSamples
    {
        public void Run()
        {
            EnumTest enumTest = new EnumTest();
            enumTest.PrintEnum();
        }
    }

    public class EnumTest
    {
        public void PrintEnum()
        {
            CustomColor color = CustomColor.Black;
            System.Console.WriteLine(color);
            System.Console.Write(System.Environment.NewLine);

            Array values = Enum.GetValues(typeof(CustomColor));
            foreach (var value in values)
            {
                System.Console.WriteLine(value);
            }

            System.Console.Write(System.Environment.NewLine);
            CustomColor[] colors = EnumTest.GetEnumValues<CustomColor>();    //second way to get enum array values
            foreach (var c in colors)
            {
                System.Console.WriteLine(c);
            }

            System.Console.Write(System.Environment.NewLine);
            System.Console.WriteLine(Enum.GetName(typeof(CustomColor), 0));

            System.Console.WriteLine();
            System.Console.WriteLine(Enum.IsDefined(typeof(CustomColor), 59)); //should be false
        }

        public static TEnum[] GetEnumValues<TEnum>() where TEnum : struct
        {
            return (TEnum[])Enum.GetValues(typeof(TEnum));
        }
    }

    internal enum CustomColor
    {
        White, //value = 0
        Black, //value = 1
        Green, //and so on...
        Yellow,
        Red,
        Blue
    }
}

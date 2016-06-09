using System;
using System.Text;

namespace Sample.Application.Console.Samples
{
    public class EncodingDecodingSample
    {
        public void Run()
        {
            EncodingTest test = new EncodingTest();
            //test.PrintUTF8String();
            test.PrintBase64String();
        }
    }

    public class EncodingTest
    {
        public void PrintUTF8String()
        {
            Encoding encodingUTF8 = Encoding.UTF8;
            Byte[] bytes = encodingUTF8.GetBytes("Hello, world!");    //encoding
            System.Console.WriteLine(BitConverter.ToString(bytes));

            Byte[] array = new byte[] { 49, 50, 51, 52, 53, 54 };
            System.Console.WriteLine(encodingUTF8.GetString(array)); //decoding array of bytes

            System.Console.WriteLine(encodingUTF8.GetString(bytes));  //decoding
        }

        public void PrintBase64String()
        {
            string s =  Convert.ToBase64String(new byte[]{ 49, 50, 51, 52 });
            byte[] bytes = Convert.FromBase64String(s);

            System.Console.WriteLine(s);
            System.Console.WriteLine(BitConverter.ToString(bytes));
        }
    }
}

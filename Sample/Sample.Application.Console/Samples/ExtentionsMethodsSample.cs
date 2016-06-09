using System;
using System.Text;

namespace Sample.Application.Console.Samples
{
    public class ExtentionsMethodsSample
    {
        public ExtentionsMethodsSample()
        {
        }

        public void Run()
        {
            StringBuilder testStringBuilder = new StringBuilder("hello");
            System.Console.WriteLine(testStringBuilder.IndexOf('l')); //call of extention method
        }        
    }

    public static class StringBuilderExtensions
    {
        //this before parameter means, that this method is extention method for StringBuilder
        public static int IndexOf(this StringBuilder sb, Char value) // keyword this!!!!!!!! 
        {
            for (Int32 index = 0; index < sb.Length; index ++)
            {
                if (sb[index] == value)
                {
                    return index;
                }
            }

            return -1;
        }
    }
}

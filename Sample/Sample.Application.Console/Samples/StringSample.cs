using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Sample.Application.Console.Samples
{
    public class StringSample
    {
        public StringSample()
        {
        }

        public void Run()
        {
            TextExample test = new TextExample();
            //test.PrintCharInfo();
            //test.PrintStringInfo();
            //test.PrintSortedArray();
            //test.CompareTwoStrings();
            //test.GetStringInfo();
            //test.PrintEffectiveStrings();
            test.ParseStringToNumericValue();
        }
    }

    public class TextExample
    {
        public TextExample()
        {  
        }

        public void PrintCharInfo()
        {
            System.Console.WriteLine("Max Value: {0}", System.Char.MaxValue);
            System.Console.WriteLine("Min Value: {0}", System.Char.MinValue);
            System.Globalization.UnicodeCategory category = System.Char.GetUnicodeCategory("e", 0);
            System.Console.WriteLine("Unicode category: {0}", System.Char.GetUnicodeCategory("4", 0));
            if (System.Char.IsDigit("5", 0))
            {
                System.Console.WriteLine("Digit!");
            }

            Char ch = '1';
            System.Console.WriteLine("char type: {0}", ch);

            //3 ways to convert int to char
            int aCode = 65;

            Char charValue = (Char)aCode; // A - the best way
            System.Console.WriteLine("{0}", charValue);

            Char charValue2 = Convert.ToChar(aCode); //middle way so-so
            System.Console.WriteLine("{0}", charValue2);

            Char charValue3 = ((IConvertible) aCode).ToChar(null); // very bad way, because boxing
            System.Console.WriteLine("{0}", charValue3);
        }

        public void PrintStringInfo()
        {
            String s = "Hello, world!";
            System.Console.WriteLine(s);
        }

        public void PrintSortedArray()
        {
            string[] strings = new[] { "ddd", "ccc", "bbb", "aaa" };

            List<string> strs = strings.ToList();
            strs.Sort();
            foreach (var str in strs)
            {
                System.Console.WriteLine(str);
            }
        }

        public void CompareTwoStrings()
        {
            String s1 = "hello";
            String s2 = "hella";

            Boolean eq;

            eq = String.Compare(s1, s2, StringComparison.Ordinal) == 0;

            CultureInfo ci = new CultureInfo("de-De");
            CompareInfo compareInfo = CompareInfo.GetCompareInfo("es-ES");
            eq = compareInfo.Compare(s1, s2) == 0;
            eq = String.Compare(s1, s2, true, ci) == 0; //using culture info class, comparae with regional standarts
        }

        public void GetStringInfo()
        {
            StringInfo stringInfo = new StringInfo("Hello");

        }

        public void PrintEffectiveStrings()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0} {1}", "Pavel", "Kaliukhovich").Replace(" ","-");

            string s = sb.ToString().ToUpper();
            sb.Length = 0;
            sb.Append(s).Insert(0, "M-");
            System.Console.WriteLine(sb);
        }

        public void ParseStringToNumericValue()
        {
            string s = "22";
            string s1 = "61,8";
            string s2 = " 55";
            string sDate = "26/03/1993";

            int age = int.Parse(s);
            double weight = double.Parse(s1);
            int age2 = int.Parse(s2, NumberStyles.AllowLeadingWhite, null); //get cultureinfo from called thread, NumberStyles allow use whitespace
            DateTime date = DateTime.Parse(sDate, null, DateTimeStyles.AssumeLocal); //tryParse without exception

            System.Console.WriteLine("Age: {0}", age);
            System.Console.WriteLine("Age: {0}", weight);
            System.Console.WriteLine("Age2: {0}", age2);
            System.Console.WriteLine("Date: {0:dd-MMM-yy}", date);
        }

        private void Swap(string str1, string str2)
        {
            string temp = str1;
            str1 = str2;
            str2 = temp;
        }
    }
}

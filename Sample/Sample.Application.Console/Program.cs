using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Application.Console.Samples;
using Sample.Application.Console.SamplesSecondPart;

namespace Sample.Application.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            SynchronousCodeSample sample = new SynchronousCodeSample();
            sample.Run();

            System.Console.Write(System.Environment.NewLine);
            System.Console.WriteLine(System.Environment.MachineName + ": Press any kay to exit...");
            System.Console.ReadLine();
        }
    }
}

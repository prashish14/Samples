using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Console.SamplesSecondPart
{
    public class AsynAnonimFuncSample
    {
        public void Run()
        {
            var result = Test();
            System.Console.WriteLine("Result: {0}", result);
        }

        public int Test()
        {
            Func<Task> lambda = async () => await Task.Delay(1000);
            Func<Task<int>> anonMethod = async delegate()
            {
                System.Console.WriteLine("Started");
                await Task.Delay(1000);
                System.Console.WriteLine("Finished");
                return 10;
            };

            Task<int> task = anonMethod();
            return task.Result;
        }
    }
}

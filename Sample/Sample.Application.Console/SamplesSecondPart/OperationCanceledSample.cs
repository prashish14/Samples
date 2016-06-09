using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.Console.SamplesSecondPart
{
    public class OperationCanceledSample
    {
        public OperationCanceledSample()
        {
            //TODO:
        }

        public void Run()
        {
            Task task = ThrowCancellationException();
            System.Console.WriteLine("Result: {0}", task.Status);

            var source = new CancellationTokenSource();
            var secondTask = WaitFor10Seconds(source.Token);
            source.CancelAfter(TimeSpan.FromSeconds(1));
            System.Console.WriteLine("Initial status: {0}", secondTask.Status);

            try
            {
                secondTask.Wait();
            }
            catch (AggregateException e)
            {
                System.Console.WriteLine("Cought {0}", e.InnerExceptions[0]);
            }
            System.Console.WriteLine("Final status: {0}", secondTask.Status);
        }

        public async Task ThrowCancellationException()
        {
            throw new OperationCanceledException();
        }


        public async Task WaitFor10Seconds(CancellationToken token)
        {
            System.Console.WriteLine("Wainting for 10 seconds");
            await Task.Delay(TimeSpan.FromSeconds(30), token);
        }
    }
}

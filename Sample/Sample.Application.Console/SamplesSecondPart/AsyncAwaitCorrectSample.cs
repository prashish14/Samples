using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Console.SamplesSecondPart
{
    public class AsyncAwaitCorrectSample
    {
        public AsyncAwaitCorrectSample()
        {
        }

        public void Run()
        {
            Task<int> task = ComputeLengthAsync("Hello");
            System.Console.WriteLine("result: {0}", task.Result);
        }

        public Task<int> ComputeLengthAsync(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            return ComputeLengthAsyncImpl(text);
        }

        public async Task<int> ComputeLengthAsyncImpl(string text)
        {
            await Task.Delay(500);
            return text.Length;
        }
    }
}

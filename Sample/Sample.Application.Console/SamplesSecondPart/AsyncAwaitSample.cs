using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sample.Application.Console.SamplesSecondPart
{
    public class AsyncAwaitSample
    {
        public AsyncAwaitSample()
        {
            //TODO:
        }

        public void Run()
        {
            Task<int> task = ComputeLengthAsync("hello, world!");
            int len = task.Result;
            System.Console.WriteLine("result: {0}", len);

            Task secondTask = MainAsync();
            var status =  secondTask.Status;
            System.Console.WriteLine("status: {0}", status);
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
            await Task.Delay(500); //emulation of async work
            return text.Length;
        }

        public async Task MainAsync()
        {
            Task<string> task = ReadFileAsync("garbage file");
            try
            {
                string text = await task;
                System.Console.WriteLine("File contents: {0}", text);
            }
            catch (IOException e)
            {
                System.Console.WriteLine("Cought IOEXception: {0}", e.Message);
            }
        }

        public async Task<string> ReadFileAsync(string fileName)
        {
            using (var reader = File.OpenText(fileName))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}

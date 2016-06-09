using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Sample.Application.Console.SamplesSecondPart
{
    public class DelegateWithAsyncAnonimFuncSample
    {
        public void Run()
        {
            TestTask();
            ShowPageLengthAsync("http://www.vk.com");
        }

        public void TestTask()
        {
            Func<int, Task<int>> function = async x =>
            {
                System.Console.WriteLine("Starting... x = {0}", x);
                await Task.Delay(5000);
                System.Console.WriteLine("Finished... x = {0}", x);
                return x * 2;
            };

            Task<int> first = function(5);
            Task<int> second = function(3);
            System.Console.WriteLine("First result: {0}", first.Result);
            System.Console.WriteLine("Second result: {0}", second.Result);
        }

        public async Task<int> ShowPageLengthAsync(params string[] urls)
        {
            var tasks = urls.Select(async url =>
            {
                using (var client = new HttpClient())
                {
                    return await client.GetStringAsync(url);
                }
            }).ToList();

            int total = 0;
            foreach (var task in tasks)
            {
                string page = await task;
                System.Console.WriteLine("Got page length {0}", page.Length);
                total += page.Length;
            }

            return total;
        }
    }
}

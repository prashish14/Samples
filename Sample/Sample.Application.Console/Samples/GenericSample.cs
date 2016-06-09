using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Console.Samples
{
    public class GenericSample
    {
        private List<Test> _tests;

        public GenericSample()
        {
            _tests = new List<Test>();
        }

        public void Run()
        {
            _tests.Add(new Test());
        }
    }

    public class Test
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

}

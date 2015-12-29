using System;
using System.Runtime.CompilerServices;
using System.Web.Http.Results;

namespace Sample.Application.WebApi.Controllers
{
    public class HomeController : BaseController
    {
        // GET: api/Home
        public object Get()
        {
            Employee empl = new Employee("Pasha", 22);
            string hello = empl.SayHello();

            return empl;
        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Employee(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string SayHello()
        {
            return "Hello, my name is " + this.Name + ". ";
        }
    }
}
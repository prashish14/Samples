using System;
using CompanyA;
using CompanyB;

namespace Sample.Application.Console.Samples
{
    public class VirutualMethodsTypeVersionSample
    {
        public VirutualMethodsTypeVersionSample()
        {
        }

        public void Run()
        {
            //Phone phone = new Phone();
            BetterPhone betterPhone = new BetterPhone();

            //phone.Dial();
            betterPhone.Dial();
        }
    }
}

namespace CompanyA
{
    public class Phone
    {
        public void Dial()
        {
            Console.WriteLine("call CompanyA.Phone.Dial()");
            EstablishConnection();
        }

        protected virtual void EstablishConnection()
        {
            Console.WriteLine("call CompanyA.Phone.EstablishConnection()");
        }
    }
}

namespace CompanyB
{
    public class BetterPhone : Phone
    {
        public new void Dial() //new work require
        {
            Console.WriteLine("call CompanyB.BetterPhone.Dial()");
            EstablishConnection();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("call base.Dail() from BetterPhone.Dail()");
            base.Dial();
        }

        //if use new - old method will be called, after you call base.Dail() ,,,,,,,,,,,, new doesn't override old method! it's just new method
        //if use override - old method will not be called!! after you call base.Dail()                               
        protected new void EstablishConnection()
        {
            Console.WriteLine("call CompanyB.BetterPhone.EstablishConnection()");
        }
    }
}
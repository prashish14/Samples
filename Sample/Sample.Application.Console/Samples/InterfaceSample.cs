using System;

namespace Sample.Application.Console.Samples
{
    public class InterfaceSample
    {
        public InterfaceSample ()
        {
            
        }

        public void Run()
        {
            InterfaseClass iCl = new InterfaseClass();
            IInterface iClIn = (IInterface) iCl;
            iClIn.SayHello();
            iClIn.SayGavGav();
            InterfaceStruct str = new InterfaceStruct();
            IGavGav strI = (IGavGav)str; //boxing!!! danger
            strI.SayGavGav();
        }
    }

    public class InterfaseClass : IInterface
    {
        public void SayHello() // use this implementation where it's possible!
        {
            System.Console.WriteLine("Hello!");
        }

        void IGavGav.SayGavGav() //implicit implementation IGavGav interface, you should avoid this implementation
        {
            System.Console.WriteLine("Gav gav!");
        }
    }

    public struct InterfaceStruct : IGavGav
    {
        public void SayGavGav()
        {
            System.Console.WriteLine("Gav Gav 2");
        }
    }

    public interface IInterface : IGavGav
    {
        void SayHello();
    }

    public interface IGavGav
    {
        void SayGavGav();
    }
}

using System;
using System.IO;

namespace Sample.Server.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string url = "http://localhost:12344/";
                new Sample.Application.WebApi.Server(url).Start();
                System.Console.WriteLine("Url: {0}", url);
                System.Console.WriteLine("Running... Press any key to exit");
            }
            catch (IOException)
            {
                System.Console.WriteLine("Run GruntJs previous start: 1) run NodeJs cmd 2) go to the solution directory (cd D:/Solution_Directory) 3) execute npm install");
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message.ToString());
            }
            System.Console.ReadLine();
        }
    }
}

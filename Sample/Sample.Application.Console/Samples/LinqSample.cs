using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Console.Samples
{
    public class LinqSample
    {
        public void Run()
        {
            LinqTest.PrintValues();
            LinqTest.PrintItems();
        }
    }

    public static class LinqTest
    {
        public static void PrintValues()
        {
            ArrayList list = new ArrayList(){ "First", "Second", "Third" };
            List<Car> cars = new List<Car>()
            {
                new Car(){ Name = "Citroen", MaxSpeed = 210, HasOwner = false },
                new Car(){ Name = "", MaxSpeed = 190, HasOwner = true },
                new Car(){ Name = "Ford", MaxSpeed = 310, HasOwner = true },
                new Car(){ Name = "Ferrari", MaxSpeed = 350, HasOwner = false },
                new Car(){ Name = "Mozeratti", MaxSpeed = 400, HasOwner = true },
                new Car(){ Name = "Lamborghini", MaxSpeed = 450, HasOwner = true }
            };

            var selectedCars = cars.Where(c => c.HasOwner == true)
                .OrderBy(c => c.Name)
                .Select(c => c.Name);

            foreach (var car in selectedCars)
            {
                System.Console.WriteLine("Car: {0}", car);
            }

            var strings = from string entry in list
                           select entry.Substring(0, 3);

            System.Console.WriteLine(System.Environment.NewLine);
            System.Console.WriteLine("Items:");
            foreach (var item in list)
            {
                System.Console.WriteLine("item: {0}", item);
            }
        }

        public static void PrintItems()
        {

        }
    }

    internal class Car
    {
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public bool HasOwner { get; set; }
    }
}

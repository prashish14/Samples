using System;
using System.Collections.Generic;
using System.IO;

namespace Sample.Application.Console.Samples
{
    public class LambdaExpressionSample
    {
        public void Run()
        {
            Func<string, int> returnLength = LambdaExpressionTest.GetStringLength;
            Func<string, int> returnLengthAnomius = delegate(string str) { return str.Length; }; //anomimus delegate
            Func<string, int> returnLengthLambda = (str) => { return str.Length; };
            Func<string, int> returnLengthLambda1 = (str) => str.Length;
            Func<string, int> returnLengthLambda2 = str => str.Length;

            System.Console.WriteLine("String length is: {0}", returnLength.Invoke("Pasha"));
            System.Console.WriteLine("String length is: {0}", returnLength("Pasha"));
            System.Console.WriteLine("String length is: {0}", returnLengthLambda("Pasha"));
            System.Console.WriteLine("String length is: {0}", returnLengthLambda1("Pasha"));
            System.Console.WriteLine("String length is: {0}", returnLengthLambda2("Pasha"));


            System.Console.WriteLine(System.Environment.NewLine);
            List<string> list = new List<string>() { "pasha", "anya", "dima", "katya" };
            LambdaExpressionTest.SortList<string>(list);
            foreach (var item in list)
            {
                System.Console.WriteLine(item);
            }

            List<Film> films = new List<Film>()
            {
                new Film("Pasha", 22), new Film("Anya", 19)
            };
            List<Film> newFilms = new List<Film>()
            {
                new Film() {Name="Dima", Year = 2015},
                new Film() {Name="Olya", Year = 1918},
                new Film() {Name="Kolya", Year = 1998}
            };

            System.Console.WriteLine(System.Environment.NewLine);
            LambdaExpressionTest.PrintSortedFilms(films);
        }
    }

    public static class LambdaExpressionTest
    {
        public static int GetStringLength(string str)
        {
            return str.Length;
        }

        public static List<T> SortList<T>(List<T> list) where T : class
        {
            list.Sort();
            return list;
        }

        public static void PrintSortedFilms(List<Film> films)
        {
            films.Sort((a, b) => String.Compare(a.Name, b.Name, StringComparison.CurrentCulture));
            foreach (var film in films)
            {
                System.Console.WriteLine("{0}: {1}", films.IndexOf(film), film.Name);
            }
        }
    }

    public class Film
    {
        public Film()
        {
        }

        public Film(string name, int year)
        {
            Name = name;
            Year = year;
        }

        public string Name { get; set; }
        public int Year { get; set; }
    }
}

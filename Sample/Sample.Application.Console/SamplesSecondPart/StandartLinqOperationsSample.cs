using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Console.SamplesSecondPart
{
    public class StandartLinqOperationsSample
    {
        public void Run()
        {
            string[] words = { "zero", "one", "two", "three", "four" };
            int[] numbers = { 0, 1, 2, 3, 4 };
            object[] allStrings = { "These", "are", "all", "strings" };
            object[] notAllStrings = { "Number", "at", "the", "end", 5 };

            RunTest(numbers);
            RunWordsTest(words);
            Concatenation(numbers);
            Transformation(allStrings, notAllStrings, numbers, words);
            RunSingleElementSelectSamples(words);
            SiquenceEqualTest(words);
            GenerationSample(numbers);
            GropSample(words);
            JoinSample();
            HumanCatJoinSample();
            Separation();
            Projection(words, numbers);
            ZipOperation();
            Quantificators(words);
            Filtration(words);
            EnumSample();
            SortSample();
        }

        private void RunTest(int[] numbers)
        {
            int sum = numbers.Sum();
            int count = numbers.Count();
            double average = numbers.Average();
            long longCount = numbers.LongCount();
            string upperStringNumbers = numbers.Aggregate("seed",
                (current, item) => 
                    current + item, 
                    result => result.ToUpper());
            System.Console.WriteLine("Standart linq operations...");
            System.Console.WriteLine("Sum: {0}", sum);
            System.Console.WriteLine("Count: {0}", count);
            System.Console.WriteLine("Average: {0}", average);
            System.Console.WriteLine("LongCount {0}", longCount);
            System.Console.WriteLine("Aggregate: {0}", upperStringNumbers);
        }

        private void RunWordsTest(string[] words)
        {
            string minString = words.Min();
            string maxString = words.Max();

            System.Console.WriteLine("Min string: {0}", minString);
            System.Console.WriteLine("Max string: {0}", maxString);
        }

        private void Concatenation(int[] numbers)
        {
            int[] result = numbers.Concat(new[] {2,3,4,5,6}).ToArray();
            System.Console.WriteLine("Concat result: {0}", result);
        }

        private void Transformation(object[] allStrings, object[] notAllStrings, int[] numbers, string[] words)
        {
            IEnumerable<string> stringsResult = allStrings.Cast<string>();
            IEnumerable<string> stringsResulteSame = allStrings.OfType<string>();

            IEnumerable<string> notAllStringsResult = notAllStrings.Cast<string>();
            IEnumerable<string> notAllStringsResultSame = notAllStrings.OfType<string>();

            int[] numbersArrayResult = numbers.ToArray();
            List<int> numbersListResult = numbers.ToList();

            var dictionaryResult = words.ToDictionary(w => w.Substring(0, 2));
            var lookUpResult = words.ToLookup(w => w[0]); //char, string ... ILookup

            try
            {
                var dictionaryResultSecond = words.ToDictionary(w => w[0]);
            }
            catch (Exception exeption)
            {
                System.Console.WriteLine(exeption.Message);
            }

            //AsEnumerable() AsQueryable()
        }

        private void RunSingleElementSelectSamples(string[] words)
        {
            string secondWord = words.ElementAt(2); //get element by index / if index < 0 -> ArgumentOutOfRangeException
            string tenWordOrDefault = words.ElementAtOrDefault(10);//null
            string firstWord = words.First(); //InvalidOperationException if Enumerable is empty
            string firstWordWith3Length = words.First(w => w.Length == 3);
            //string firstWordWith10Length = words.First(w => w.Length == 10);
            string lastWord = words.Last(); // get last element
            try
            {
                string single = words.Single();
                string singleOrDefault = words.Single();
                string singlePredicate = words.Single(word => word.Length == 5);
                string singlePredicateSecond = words.Single(word => word.Length == 10);
                string singlePredicateNext = words.SingleOrDefault(w => w.Length == 10);
            }
            catch (Exception exeption)
            {
                System.Console.WriteLine(exeption);
            }
        }

        private void SiquenceEqualTest(string[] words)
        {
            bool isSequenceEqual = words.SequenceEqual(new[] {"zero", "one", "two", "three", "four"});
            bool isSequenceEqualUpperCase = words.SequenceEqual(new[] {"ZERO", "ONE", "TWO", "THREE", "FOUR"});
            bool isSequenceEqualIgnoreCase = words.SequenceEqual(new[] { "ZERO", "ONE", "TWO", "THREE", "FOUR" }, StringComparer.OrdinalIgnoreCase);
        }

        private void GenerationSample(int[] numbers)
        {
            IEnumerable<int> result = numbers.DefaultIfEmpty();
            IEnumerable<int> resultDefaultIfEmpty = new int[0].DefaultIfEmpty();
            IEnumerable<int> testRange1 = Enumerable.Range(15, 2);
            IEnumerable<int> testRange2 = Enumerable.Range(25, 3); // start value, count -> 25, 26, 27
            IEnumerable<int> repeatSequence = Enumerable.Repeat(25, 3); // value, count -> 25, 25, 25
            IEnumerable<int> empty = Enumerable.Empty<int>(); //empty sequence
            System.Console.WriteLine();
        }

        private void GropSample(string[] words) //IGrouping<,>
        {
            var result = words.GroupBy(w => w.Length); // group by length
            var secondResult = words.GroupBy(word => word.Length, word => word.ToUpper());
            var thirdResult = words.GroupBy(w => w.Length, (key, g) => key + ": " + g.Count());
        }

        private void JoinSample()
        {
            string[] names = new[] {"Robin", "Ruth", "Bob", "Emma"};
            string[] colors = new[] {"Red", "Blue", "Beige", "Green"};

            List<string> list = names.Join(colors, name => name[0], color => color[0], (name, color) => name + "-" + color).ToList();
            System.Console.WriteLine("result sequence:");
            foreach(var item in list)
            System.Console.WriteLine(item);

            //Func<string, int> calc = s => s.Length;

            
        }

        private void HumanCatJoinSample()
        {
            var humans = new Human[]
            {
                new Human { Id = 1, HumanName = "Pasha"},
                new Human { Id = 2, HumanName = "Katya"},
                new Human { Id = 3, HumanName = "Vasya"},
            };

            var animals = new Animal[]
            {
                new Animal { Id = 1, AnimalName = "Mia", HumanId = 1 },
                new Animal { Id = 2, AnimalName = "Kesha", HumanId = 2 },
                new Animal { Id = 3, AnimalName = "Francisk", HumanId = 2 },
                new Animal { Id = 2, AnimalName = "Jack", HumanId = 3 }
            };

            var query = humans.Join(animals, h => h.Id, a => a.HumanId, (h, a) => new { h.Id, h.HumanName, a.AnimalName });
            var result = query.ToList();
            foreach (var item in result)
            {
                System.Console.WriteLine(item);
            }
        }

        private void Separation()
        {
            string[] words = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten"};
            IEnumerable<string> selectedWords = words.Take(2);
            IEnumerable<string> secondSequence = words.Skip(2);

            IEnumerable<string> result = words.TakeWhile(w => !w.Equals("four"));
            IEnumerable<string> rest = words.SkipWhile(w => !w.Equals("eight"));
        }

        private void Projection(string[] words, int[] numbers)
        {
            IEnumerable<int> result = words.Select(w => w.Length);
            IEnumerable<string> strings = words.Select((w, index) =>
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(index.ToString() + ": " + w);
                return sb.ToString();
            });

            IEnumerable<char> chars = words.SelectMany(w => w.ToCharArray());
            var objects = words.SelectMany(Enumerable.Repeat);
        }

        private void ZipOperation()
        {
            string[] owners = new[] {"Pasha", "Kaya", "Vasya", "Petya"};
            string[] pets = new[] {"Mia", "Kesha", "Francisk", "Bobik"};

            var query = owners.Zip(pets, (owner, pet) => owner + "-" + pet);
            var result = query.ToList();
            System.Console.WriteLine("Zip operation: ");
            foreach (var item in result)
            {
                System.Console.WriteLine(item);
            }
        }

        private void Quantificators(string[] words) //returns bool value, imediate execution
        {
            var query = words.All(word => word.Length > 3); //false
            var secondQuery = words.All(w => w.Length > 2); //true
            var thirdQuery = words.Any(); //true, because the sequence is not empty
            var fourthQuery = words.Any(w => w.Length == 6); // there is no words with length == 6
            var fivthQuery = words.Any(w => w.Length == 5); //three has length = 5
            var sixthQuery = words.Contains("FOUR"); //false
            var seventhQuery = words.Contains("three"); //true
            //use Any instead of Count, bacause Any stops when predicate is true. Count goes through all elements.
        }

        private void Filtration(string[] words)
        {
            IEnumerable<string> filtered = words.Where(w => w.Length > 3);
            IEnumerable<string> seccondFiltered = words.Where((w, index) => w.Length > index); // if true -> then add to result sequence
        }

        private void EnumSample() //deferred execution
        {
            char[] abbc = { 'a', 'b', 'b', 'c' };
            char[] cd = { 'c', 'd' };

            var abc = abbc.Distinct(); //removes repeatable elements from sequence
            var result = abbc.Intersect(cd);
            var secondResult = abbc.Union(cd);
            var thirdResult = abbc.Except(cd); //removes from first existent in second
            var fourthResult = cd.Except(abbc);
        }

        private void SortSample()
        {
            string[] words = {"b", "b", "a", "z", "d", "f", "n", "m", "o", "q", "w", "z"};
            var sorted = words.OrderBy(w => w);
            var result = words.OrderBy(w => w[0]); //by the first letter
            var lengthSorted = words.OrderBy(w => w.Length);
            var descending = words.OrderByDescending(w => w.Length);
            var lengthOrderAlpha = words.OrderBy(w => w.Length).ThenBy(w => w);
            var lengthOrderZMode = words.OrderBy(w => w.Length).ThenByDescending(w => w);
            var reverseOrder = words.Reverse();
        }
    }

    public class Human
    {
        public int Id { get; set; }
        public string HumanName { get; set; }
    }

    public class Animal
    {
        public int Id { get; set; }
        public string AnimalName { get; set; }
        public int HumanId { get; set; }
    }
}

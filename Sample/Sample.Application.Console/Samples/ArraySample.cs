using System;
using System.Collections;
using System.ComponentModel;

namespace Sample.Application.Console.Samples
{
    public class ArraySample
    {
        public void Run()
        {

        }
    }

    public class ArrayTest
    {
        public void PrintArray()
        {
            //array initializer
            int[] array = new int[] { 4, 5, 6 }; //single-dimension
            int[,] arrayXYZ = new int[2, 3] { {1, 2, 3 }, {1, 2, 3 } }; //multidimension
            int[][] arrayOfArray = new int[5][]; // not regular, jagged(array of arrays)
        }
    }
}

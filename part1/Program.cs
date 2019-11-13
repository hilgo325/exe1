using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 hillel gonen-325004414
 ilan russell-332339134
 */
namespace part1
{
    class Program
    {

        //prints a given array with spaces in between items
        static void printArr(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write("{0, -4}", arr[i]);
            Console.WriteLine();
        }

        //puts random numbers into a given array
        static void randomArr(int[] arr)
        {
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < arr.Length; i++)
                arr[i] = r.Next(18, 122);
        }

        /*
        return the absolute value of the difference
        between the parallel items from two different arrays
        */
        static int[] subtractArrs(int[] firstArr, int[] secondArr)
        {
            int size = firstArr.Length;
            if (firstArr.Length > secondArr.Length)
                size = secondArr.Length;
            int[] newArray = new int[size];
            for (int i = 0; i < size; i++)
            {
                if (firstArr[i] > secondArr[i])
                    newArray[i] = firstArr[i] - secondArr[i];
                else
                    newArray[i] = secondArr[i] - firstArr[i];
            }
            return newArray;
        }
        static void Main(string[] args)
        {
            int[] firstArray = new int[20];
            int[] secondArray = new int[20];
            int[] newArray = new int[20];

            randomArr(firstArray);
            randomArr(secondArray);
            newArray = subtractArrs(firstArray, secondArray);

            printArr(firstArray);
            printArr(secondArray);
            printArr(newArray);

            Console.Read();
        }
    }
}


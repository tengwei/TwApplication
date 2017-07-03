using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 3, 5, 2, 8, 2, 9, 45, 233, 87, 978, 2323, 344, 5};
            //array=BubbleSorting1(array);
            //array = SimpleBubbleSorting(array);
            array = simple_insertSort(array, array.Length);
            


            for (int i=0;i< array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
            Console.ReadLine();
        }

        static int[] BubbleSorting1(int[] array)
        {
            
            int length = array.Length;
            if (length < 2)
            {
                return array;
            }
            for (int i=0;i < length - 1; i++)
            {
                for(int j=i+1;j< length; j++)
                {
                    if(array[i] < array[j])
                    {
                        int temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }

        static int[] SimpleBubbleSorting(int[] array)
        {
            for(int i=1;i< array.Length; i++)
            {
                int j = i;
                while (j > 0 && array[j] < array[j - 1])
                {
                    int temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                    j--;
                }
            }
            return array;
        }

        static int[] simple_insertSort(int[] array, int n)
        {
            int i, j;
            int temp;
            for (i = 1; i < n; ++i)
            {
                temp = array[i];
                j = i - 1;
                while (j >= 0 && temp < array[j])
                {
                    array[j + 1] = array[j];
                    --j;
                }
                array[j + 1] = temp;
            }
            return array;
        }
    }


}

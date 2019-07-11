using System;

namespace Algorithms_Lesson_3
{

    // Савенко В.
    class Program
    {


        static void Main(string[] args)
        {
            //Линейный поиск
            int[] array = FillArray(10);
            ShowArray(array);

            string ElementFound = SearchEl(array, 2, 0) != -1 ? "Елемент найден!" :"Елемент не найден!";
            Console.WriteLine(ElementFound);
        }


        // ЛИНЕЙНЫЙ ПОИСК В ВИДЕ РЕКУНСРИИ
        public static int[] FillArray(int size)
        {
            Random r1 = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = r1.Next(0, 10);
            }
            return array;
        }

        public static void ShowArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine((i + 1) + ": " + array[i]);
            }
        }

        public static int SearchEl(int[] array,int el,int index)
        {
            if (array.Length != index)
            {
                if (array[index]==el)
                 {
                          return index;
                 }
                else
                {
                
                    index++;
                    return SearchEl(array, el, index);
               
                 }
            }
            else
                return -1;
        }
    }
}

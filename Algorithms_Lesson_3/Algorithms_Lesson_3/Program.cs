using System;

namespace Algorithms_Lesson_3
{

    // Савенко В.
    // Линейный поиск в виде рекурсии и пузырьковая сортировка
    class Program
    {


        static void Main(string[] args)
        {
            //Линейный поиск
            int[] array = FillArray(10);
            ShowArray(array);

            string ElementFound = SearchEl(array, 2, 0) != -1 ? "Елемент найден!" :"Елемент не найден!";
            Console.WriteLine(ElementFound);

            int[] array2 = FillArray(10);

            Console.WriteLine("Колличество операций обычной сортировки: "+ BumbleSort(array).ToString());

            Console.WriteLine("Колличество оптимизированной сортировки: " + BumbleSortOptimized(array2).ToString());

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
                Console.Write(array[i]+", ");
            }
            Console.Write("\n");
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

        public static void Swap(ref int a , ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static int BumbleSort(int[] array)
        {
            int taskCount = 0; 
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
                taskCount++;
            }
            return taskCount;
        }

        // ПУЗЫРЬКОВА СОРТИРОВКА ОПТИМИЗИРОВАННАЯ
        // ОСНОВАННАЯ НА ТОМ, ЧТО ЕСЛИ МАССИВ СОРТИРОВАН НА БОЛЕЕ РАННИЪ ЦИКЛАХ, ТО НЕТ СМЫСЛА ВЫПОЛНЯТЬ ДОКОНЦА
        public static int BumbleSortOptimized(int[] array)
        {
            int taskCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                bool isChanged = false;
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);

                        //Зафиксировали перестановку элементов
                        isChanged = true;
                    }
                }
                taskCount++;
                //Если факт перестановки элементов не был зафиксирован
                if (isChanged == false)
                    break; //Прерываем цикл (прекращаем сортировку)
            }
            return taskCount;
        }
    }
}

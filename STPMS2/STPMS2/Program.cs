using System;
using System.Text;

namespace STPMS2
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hell" +
                "o World!");

            Console.WriteLine("\t\nTask 1-a!");
            bool name1 = true;
            Console.WriteLine($"1) переменная типа bool: {name1}");

            byte name2 = 2;
            Console.WriteLine($"2) переменная типа byte: {name2}");

            sbyte name3 = -2;
            Console.WriteLine($"3) переменная типа sbyte: {name3}");

            var name4 = new[]
                  {
                    'm','a','r','k'
                };

            Console.WriteLine($"4) переменная типа char: {string.Join(" ", name4)}");

            decimal name5 = 2.1m;
            Console.WriteLine($"5) переменная типа decimal: {name5}");

            double name6 = 1.0;
            Console.WriteLine($"6) переменная типа double: {name6}");

            float name7 = 3_000.5F;
            Console.WriteLine($"7) переменная типа float: {name7}");

            int name8 = 125;
            Console.WriteLine($"8) переменная типа int: {name8}");

            uint name9 = 125;
            Console.WriteLine($"9) переменная типа uintt: {name9}");

            long name10 = 125;
            Console.WriteLine($"10) переменная типа long: {name10}");

            ulong name11 = 125;
            Console.WriteLine($"11) переменная типа ulong: {name11}");

            short name12 = 125;
            Console.WriteLine($"12) переменная типа short: {name12}");

            ushort name13 = 125;
            Console.WriteLine($"13) переменная типа ushort: {name13}");

            Console.WriteLine("\t\nTask 1-b!");
            Byte newname1 = (Byte)name3;
            Int16 newname2 = (Int16)name2;
            SByte newname3 = (SByte)name7;
            Int64 newname4 = (Int64)name12;
            Double newname5 = (Double)name13;

            Int32 newname6 = name12;
            Int64 newname7 = newname6;
            Single newname8 = newname6;
            Double newname9 = newname6;
            Decimal newname10 = name8;
           
            Console.WriteLine("\t\nTask 1-c!");
            Int32 y = 5;
            Object o = y;
            byte m = (byte)(int)o;

            Console.WriteLine("\t\nTask 1-d!");
            var v1 = 5;
            Console.WriteLine($" неявно типизированная переменная: {v1.GetType()}");//

            Console.WriteLine("\tTask 1-e!");
            int? p = null;
            //Nullable<int> p = 25;
            Console.WriteLine($"Nullable: {p}");

            Console.WriteLine("\t\nTask 1-f!");
            var v2 = 5;
            v2 = 6;
            Console.WriteLine($"Нетипизированная: {v2}");

            Console.WriteLine("\t\nTask 2-a!");
            String path1, path2;
            path1 = "Лабораторная работа 1";
            path2 = "Лабораторная работа 2";
            Console.WriteLine($"Cтроковый литерал 1: {path1}");
            Console.WriteLine($"Cтроковый литерал 2: {path2}");
            Console.WriteLine("Строки одинаковые? {0}", String.Compare(path1, path2) == 0 ? "true" : "false");

            Console.WriteLine("\t\nTask 2-b!");
            String str1, str2, str3, str4;
            str1 = "первая";
            str2 = "вторая";
            str3 = "третья";
            str4 = " ";
            Console.WriteLine($"первая строка: {str1}");
            Console.WriteLine($"вторая строка: {str2}");
            Console.WriteLine($"третья строка: {str3}");
            Console.WriteLine($"Сцепление: { String.Concat(str1, str2)}");
            Console.WriteLine($"Копирование: {str2 = str1}");
            Console.WriteLine($"Выделение подстроки из строки 1 с 3-ей позиции: {str4 = str1.Substring(3)}");
            Console.WriteLine($"Разделение строки на слова: {str1}");
            String s = "Степанюк Марк Александрович";
            String[] words = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Исходная строка: {s}");
            Console.WriteLine($"Слова: {words[0]}, {words[1]}, {words[2]} ");
            Console.WriteLine($"Вставки подстроки в заданную позицию: {str2 = str1.Insert(4, str3.Substring(3))}");
            str2 = str2.Substring(3);
            Console.WriteLine($"Удаление заданной подстроки: {str1 = str1.Remove(3)}");

            Console.WriteLine("\nTask 2-c!");
            String str5 = "";
            bool flag = String.IsNullOrEmpty(str5);
            Console.WriteLine($"Строка нулевая?: {flag}" );

            Console.WriteLine("\nTask 2-d!");
            StringBuilder sb = new StringBuilder("new", 50);

            sb.Append(new char[] { 's', 't', 'r' });
            Console.WriteLine($"Строка, основанная на  StringBuilder?: {sb }");

            Console.WriteLine("\nTask 3-a!\nдвумерный массив: \n");
            int[,] array1 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.WriteLine($"{array1[i, j]} ");
                }

            }
            Console.WriteLine($"{array1[0, 0]} {array1[0, 1]} {array1[0, 2]} ");
            Console.WriteLine($"{array1[1, 0]} {array1[1, 1]} {array1[1, 2]} ");

            Console.WriteLine("\nTask 3-b!");
            Console.WriteLine($"Одномерный массив строк");
            String[] collection = new String[] { "first", "second", "third" };

            for (int i = 0; i < collection.Length; ++i)
            {
                Console.WriteLine(collection[i]);
            }
            Console.WriteLine($"Длинна массива: {collection.Length}");

            Console.WriteLine($"Введите номер элемента, который нужно поменять: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Введите новую строку: ");
            string line = Console.ReadLine();
            collection[number] = line;
            Console.WriteLine($"Новый массив строк");
            for (int i = 0; i < collection.Length; ++i)
            {
                Console.WriteLine(collection[i]);
            }

            Console.WriteLine("\nTask 3-c!");
            int[][] numbers = new int[3][];
            numbers[0] = new int[2] { 1, 2 };
            numbers[1] = new int[3] { 45, 34, 23 };
            numbers[2] = new int[4] { 25, 7, 9, 0 };
            foreach (int[] row in numbers)
            {
                foreach (int number2 in row)
                {
                    //int number3 = Convert.ToInt32(Console.ReadLine());
                    Console.Write($"{number2} \t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nTask 3-d!");
            var array2 = new object[4];

            for (int i = 0; i < array2.Length; ++i)
            {
                array2[i] = Console.ReadLine();
            }
            Console.WriteLine($"Итоговый массив массива:");
            for (int i = 0; i < array2.Length; i++)
            {
                Console.WriteLine(array2[i]);
            }
            Console.WriteLine($"Длинна массива: {array2.Length}");

            Console.WriteLine("\nTask 4-a!");
            ValueTuple<int, string, char, string, ulong> student = (18, "Mark", 'm', "Stepaniuk", 176);

            Console.WriteLine("\nTask 4-b!");
            Console.WriteLine($" {student}");

            Console.WriteLine("\nTask 4-c!");
            Console.WriteLine(student.Item1);
            Console.WriteLine(student.Item3);
            Console.WriteLine(student.Item4);

            var a = student.Item1;
            var b = student.Item2;
            var c = student.Item3;
            var d = student.Item4;
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            var (first, _, _, fourth, fifth) = student;


            Console.WriteLine("\nTask 5!");
            int[] Arrai = { 3, 7, 9, 25 };
            Console.WriteLine(task5(Arrai, "mark"));
            task5(Arrai, "abcd");

            Console.WriteLine("\nTask 6_1!");
            task6_1();

            Console.WriteLine("\nTask 6_2!");
            task6_2();




            (int, int, int, char) task5(int[] arrA, string strA)
            {
                int max, min, sum = 0;
                min = max = arrA[0];
                foreach (int i in arrA)
                {
                    if (i < min)
                    {
                        min = i;
                    }
                }
                foreach (int i in arrA)
                {
                    if (i > max)
                    {
                        max = i;
                    }
                }
                foreach (int i in arrA)
                {
                    sum += i;
                }
                (int, int, int, char) TupleB = (min, max, sum, strA[0]);
                return TupleB;
            }
            void task6_1()
            {
                checked
                {
                    int A = 2_147_483_647;
                    A++;
                    Console.WriteLine(A);
                }
            }
            void task6_2()
            {
                unchecked
                {
                    int A = 2_147_483_647;
                    A++;
                    Console.WriteLine(A);
                }
            }
            // 10, 33, 35
            //Всевозможные определения двумерных массивов 
            int[,] nums1;
            int[,] nums2 = new int[2, 3];
            int[,] nums3 = new int[2, 3] { { 0, 1, 2 }, { 3, 4, 5 } };
            int[,] nums4 = new int[,] { { 0, 1, 2 }, { 3, 4, 5 } };
            int[,] nums5 = new[,] { { 0, 1, 2 }, { 3, 4, 5 } };
            int[,] nums6 = { { 0, 1, 2 }, { 3, 4, 5 } };

            //
           
                int[] numbers1 = { 4, 7, 13, 20, 33, 23, 54 };
                int s1 = 0;

                foreach (int el in numbers1)
                {
                    s1 += el;
                }
                Console.WriteLine(s1);
                Console.ReadKey();
            












        }



    }
}


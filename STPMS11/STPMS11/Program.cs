using System;
using System.Collections.Generic;
using System.Linq;

namespace STPMS11
{
    class student : IComparable<student>
    {
        public string name;
        public string faculty;
        public int exam;
        public int CompareTo(student a)
        {
            return this.faculty.CompareTo(a.faculty);
        }
    }
    class decan : IComparable<decan>
    {
        public string name;
        public string faculty;
        public int CompareTo(decan a)
        {
            return this.faculty.CompareTo(a.faculty);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("         ------------------");
            Console.WriteLine("             Задание 1");
            Console.WriteLine("         ------------------");
            string[] months = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            string[] mass = { "Январь", "Февраль", "Июнь", "Июль", "Август", "Декабрь" };
            int n = 6;
            var query1 = from p in months
                         where p.Length == 6
                         select p;

            IEnumerable<string> rezult1 = months.Where(p => p.Length < 6).Select(p => p);

            Console.WriteLine("------------------");
            Console.WriteLine("     Запрос 1");
            Console.WriteLine("------------------");

            Console.WriteLine("Условие: месяцы, состоящие из n букв");
            Console.WriteLine();
            foreach (string s in query1)//запрос выбирающий последовательность месяцев с длиной строки равной n
                Console.WriteLine(s);

            var query10 = months.Intersect<string>(mass);//запрос возвращающий только летние и зимние месяцы
            Console.WriteLine();
            Console.WriteLine("------------------");
            Console.WriteLine("     Запрос 2");
            Console.WriteLine("------------------");

            Console.WriteLine("Условие: летние и зимние месяцы");
            Console.WriteLine();
            foreach (string s in query10)
                Console.WriteLine(s + ".");
            var query11 = from p in months
                          orderby p//упорядочивает элементы по возрастанию
                          select p;
            Console.WriteLine();
            Console.WriteLine("------------------");
            Console.WriteLine("     Запрос 3");
            Console.WriteLine("------------------");

            Console.WriteLine("Условие: месяцы в алфавитном порядке");
            Console.WriteLine();
            foreach (string s in query11)//запрос вывода месяцев в алфавитном порядке
                Console.WriteLine(s + "/");
            var query2 = from p in months
                         where p.Length >= 4 & p.Contains("ь")
                         select p;
            Console.WriteLine();
            Console.WriteLine("------------------");
            Console.WriteLine("     Запрос 4");
            Console.WriteLine("------------------");

            Console.WriteLine("Условие: месяцы, содержащие букву (ь) и длиной не менее 4-ч букв");
            Console.WriteLine();
            foreach (string s in query2)//запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4-х..
                Console.WriteLine(s);

            Console.WriteLine("         ------------------");
            Console.WriteLine("             Задание 3");
            Console.WriteLine("         ------------------");
            List<Train> t = new List<Train>();
            t.Add(new Train() { H = 12, M = 12, Time = "утро", Town = "Minsk" });
            t.Add(new Train() { H = 9, M = 12, Time = "обед", Town = "MG" });
            t.Add(new Train() { H = 1, M = 52, Time = "утро", Town = "Gomel" });
            t.Add(new Train() { H = 9, M = 12, Time = "ночь", Town = "Pinsk" });
            t.Add(new Train() { H = 1, M = 52, Time = "обед", Town = "Minsk" });
            t.Add(new Train() { H = 17, M = 37, Time = "обед", Town = "Gomel" });
            t.Add(new Train() { H = 6, M = 19, Time = "утро", Town = "Minsk" });
            t.Add(new Train() { H = 23, M = 51, Time = "утро", Town = "Pinsk" });

            Console.WriteLine("------------------");
            Console.WriteLine("     Запрос 1");
            Console.WriteLine("------------------");

            Console.WriteLine("Условие: Поезда, следующие до - Minsk");
            Console.WriteLine();
            string m = "Minsk";
            var query12 = from p in t
                          where p.Town == m
                          select p;

            foreach (Train q in query12)
                Console.WriteLine(q.ToString());

            int k = 9;
            var query6 = from p in t
                         where p.H == k
                         select p;
            Console.WriteLine();
            Console.WriteLine("------------------");
            Console.WriteLine("     Запрос 2");
            Console.WriteLine("------------------");

            Console.WriteLine("Условие: Поезда, следующий в 9:00");
            Console.WriteLine();
            foreach (Train q in query6)
                Console.WriteLine(q.ToString());
            var query7 = from Train in t
                         group Train by Train.Time;
            Console.WriteLine();
            Console.WriteLine("------------------");
            Console.WriteLine("     Запрос 3");
            Console.WriteLine("------------------");

            Console.WriteLine("Условие: Поезда по группам");
            Console.WriteLine();
            foreach (IGrouping<string, Train> c in query7)
            {
                Console.WriteLine(c.Key);
                foreach (Train q in c)
                    Console.WriteLine(q.ToString());
            }
            //Train query8 = t.Min();
            //Console.WriteLine("------------------3");
            //Console.WriteLine(query8.ToString());
            var query9 = from Train in t

                         orderby Train.Town
                         select Train;
            Console.WriteLine();
            Console.WriteLine("------------------");
            Console.WriteLine("     Запрос 4");
            Console.WriteLine("------------------");

            Console.WriteLine("Условие: Поезда отсортированы по городам в алфавитном порядке");
            Console.WriteLine();
            foreach (object s in query9)
                Console.WriteLine(s);
            Console.WriteLine("         ------------------");
            Console.WriteLine("             Задание 4");
            Console.WriteLine("         ------------------");

            Console.WriteLine("         ------------------");
            Console.WriteLine("             Задание 5");
            Console.WriteLine("         ------------------");
            student[] st = new student[] { new student { name = "Mark", faculty = "FIT", exam = 5 }, new student { name = "Sasha", faculty = "PIM", exam = 9 }, new student { name = "Mark", faculty = "FIT", exam = 10 } };
            decan[] dec = new decan[] { new decan { name = "Шиман", faculty = "FIT" }, new decan { name = "noname", faculty = "PIM" } };
            var ss = from student in st
                     group student by student.faculty into studentgroup
                     select new { Group = studentgroup.Key, count = studentgroup.Count() };
            foreach (var s in ss)
            {
                Console.WriteLine(s.Group + "-" + s.count);
            }
            var jn = from s in st
                     join d in dec on s.faculty equals d.faculty
                     select new { decanName = d.name, facultyName = d.faculty, studentName = s.name };
            foreach (var j in jn)
                Console.WriteLine(j.decanName + " " + j.facultyName + " " + j.studentName);
        }
    }
}
//Агрегация(Count, Min, Max)
//Преобразование(Cast, ofType, ToArray, ToList,
//ToDictionary)
//Конкатенация(Concat)
//Элемент(Last, First, Single, ElemetAt + Default)
//Множество(Except, Distinct, Union)

//При отложенном выполнении LINQ-выражение не выполняется, пока не будет произведена итерация или перебор по выборке

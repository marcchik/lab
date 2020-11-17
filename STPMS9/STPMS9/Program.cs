using System;
using System.IO;
using System.Collections.Generic;

namespace ООП9
{
    public delegate string StringFormat(ref string str);
    class Program
    {
        delegate void Hello();

        class Programmist // ---- Класс-источник события ---------
        {
            public event EventHandler Delete; // Описание соб. станд. типа
            public void CommandDelete() // Метод, инициирующий событие
            {
                Console.WriteLine("Удалено!");
                Console.WriteLine();
                if (Delete != null)
                    Delete(this, null);
            }
            public event EventHandler Mutate; // Описание соб. станд. типа
            public void CommandMutate() // Метод, инициирующий событие
            {
                Console.WriteLine("Мутировано!");
                Console.WriteLine();
                if (Mutate != null)
                    Mutate(this, null);
            }
        }
        class Leg // ------- Класс-наблюдатель ------------
        {
            public void Show(object sender, EventArgs e)
            {
                Console.WriteLine("Исходный список!"); // Обработчик соб-я
                List<Person> people = new List<Person>(3);
                people.Add(new Person() { Name = "Том" });
                people.Add(new Person() { Name = "Билл" });
                people.Add(new Person() { Name = "Джон" });
                people.Add(new Person() { Name = "Артур" });


                foreach (Person p in people)
                {
                    Console.WriteLine(p.Name);
                }
                Console.WriteLine();
            }
            public void Mix(object sender, EventArgs e)
            {
                Console.WriteLine("Перемешивание списка!"); // Обработчик соб-я
                List<Person> people = new List<Person>(3);
                people.Add(new Person() { Name = "Джон" });
                people.Add(new Person() { Name = "Том" });
                people.Add(new Person() { Name = "Артур" });
                people.Add(new Person() { Name = "Билл" });
                people.RemoveAt(1);


                foreach (Person p in people)
                {
                    Console.WriteLine(p.Name);
                }
                Console.WriteLine();
            }
            public void Delete1(object sender, EventArgs e)
            {
                Console.WriteLine("Удаление первого элемента!"); // Обработчик соб-я
                List<Person> people = new List<Person>(3);
                people.Add(new Person() { Name = "Том" });
                people.Add(new Person() { Name = "Билл" });
                people.Add(new Person() { Name = "Джон" });
                people.Add(new Person() { Name = "Артур" });
                people.RemoveAt(0);


                foreach (Person p in people)
                {
                    Console.WriteLine(p.Name);
                }
                Console.WriteLine();
            }
            public void Add(object sender, EventArgs e)
            {
                Console.WriteLine("Добавление в конец списка элемента!"); // Обработчик соб-я
                List<Person> people = new List<Person>(3);
                people.Add(new Person() { Name = "Том" });
                people.Add(new Person() { Name = "Билл" });
                people.Add(new Person() { Name = "Джон" });
                people.Add(new Person() { Name = "Артур" });
                people.Add(new Person() { Name = "Mark" });
                people.RemoveAt(0);


                foreach (Person p in people)
                {
                    Console.WriteLine(p.Name);
                }
                Console.WriteLine();
            }
        }
        class Person
        {
            public string Name { get; set; }

        }
        class Class1
        {
            static void Main()
            {

                Programmist s = new Programmist();
                Leg o1 = new Leg();
                Leg o2 = new Leg();
                Leg o3 = new Leg();
                Leg people = new Leg();
                s.Delete += o1.Show; // регистрация обработчика
                s.Delete += o1.Mix; // регистрация обработчика
                s.Delete += o1.Delete1;
                s.Delete += o1.Add;
                s.Mutate += o1.Show;
                s.CommandDelete();
                s.CommandMutate();
                Console.ReadLine();

                //делегаты
                Func<int, int> retFunc = Factorial;
                int n1 = GetInt(6, retFunc);
                Console.WriteLine(n1);  // 720

                int n2 = GetInt(6, x => x * x);
                Console.WriteLine(n2); // 36

                Console.Read();

               
                Action<int, int> op;
                op = Add;
                Operation(10, 6, op);
                op = Substract;
                Operation(10, 6, op);

                Console.Read();

                Programist acc = new Programist();
                acc.Vvod += DisplayMessage; //добавление обработчика события
                acc.Delete += DisplayMessage;
                acc.Modify += DisplayMessage;
                acc.Replace += DisplayMessage;
                acc.Put(Console.ReadLine());
                acc.Redact(acc.Slovo);
                acc.Redact1(acc.Slovo);
                acc.Replacer(acc.Slovo);
                Console.Read();



            }
            private static void DisplayMessage(string message)
            {
                Console.WriteLine(message);
            }
        }

        static int GetInt(int x1, Func<int, int> retF)
        {
            int result = 0;
            if (x1 > 0)
                result = retF(x1);
            return result;
        }
        static int Factorial(int x)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            return result;
        }

        static void Operation(int x1, int x2, Action<int, int> op)
        {
            if (x1 > x2)
                op(x1, x2);
        }

        static void Add(int x1, int x2)
        {
            Console.WriteLine("Сумма чисел: " + (x1 + x2));
        }

        static void Substract(int x1, int x2)
        {
            Console.WriteLine("Разность чисел: " + (x1 - x2));
        }
    }
    
    class Programist

    {
        public delegate void AccountHandler(string message);
        public event AccountHandler Delete;
        public event AccountHandler Modify;
        public event AccountHandler Vvod;
        public event AccountHandler Replace;
        public Programist()
        {
            Console.WriteLine("Введите слово:");
        }
        public string Slovo { get; private set; }
        public void Put(string slovo)
        {
            Slovo = slovo;
            Vvod.Invoke($"Введенное слово: {slovo}");
        }
        public void Redact(string slovo)
        {
            slovo = slovo.Remove(0, 1);
            Delete.Invoke($"Удаление: {slovo}");
        }
        public void Redact1(string slovo)
        {
            slovo = slovo.Replace("k", "s");
            Modify.Invoke($"Мутирование: {slovo}");
        }
        public void Replacer(string slovo)
        {
            slovo = slovo.Replace(",", String.Empty);
            slovo = slovo.Replace(".", String.Empty);
            slovo = slovo.Replace("/", String.Empty);
            slovo = slovo.Replace("!", String.Empty);
            slovo = slovo.Replace("?", String.Empty);
            slovo = slovo.Replace(":", String.Empty);
            slovo = slovo.Replace(";", String.Empty);
            Replace.Invoke($"Удаление знаков препинания: {slovo}");
        }
    }
}
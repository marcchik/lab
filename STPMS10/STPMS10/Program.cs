using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace STPMS10
{
   
    class Student
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }
        public Student(string str)
        {
            Name = str;
        }
    }
    class Program
    {
        //static BlockingCollection<int> bc;

       
           
        

        static void Main(string[] args)
        {
            //bc = new BlockingCollection<int>(4);


            //
            //необобщенная коллекция ArrayList

            ArrayList list = new ArrayList();

            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                list.Add(rand.Next(25));
            }
            string stroke = "BSTU";
            string name = "Mark";
            object student = name;
            list.Add(stroke);
            list.Add(student);

            Console.WriteLine("ArrayList: ");

            foreach (object o in list)
            {
                Console.Write(o + "; ");
            }
            Console.WriteLine($"Количество элементов: {list.Count}");
            Console.WriteLine();
            Console.WriteLine("Введите номер элемента, который хотите удалить: ");
            int n = Convert.ToInt32(Console.ReadLine());

            // удаляем элемент
            list.RemoveAt((n - 1));
            foreach (object o in list)
            {
                Console.Write(o + "; ");
            }
            Console.WriteLine();

            Console.WriteLine("Введите элемент, номер которого хотите найти: ");


            string find = Console.ReadLine();

            //// поиск
            bool g = false;
            int k = -1;
            for (int i = 0; i < list.Count; i++)
            {
                if (find == list[i].ToString())
                {
                    g = true;
                    k = i + 1;
                }

            }
            if (g == true) Console.WriteLine("Этот элемент имеет индекс " + (k));
            else Console.WriteLine("Такого элемента нет!");
            bool con = list.Contains("Mark");
            Console.WriteLine("В коллекции содержится элемент Mark: " + con);
            //////////////////////////////////////////////////////////////////
            //Задание 1
            ArrayList arr = new ArrayList();
            Student s1 = new Student("Вова");
            for (int i = 0; i < 5; i++)
                arr.Add(i);
            arr.Add("string");
            arr.Add(s1);
            arr.Remove(s1);
            Console.WriteLine("///");
            Console.WriteLine(arr.Count);
            Console.WriteLine("///");
            foreach (object s in arr)
                Console.WriteLine(s.ToString());
            if (arr.Contains(0))
                Console.WriteLine("Да");
            //Task 1
            
            Game game = new Game();
    
            foreach (var day in game)
            {
                Console.WriteLine(day);
            }
            Console.WriteLine();

            //Task 2
            SortedList<int, char> sort = new SortedList<int, char>();
            sort.Add(0, 'a');
            sort.Add(1, 'v');
            sort.Add(5, ' ');
            sort.Add(99, '9');
            sort.Add(-10, '-');
            foreach (int a in sort.Keys)
                Console.WriteLine("Ключ: [" + a + "], Значение: " + sort[a]);
            int m = 3;
            for (int i = 0; i < m; i++)
                sort.Remove(sort.Keys[i]);
            sort.Add(2, '2');
            sort.Add(3, 'q');
            List<char> lst = new List<char>();
            foreach (int a in sort.Keys)
                lst.Add(sort[a]);
            foreach (char a in lst)
                Console.WriteLine("Значение: " + a);
            if (lst.Contains(' '))
                Console.WriteLine("Да");
            Console.WriteLine();
            //Task 3 
            SortedList<int, Engine> srt = new SortedList<int, Engine>();
            Engine e1 = new Engine("Audi", 300);
            Engine e2 = new Engine("Reno", 100);
            Engine e3 = new Engine("BMV", 400);
            Engine e4 = new Engine("Tesla", 300);
            srt.Add(1, e1);
            srt.Add(2, e2);
            srt.Add(3, e3);
            srt.Add(4, e4);
            n = 2;
            for (int i = 0; i < n; i++)
                sort.Remove(srt.Keys[i]);
            srt.Add(6, e1);
            srt.Add(9, e2);
            List<Engine> l = new List<Engine>();
            foreach (int a in srt.Keys)
                l.Add(srt[a]);
            foreach (Engine a in l)
                Console.WriteLine("Значение: " + a.ToString());
            if (l.Contains(e1))
                Console.WriteLine("Да");
            Console.WriteLine();
            //Task Создайте объект наблюдаемой коллекции ObservableCollection<T>
            ObservableCollection<Engine> eng = new ObservableCollection<Engine>();
            eng.CollectionChanged += CollectionChange;
            eng.Add(e1);
            eng.Add(e2);
            eng.Add(e3);
            eng.Add(e4);
            eng.Remove(e3);
            Console.WriteLine();
        }
        private static void CollectionChange(object obj, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Console.WriteLine($"Добавлен {e.NewItems[0].ToString()}");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Console.WriteLine($"Удалён {e.OldItems[0].ToString()}");
                    break;
            }
        }

    }
    //5 8

    public interface IEnumerable
    {
        IEnumerator GetEnumerator();
    }
    public class Game : IEnumerable
    {

        string[] games = { "1. Star Wars", "2. Звездные войны", "3. Devil May Cry 3", "4. Warhammer 40,000",
                         "5. Boulder Dash II", "6. Divinity", "7. Terraria" };
        public IEnumerator GetEnumerator()
        {
            return games.GetEnumerator();
        }
       
    }

    
}

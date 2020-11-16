using STPMS5;
using System;
using System.Collections.Generic;
using System.Text;

namespace STPMS6
{
    class Prog
    {
      
    }


    public partial class Car : Vehicle
    {
        enum model
        {
            bmw,
            audi,
            mercedes,
            opel
        }
        public int number;
        public override void metod()
        {
            Console.WriteLine("Метод для абстрактного класса");
        }
        public override void Move()//переопределяем метод "движение" класса-родителя
        {
            Console.WriteLine("Машина движется.");
        }
    }
}

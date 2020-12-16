using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;


namespace STPMS12
{
    static class library
    {
        private static void FWriter(StreamWriter f, string str)
        {
            f.WriteLine(str);
        }
        public static void ToFile(Type t)
        {
            StreamWriter a = new StreamWriter("classInfo.txt");
            bool IS = t.IsSealed, II = t.IsInterface, IC = t.IsClass, IArr = t.IsArray, IA = t.IsAbstract, IE = t.IsEnum;
            FWriter(a, $"Общие сведения: ");
            FWriter(a, $"FullName:   [{t.FullName}]");
            FWriter(a, $"Name:   [{t.Name}]");
            FWriter(a, $"BaseType:   [{t.BaseType}]");
            FWriter(a, $"IsSealed:  [{IS}]");
            FWriter(a, $"IsInterface:   [{II}]");
            FWriter(a, $"IsClass:   [{IC}]");
            FWriter(a, $"IsAbstract:    [{IA}]");
            FWriter(a, $"IsEnum:    [{IE}]");
            FWriter(a, $"IsArray:   [{IArr}]");
            MethodInfo[] m = t.GetMethods();
            PropertyInfo[] p = t.GetProperties();
            ConstructorInfo[] c = t.GetConstructors();
            FieldInfo[] f = t.GetFields();
            Type[] i = t.GetInterfaces();
            FWriter(a, "Методы:");
            foreach (var s in m)
                FWriter(a, $"    [{s.ToString()}]");
            FWriter(a, "Свойства:");
            foreach (var b in p)
                FWriter(a, $"   [{b.ToString()}]");
            FWriter(a, "Конструкторы:");
            foreach (var s in c)
                FWriter(a, $"   [{s.ToString()}]");
            FWriter(a, "Поля:");
            foreach (var s in f)
                FWriter(a, $"   [{s.ToString()}]");
            FWriter(a, "Интерфейсы:");
            foreach (var s in i)
                FWriter(a, $"   [{s.ToString()}]");
            FWriter(a, "Задание 'e':");
            foreach (var s in m)
            {
                var MethodParams = s.GetParameters();
                foreach (var k in MethodParams)
                    if (k.ParameterType == typeof(user))
                        FWriter(a, $"   [{s.Name}]");
            }
           // Assembly asm = Assembly.LoadFrom("Data.exe");
           // Type typ = asm.GetType("Data.Program");
            // создаем экземпляр класса Program
           // object obj = Activator.CreateInstance(typ);
            // получаем метод GetArray
           // MethodInfo method = typ.GetMethod("GetArray");
            // вызываем метод, передаем значения для параметров и получаем
            //object result = method.Invoke(obj, new object[] { 6, 100, 3 });
           // Console.WriteLine((result));

            a.Close();
        }
        public static void Runtimemethod(Type t, string method)
        {

            StreamReader sr = new StreamReader("message.txt");
            object obj = Activator.CreateInstance(t);
            string r;
            r = sr.ReadToEnd();
            MethodInfo m = t.GetMethod(method);
            m.Invoke(obj, new object[] { r });
        }
    }
    static class Reflector
    {
        static public void Method(object obj)
        { }
        static public void Field(object obj)
        { }
        static public void Interfece(object obj)
        { }
        static public void MethodForType(object obj, Type parametr)
        { }
        static public void Voke(object obj, string methode)
        { }
       
        public static void Create(Type t, string method)
        {

            StreamReader sr = new StreamReader("message.txt");
            object obj = Activator.CreateInstance(t);
            string r;
            r = sr.ReadToEnd();
            MethodInfo m = t.GetMethod(method);
            m.Invoke(obj, new object[] { r });
        }
    }
}
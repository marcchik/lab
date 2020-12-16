using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;


namespace STPMS13
{
    class Program
    {
        static void Main(string[] args)
        {

            StreamWriter file = SMALog.CreateWriter("smalogfile.txt");
            SMADiskInfo.InfoDisk(file); Console.WriteLine();
            SMAFileInfo.FullDirection(file, "smalogfile.txt");
            SMADirInfo.CreationTime(file, "..");
            SMADirInfo.FileCount(file, "..");
            SMADirInfo.DirCount(file, "..");
            SMADirInfo.ParentsCount(file, ".."); Console.WriteLine();
            SMAFileManager.FileSubdir(file, "D:/");
            SMAFileManager.Part1(file);
            SMAFileManager.Part2(file);
            SMAFileManager.Part3(file);
            file.Close();

            Console.ReadKey();
        }
    }
    //1. Создать класс XXXLog
    //Класс XXXLog: работа с текстовым файлом,
    //в который записываются все действия пользователя и
    //соответственно методами записи в текстовый файл, чтения, поиска нужной информации.

    class SMALog

    {
        //метод создания объекта класса StreamWriter для записи в текстовый файл
        public static StreamWriter CreateWriter(string str)
        {
            StreamWriter writer = new StreamWriter(str);
            return writer;
        }
        //метод создания объекта класса StreamWriter для чтения с текстового файла
        public static StreamReader CreateReader(string str)
        {
            StreamReader reader = new StreamReader(str);
            return reader;
        }
        //метод записи даты и информации
        public static void SMAWriter(StreamWriter writer, string info)
        {
            DateTime date = new DateTime();
            date = DateTime.Now;
            writer.WriteLine(date + ":\t" + info);
        }
        //Проверка на наличие заданной информации в файле
        public static void SMASearcher(StreamReader reader, string info)
        {
            string text = reader.ReadToEnd();
            if (text.Contains(info))
            {
                Console.WriteLine("Файл содержит данную информацию");
            }
            else
            {
                Console.WriteLine("Файл не содержит данную информацию");
            }
        }
    }
    //2. Создать класс XXXDiskInfo 
    //Класс XXXDiskInfo(): вывод информации о свободном месте на диске, файловой системе.
    //Для каждого существующего диска - имя, объем, доступный объем, метка тома.
    class SMADiskInfo
    {
        //Для представления диска в пространстве имен System.IO;
        //возвращает имена всех логических дисков компьютера
        private static DriveInfo[] Drives = DriveInfo.GetDrives();
        public static void InfoDisk(StreamWriter writer)
        {
            Console.WriteLine();
            Console.WriteLine("         2. Создать класс XXXDiskInfo");
            Console.WriteLine();
            SMALog.SMAWriter(writer, "Вывод информации о каждом диске");
            for (int i = 0; i < Drives.Length; i++)
            {
                if (Drives[i].IsReady)
                {
                    Console.WriteLine($"Общий объем диска: {Drives[i].TotalSize / 1024 / 1024 / 1024} ГБ");
                    Console.WriteLine($"Объем свободного места: {Drives[i].TotalFreeSpace / 1024 / 1024 / 1024} ГБ");
                    Console.WriteLine($"Корневой каталог: {Drives[i].RootDirectory}");
                    Console.WriteLine($"Метка тома: {Drives[i].VolumeLabel}");
                    Console.WriteLine($"Тип диска: {Drives[i].DriveType}\n");
                }
            }
        }
    }

    //3. Создать класс XXXFileInfo
    //XXXFileInfo - информация о конкретном файле
    //Полный путь
    //Размер, расширение, имя
    //Время создания

    static class SMAFileInfo
    {

        public static void FullDirection(StreamWriter writer, string f)
        {
            Console.WriteLine();
            Console.WriteLine("         3. Создать класс XXXFileInfo");
            Console.WriteLine();
            SMALog.SMAWriter(writer, "Полный путь");
            FileInfo file = new FileInfo(f);
            if (file.Exists)
            {
                Console.WriteLine("Полный путь: " + file.DirectoryName);
                Console.WriteLine("\nПолный путь файла: " + file.FullName);
                Console.WriteLine("Размер файла: " + file.Length + "байт");
                Console.WriteLine("Расширение файла: " + file.Extension);
                Console.WriteLine("Имя файла: " + file.Name);
                Console.WriteLine("Дата создания файла: " + file.CreationTimeUtc);
                Console.WriteLine("Дата создания файла: " + file.CreationTime);
            }
            else Console.WriteLine("Файл не найден!");
        }


    }

    //4. Создать класс XXXDirInfo
    //XXXDirInfo: вывод информации о директории
    //Количество файлов
    //Время создания
    //Количество поддиректориев
    //Список родительских директориев
    class SMADirInfo
    {
        public static void FileCount(StreamWriter writer, string s)
        {
            Console.WriteLine();
            Console.WriteLine("         4. Создать класс XXXDirInfo");
            Console.WriteLine();
            SMALog.SMAWriter(writer, "Вывод информации о количестве файлов в директории");
            DirectoryInfo dirinfo = new DirectoryInfo(s);
            if (dirinfo.Exists)
            {
                FileInfo[] file = dirinfo.GetFiles();
                Console.WriteLine("Количестве файлов: " + file.Length);
            }
            else Console.WriteLine("Директория не найдена!");
        }
        public static void CreationTime(StreamWriter writer, string s)
        {
            SMALog.SMAWriter(writer, "Вывод информации о выводе создания директории");
            DirectoryInfo dirinfo = new DirectoryInfo(s);
            if (dirinfo.Exists)
                Console.WriteLine("Время создания: " + dirinfo.CreationTime);
            else Console.WriteLine("Директория не найдена!");
        }
        public static void DirCount(StreamWriter writer, string s)
        {
            SMALog.SMAWriter(writer, "Количество поддиректориев: ");
            DirectoryInfo dirinfo = new DirectoryInfo(s);
            if (dirinfo.Exists && dirinfo.Extension == "")
            {
                DirectoryInfo[] d = dirinfo.GetDirectories();
                Console.WriteLine("Количество поддиректориев: " + d.Length);
            }
            else Console.WriteLine("Директория не найдена!");
        }
        public static void ParentsCount(StreamWriter writer, string s)//Список родительских директориев
        {
            SMALog.SMAWriter(writer, "Список родительских директориев: ");
            DirectoryInfo dirinfo = new DirectoryInfo(s);
            if (dirinfo.Exists)
            {
                Console.WriteLine("Список родительских директориев: " + dirinfo.Root);
            }
            else Console.WriteLine("Директория не найдена!");
        }
    }

    //5. Создать класс XXXFileManager
    //Прочитать список файлов и папок заданного диска.Создать
    //директорий XXXInspect, создать текстовый файл
    //xxxdirinfo.txt и сохранить туда информацию. Создать
    //копию файла и переименовать его. Удалить
    //первоначальный файл.
    //b.Создать еще один директорий XXXFiles.Скопировать в
    //него все файлы с заданным расширением из заданного
    //пользователем директория. Переместить XXXFiles в
    //XXXInspect. 
    //c.Сделайте архив из файлов директория XXXFiles.
    //Разархивируйте его в другой директорий.
    public static class SMAFileManager
    {

        public static void FileSubdir(StreamWriter writer, string name = null)
        {
            Console.WriteLine();
            Console.WriteLine("         5. Создать класс XXXFileManager");
            Console.WriteLine();
            SMALog.SMAWriter(writer, "Вывод инфомации о вложенных папках и файлах диска " + name);
            if (name != null)
            {
                Console.WriteLine("Папки:");
                string[] dirs = Directory.GetDirectories(name);
                foreach (string s in dirs)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(name);
                foreach (string s in files)
                {
                    Console.WriteLine(s);
                }
            }
        }
        public static void Part1(StreamWriter writer)
        {
            SMALog.SMAWriter(writer, "Создание папки,файла,заполнение,копирование,удаления");
            string path = @"D:\\";
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.CreateSubdirectory("SMAInspect"); //создает каталог по указанному пути path
            if (!directory.Exists) // проверяет, существует ли каталог
            {
                directory.Create();
            }

            Console.WriteLine(directory.FullName);
            FileInfo file = new FileInfo(directory.FullName + "SMAInspect\\SMAdirinfo.txt");
            using (FileStream fs = new FileStream(file.FullName, FileMode.OpenOrCreate))
            {
                string text = "Hello World";
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fs.Write(array, 0, array.Length);
                fs.Close();
            }
            File.Copy(file.FullName, file.DirectoryName + "\\test.txt", true);
            file.CopyTo("newfile.txt", true);
            file.Delete();//удаление файла "D:\\SMAInspect\\SMAdirinfo.txt"
        }
        public static void Part2(StreamWriter writer)
        {
            SMALog.SMAWriter(writer, "Создание папки, перемещение файлов с заданым расширением из одной папки в другую");
            string path = @"D:\\STPMS13";
            DirectoryInfo directory = new DirectoryInfo(path);
            directory.CreateSubdirectory("SMAFiles");
            if (!directory.Exists)
            {
                directory.Create();
            }

            Console.WriteLine(directory.FullName);
            DirectoryInfo source = new DirectoryInfo(@"D:\\");
            DirectoryInfo destin = new DirectoryInfo(@"D:\\STPMS13\SMAFiles\");
            DirectoryInfo dest = new DirectoryInfo(@"D:\\SMAInspect");
            foreach (FileInfo item in source.GetFiles().Where(x => x.Extension == "1111.txt").ToList())
            {
                item.CopyTo(destin + item.Name, true);
            }

            
                Console.WriteLine("-------------------------------------");
                destin.MoveTo(dest.FullName);
            
        }

        public static void Part3(StreamWriter writer)
        {
            SMALog.SMAWriter(writer, "Архивирование папки");

            string startPath1 = @"D:\\STPMS13\CYYFiles";
            string zipPath1 = @"D:\\STPMS13\CYYFiles.zip";
            string startPath = @"D:\\CYYInspect";
            string zipPath = @"D:\\CYYInspect.zip";
            string extractPath = @"D:\\CYYInspect_2";
            DirectoryInfo zipFile = new DirectoryInfo(@"D:\\STPMS13\YYInspect.zip");

           
        }
    }
}
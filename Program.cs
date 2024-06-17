using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp21
{
    class Program
    {
        static void Main(string[] args)
        {
            string dirName = @"C:\Users\Админ\source\repos\ConsoleApp21";
            while (true)
            {
                string action = Console.ReadLine();
                switch (action)
                {
                    case "dirs":
                        ShowDirs();
                        break;

                    case "files":
                        ShowFiles();
                        break;
                }
            }
        }
        public static void ShowDirs()
        {
            string path = @"C:\";
            DirectoryInfo dir = new DirectoryInfo(path);
            string[] dirs = Directory.GetDirectories(path);
            foreach (string var in dirs)
            {
                Console.WriteLine(var);
            }
        }
        public static void ShowFiles()
        {
            string path2 = @"C:\";
            FileInfo file = new FileInfo(path2);
            string[] files = Directory.GetFiles(path2);
            foreach (string var in files)
            {
                Console.WriteLine(var);
            }
        }
        static string currentDirectory = Directory.GetCurrentDirectory();

       static void Main() { 
            Console.WriteLine($"Текущая директория: {currentDirectory}");

            while (true)
            {
                Console.Write("\nВведите команду (напишите 'cd Название_директории' или 'back' для перемещения по директориям): ");
                string input = Console.ReadLine();

                if (input.ToLower() == "back")
                {
                    MoveBack();
                }
                else if (input.StartsWith("cd "))
                {
                    string targetDirectory = input.Substring(3);
                    ChangeDirectory(targetDirectory);
                }
                else
                {
                    Console.WriteLine("Некорректная команда. Попробуйте снова.");
                }
            }
        }

        static void MoveBack()
        {
            currentDirectory = Directory.GetParent(currentDirectory).FullName;
            Console.WriteLine($"Текущая директория: {currentDirectory}");
        }

        static void ChangeDirectory(string targetDirectory)
        {
            string newDirectory = Path.Combine(currentDirectory, targetDirectory);
            if (Directory.Exists(newDirectory))
            {
                currentDirectory = newDirectory;
                Console.WriteLine($"Текущая директория: {currentDirectory}");
            }
            else
            {
                Console.WriteLine("Директория не найдена.");
            }
        }
    }
}

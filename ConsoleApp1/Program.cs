using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace ConsoleApp1
{

    class Program
    {
        static void Main(string[] args)
        {
            string PATH = $"{Environment.CurrentDirectory}\\TODO.json";
            FileWR filewr = new FileWR(PATH);

            BModel a = new BModel();
            List<BModel> list1 = new List<BModel>();

            list1 = filewr.ReadF();

            A data = new A(list1);

            Console.WriteLine(" --------------------------------TODOLIST-------------------------------- ");
            Console.WriteLine("|        Чтобы вывести весь список дел, введите : 'список'                |");
            Console.WriteLine("|        Чтобы добавить в список дел, введите : 'добавить'                |");
            Console.WriteLine("|        Чтобы удалить из списка дел, введите : 'удалить'                 |");
            Console.WriteLine("|        Чтобы найти по списку дело, введите : 'поиск'                    |");
            Console.WriteLine("|        Чтобы пометить выполнение дела, введите : 'ок'                   |");
            Console.WriteLine("|        Чтобы отсортировать дела по важности введи : 'сортировка'        |");
            Console.WriteLine("|        Чтобы закрыть программу введи : 'закрыть'                        |");
            Console.WriteLine("|        Введите необходимое действие к списку дел :                      |");
            Console.WriteLine("  ----------------------------------------------------------------------- ");

            void Ret() 
            {
                Console.WriteLine("Введите необходимое действие к списку дел : ");
                string D = Console.ReadLine();
                if (D != "список" && D != "добавить" && D != "удалить" && D != "поиск" && D != "ок" && D != "сортировка" && D != "закрыть")
                {
                    Console.WriteLine("Ошибка,такого действия нет! ");
                    Ret();
                }
                switch (D)
                {
                    case "список":
                        data.Spisok();
                        Ret();
                        break;
                    case "добавить":
                        data.Add();
                        Ret();
                        break;
                    case "удалить":
                        data.Delete();
                        Ret();
                        break;
                    case "поиск":
                        data.Finde();
                        Ret();
                        break;
                    case "ок":
                        data.ok();
                        Ret();
                        break;
                    case "сортировка":
                        data.Sort();
                        Ret();
                        break;
                    case "закрыть":
                        data.Safe();
                        break;
                }
            }
            Ret();
            
            
        }
    }
}

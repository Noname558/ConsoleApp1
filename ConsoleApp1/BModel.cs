﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Priority { get; set; }
        public string Text { get; set; }
        public string Complet { get; set; } = " ";


        public void Info()
        {
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine($"ID: {ID} | Name: {Name} | Priority: {Priority} | Text: {Text} | Complet: {Complet} |");

        }
    }

    public class A
    {
        List<BModel> list = new List<BModel>();
        public A(List<BModel> L)
        {
            list = L;
        }
        public void Spisok()
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Список пуст");
            }
            else
            {
                foreach (BModel a in list)
                {
                    a.Info();
                }
            }
        }

        public void Add()
        {
            BModel model1 = new BModel();
            int count;
            foreach (BModel a in list)
            {
                count = a.ID;
                model1.ID = count + 1;
            }
            Console.WriteLine("Введите имя: ");
            model1.Name = Console.ReadLine();
            Console.WriteLine("Введите приоритет: ");
            model1.Priority = Console.ReadLine();
            Console.WriteLine("Введите текст: ");
            model1.Text = Console.ReadLine();
            list.Add(model1);
        }

        public void Delete()
        {
            Console.WriteLine("Список");
            view(list);

            void del(int b)
            {
                List<BModel> deleteList = new List<BModel>();
                int count = 0;
                foreach (BModel a in list)
                {

                    if (a.ID == b)
                    {
                        count++;
                        int n = 1;
                        if (n == 1)
                        {
                            deleteList.Add(a);
                        }

                    }

                }
                foreach (var del in deleteList)
                {
                    list.Remove(del);
                }
                if (count == 0)
                {
                    Console.WriteLine("Дела с таким ID не существует");
                    Zad();
                }
            }
            void Zad()
            {
                Console.WriteLine("Введите индекс дела, который вы хотите удалить : ");
                int c = int.Parse(Console.ReadLine());
                del(c);
            }
            Zad();
            view(list);
        }

        public void Finde()
        {
            Console.WriteLine("Введите название дела: ");
            string name = Console.ReadLine();
            void Search(string name)
            {
                foreach (BModel a in list)
                {
                    if (a.Name == name)
                    {
                        a.Info();
                    }
                }
            }
            Search(name);
        }

         public void ok()
        {
            Console.WriteLine("Список");
            view(list);
            Console.WriteLine("Введите ID дела, которое выполнили: ");
            int id = int.Parse(Console.ReadLine());
            foreach (BModel a in list)
            {
                if (a.ID == id)
                {
                    a.Complet = "done";
                }
            }
            view(list);
        }
        public void Sort()
        {
            List<BModel> l = new List<BModel>();
            List<BModel> l1 = new List<BModel>();
            foreach (BModel a in list)
            {
                if (a.Priority == "Важно")
                {
                    l.Add(a);
                }
                else
                    l1.Add(a);
            }
            view(l);
            view(l1);
        }
        public void view(List<BModel> ll)
        {
            List<BModel> ll1 = ll;
            foreach (BModel a in ll1)
            {
                a.Info();
            }
        }

        public void safe()
        {
            string path = $"{Environment.CurrentDirectory}\\TODO.json";
            FileWR file = new FileWR(path);
            file.SaveF(list);
        }
    }
}

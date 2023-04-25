using System;
using System.Collections.Generic;
using System.Linq;

namespace Amnesty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Terminal terminal = new Terminal();

            terminal.Work();
        }
    }

    class Criminal
    {
        private string _name;
        private string _surname;

        public Criminal(string name, string surname, string crime)
        {
            _name = name;
            _surname = surname;
            Crime = crime;
        }

        public string Crime { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{_surname} {_name} - {Crime}");
        }
    }

    class Jail
    {
        List<Criminal> _criminals;

        public Jail()
        {
            _criminals = new List<Criminal>()
            {
                new Criminal("Иван", "Иванов", "кража"),
                new Criminal("Григорий", "Григорьев", "разбой"),
                new Criminal("Дмитрий", "Дмитров", "убийство"),
                new Criminal("Роман", "Романов", "хулиганство"),
                new Criminal("Петр", "Петров", "наркоторговля"),
                new Criminal("Николай", "Николаев", "изнасилование"),
                new Criminal("Илья", "Ильев", "дезертирство"),
                new Criminal("Константин", "Константинов", "антиправительственное"),
                new Criminal("Евгений", "Евгеньев", "антиправительственное"),
                new Criminal("Владимир", "Владимьев", "антиправительственное"),
                new Criminal("Вадим", "Вадимьев", "антиправительственное"),
                new Criminal("Эдуард", "Эдуардов", "антиправительственное"),
                new Criminal("Леонид", "Леонидов", "антиправительственное"),
                new Criminal("Матвей", "Матвеев", "антиправительственное")                
            };
        }

        public void ShowList()
        {
            foreach (Criminal criminal in _criminals)           
                criminal.ShowInfo();

            Console.WriteLine();
        }        

        public void Amnesty()
        {
            _criminals = _criminals.Where(criminal => criminal.Crime != "антиправительственное").ToList();
        }
    }

    class Terminal
    {
        private Jail _jail = new Jail();

        public void Work()
        {
            string header = "  В НАШЕЙ ВЕЛИКОЙ СТРАНЕ АРСТОЦКА ПРОИЗОШЛА АМНИСТИЯ!";
            string header1 = "  ВСЕ ЗАКЛЮЧЕННЫЕ ЗА АНТИПРАВИТЕЛЬСТВЕННЫЕ ПРЕСТУПЛЕНИЯ ОСВОБОЖДАЮТСЯ!    ";
            string header2 = "  СПИСОК ЗАКЛЮЧЕННЫХ:";

            Console.WriteLine(header);
            
            ShowHeaders(header1, header2);

            _jail.ShowList();

            Console.WriteLine(header1);

            ShowHeaders(header1, header2);

            _jail.Amnesty();
            _jail.ShowList();

            Console.ReadKey();
        }

        private void ShowHeaders(string header1, string header2)
        {
            Console.WriteLine(new string('*', header1.Length));
            Console.WriteLine(header2);
            Console.WriteLine();
        }
    }
}

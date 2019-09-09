using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlanner
{
    class Program
    {
        const string HELP = "помощь";
        const string EXIT = "выход";
        

        public static void Main(string[] arg)
        {
            List<Event> mainList = new List<Event>();
            CommandManager commManager = new CommandManager(mainList);
            Hello();
            string command = "";
            while (true)
            {
                Console.Write("Планировщик> ");
                command = Console.ReadLine().Trim();
                if (string.Equals(command, ""))
                {
                    continue;
                }
                if (string.Equals(command, EXIT))
                {
                    break;
                }
                else if (string.Equals(command, HELP))
                {
                    Help(commManager);
                    continue;
                }
                Command inputCommand = commManager.FindCommand(command);
                if (inputCommand != null)
                {
                    inputCommand.Execute();
                }
                else
                {
                    Console.WriteLine("Команда не распознана");
                }
            }
        }

        private static void Help(CommandManager commands)
        {
            Console.WriteLine("Доступные команды:");
            foreach (var command in commands)
            {
                Console.WriteLine(command);
            }
            Console.WriteLine("{0, -10}\tВызов справки", HELP);
            Console.WriteLine("{0, -10}\tВыход", EXIT);
        }

        private static void Hello()
        {
            Console.WriteLine("Добро пожаловать! Текущие дата/время: {0}", DateTime.Now.ToString("ddd, dd/MM/yyyy H:mm"));
            Console.WriteLine("Для вызова помощи наберите \"{0}\"", HELP);
            Console.WriteLine("----------");
            Console.WriteLine();
        }
    }
}

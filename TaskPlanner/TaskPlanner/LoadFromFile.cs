using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlanner
{
    class LoadFromFile : Command
    {
        public List<Event> allEvents = new List<Event>();
        public LoadFromFile(string name, string action, List<Event> allEven) : base(name, action)
        {
            allEvents = allEven;
        }

        public override void Execute()
        {
            string fileName = "";
            string splitter = "----------------------";
            string eventLine = "Мероприятие:";

            do
            {
                Console.Write("{0}> Введите имя файла без указания расширения: ", this.commandName);
            } while ((fileName = Console.ReadLine()) == "");
            //deleting spaces
            fileName.Replace(" ", "");
            //adding extension
            fileName += ".txt";


            try
            {
                int countLines = File.ReadAllLines(fileName).Count();
                for (int i = 0; i <= countLines - 1; i += 6)
                {
                    Event myEvent = new Event();
                    myEvent.eventName = File.ReadLines(fileName).Skip(i+1).First();
                    myEvent.eventDescription = File.ReadLines(fileName).Skip(i+2).First();
                    myEvent.eventDate = File.ReadLines(fileName).Skip(i+3).First();
                    myEvent.eventTime = File.ReadLines(fileName).Skip(i+4).First();
                    Console.WriteLine(myEvent.eventName);
                    Console.WriteLine(myEvent.eventDescription);
                    Console.WriteLine(myEvent.eventDate);
                    Console.WriteLine(myEvent.eventTime);
                    allEvents.Add(myEvent);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл с таким именем не существует!");
                return;
            }
            

        }
    }
}

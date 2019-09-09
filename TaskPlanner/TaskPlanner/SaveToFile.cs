using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TaskPlanner
{
    class SaveToFile : Command
    {
        public List<Event> allEvents = new List<Event>();

        public SaveToFile(string name, string action, List<Event> allEven) : base(name, action)
        {
            allEvents = allEven;
        }

        public override void Execute()
        {
            string fileName = "";
            string splitter = "----------------------";
            do
            {
                Console.Write("{0}> Введите имя файла без указания расширения: ", this.commandName);
            } while ((fileName = Console.ReadLine()) == "");
            //deleting spaces
            fileName.Replace(" ", "");
            //adding extension
            fileName += ".txt";
            Console.WriteLine("Создан файл: "+fileName);

            FileStream outFile = new FileStream(fileName, FileMode.Create);
            StreamWriter sw = new StreamWriter(outFile);
            outFile.Seek(0, SeekOrigin.End);

            foreach (Event myEvent in allEvents)
            {
                sw.WriteLine("Мероприятие:");
                sw.WriteLine(myEvent.eventName);
                sw.WriteLine(myEvent.eventDescription);
                sw.WriteLine(myEvent.eventDate);
                sw.WriteLine(myEvent.eventTime);
                sw.WriteLine(splitter);
            }

            sw.Close();
        }
    }
}

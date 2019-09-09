using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaskPlanner
{
    class CreateEvent : Command
    {

      public List<Event> allEvents = new List<Event>();

       public CreateEvent( string name, string action, List<Event> allEven) : base(name, action)
        {
            allEvents = allEven;
        }


        public override void Execute()
        {
            Event myEvent = new Event();
            // creating event name
            do
            {
                Console.Write("{0}> Введите название задачи: ", this.commandName);
            } while ((myEvent.eventName = Console.ReadLine()) == "");
            // creating event description
            do
            {
                Console.Write("{0}> Введите описание задачи: ", this.commandName);
            } while ((myEvent.eventDescription = Console.ReadLine()) == "");
            // creating event date
            while (true)
            {
                Console.Write("{0}> Введите дату выполнения задачи в формате ДД.ММ.ГГГГ: ", this.commandName);
                myEvent.eventDate = Console.ReadLine();
                if (myEvent.eventDate == "")
                {
                    //by default the date is tomorrow
                    myEvent.eventDate = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd");
                    break;
                }
                else if (CheckDate(myEvent.eventDate))
                {
                    myEvent.eventDate = FormatDate(myEvent.eventDate);
                    break;
                }
                else
                {
                    Console.WriteLine("Дата не соответствует заданному формату");
                }
            }

            //creating event time
            while (true)
            {
                Console.Write("{0}> Введите врмя исполнения задачи в формате ЧЧ:ММ (24ч): ", this.commandName);
                myEvent.eventTime = Console.ReadLine();
                if (myEvent.eventTime == "")
                {
                    //Setting up the default value.
                    myEvent.eventTime = DateTime.Now.ToString("HH:mm");
                    break;
                }
                else if (CheckTime(myEvent.eventTime))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Время не соответствует заданному формату");
                }

            }
            Console.WriteLine("Создано!");
            allEvents.Add(myEvent);

            //when created every event is saved by default 
            string outputFileName = "defaultout.txt";
            FileStream outFile = new FileStream(outputFileName, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(outFile);
            outFile.Seek(0, SeekOrigin.End);
            sw.WriteLine("Мероприятие:");
            sw.WriteLine(myEvent.eventName);
            sw.WriteLine(myEvent.eventDescription);
            sw.WriteLine(myEvent.eventDate);
            sw.WriteLine(myEvent.eventTime);
            sw.WriteLine("----------------------");
            sw.Close();

            
        }
        private bool CheckDate(string dat)
        {
            string dateRegex = "([0-2][0-9]|30|31)\\.(0[1-9]|10|11|12)\\.(\\d{4})";
            return Regex.IsMatch(dat, dateRegex);
        }

        private string FormatDate(string dat)
        {
            return Regex.Replace(dat, "([0-2][0-9]|30|31)\\.(0[1-9]|10|11|12)\\.(\\d{4})", "$3-$2-$1");
        }
        private bool CheckTime(string tim)
        {
            string timeRegex = "([0-1][0-9]|2[0-3]):([0-5][0-9])";
            return Regex.IsMatch(tim, timeRegex);
        }
    }
}

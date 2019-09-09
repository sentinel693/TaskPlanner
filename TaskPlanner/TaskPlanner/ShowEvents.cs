using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlanner
{
    class ShowEvents : Command
    {
        public List<Event> allEvents = new List<Event>();

        public ShowEvents(string name, string action, List<Event> allEven) : base(name, action)
        {
            allEvents = allEven;
        }

        public override void Execute()
        {
            foreach (Event ev in allEvents)
            {
                Console.WriteLine("Название задачи: "+ev.eventName);
                Console.WriteLine("Описание задачи: "+ev.eventDescription);
                Console.WriteLine("Дата проведения: "+ev.eventDate);
                Console.WriteLine("Время проведения: "+ev.eventTime);
                Console.WriteLine("-----------------");
            }
        }
    }
}

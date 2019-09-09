using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlanner
{
    class DeleteEvent : Command
    {

        List<Event> allEvents = new List<Event>();
        Event deletedEvent = new Event();

        public DeleteEvent(string name, string action, List<Event> allEven) : base(name, action)
        {
            allEvents = allEven;
        }

        public override void Execute()
        {
            int id = 0;
            string idString = "";
            do
            {
                    Console.Write("{0}> Введите номер удаляемой задачи: ", commandName);
            } while ((idString = Console.ReadLine()) == "");
            // checking if id is a number
            try
            {
                id = Convert.ToInt32(idString);
            }
            catch (FormatException)
            {
                Console.WriteLine("Введённое значение не является числом");
                return;
            }
            // deleting selected event
            if (id >= 0 && id <= allEvents.Count())
            {
                allEvents.RemoveAt(id - 1);
                Console.WriteLine("Мероприятие {0} удалено", id);
            }
            else
            {
                Console.WriteLine("Заданное мероприятие не найдено");
            }
        }
    }
}

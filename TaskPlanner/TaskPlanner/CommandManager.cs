using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading.Tasks;

namespace TaskPlanner
{
    class CommandManager : IEnumerable<Command>
    {
        private List<Command> Commands;
        private List<Event> allEvents;

        public CommandManager(List<Event> allEven)
        {
            allEvents = allEven;
            Commands = new List<Command>
            {
                new CreateEvent("создать", "Создать новую задачу",allEvents),
                new ShowEvents("показать", "Вывести список всех запланированных задач",allEvents),
                new DeleteEvent("удалить", "Удалить задачу",allEvents),
                new UpdateEvent("обновить", "Обноить данные о задаче",allEvents),
                new SaveToFile("сохранить", "Записать список задач в файл", allEvents),
                new LoadFromFile("загрузить", "Загрузить список задач изфайла",allEvents)
            };
        }

        public Command FindCommand(string name)
        {
            return Commands.Find(comm => string.Equals(comm.GetName(), name));
        }

        public IEnumerator<Command> GetEnumerator()
        {
            foreach (var command in Commands)
            {
                yield return command;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

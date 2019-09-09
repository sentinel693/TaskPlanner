using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace TaskPlanner
{
    class UpdateEvent: Command
    {

        List<Event> allEvents = new List<Event>();
        Event updatedEvent = new Event();

        public UpdateEvent(string name, string action, List<Event> allEven) : base(name, action)
        {
            allEvents = allEven;
        }

        public override void Execute()
        {
            int id = 0;
            string idString = "";
            do
            {
                Console.Write("{0}> Введите номер обновляемой задачи: ", commandName);
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

            if (id >= 0 && id <= allEvents.Count())
            {
                updatedEvent = allEvents[id - 1];
                string paramNum = "";
                //A task parameter value which is being updated.
                string value = "";
                do
                {
                    Console.WriteLine("{0}> Выберите номер редактируемого параметра: ", commandName);
                    Console.WriteLine("\t[1]Имя\n\t[2]Описание\n\t[3]Дата\n\t[4]Время");
                    Console.Write("{0}> ", commandName);
                } while ((paramNum = Console.ReadLine()) == "" || Convert.ToInt32(paramNum) < 1 || Convert.ToInt32(paramNum) > 4);


                switch (Convert.ToInt32(paramNum))
                {
                    case (1):
                        do
                        {
                            Console.Write("{0}> Введите новое имя: ", commandName);
                            value = Console.ReadLine();
                        } while (value == "");
                        updatedEvent.eventName = value;
                        break;
                    case (2):
                        do
                        {
                            Console.Write("{0}> Введите новое описание: ", commandName);
                            value = Console.ReadLine();
                        } while (value == "");
                        updatedEvent.eventDescription = value;
                        break;
                    case (3):
                        while (true)
                        {
                            Console.Write("{0}> Введите новую дату в формате ДД.ММ.ГГГГ: ", commandName);
                            value = Console.ReadLine();
                            if (CheckDate(value))
                            {
                                value = FormatDate(value);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Дата не соответствует заданному формату");
                            }
                        }
                        updatedEvent.eventDate = value;
                        break;
                    case (4):
                        while (true)
                        {
                            Console.Write("{0}> Введите новое время в формате ЧЧ:ММ (24ч): ", commandName);
                            value = Console.ReadLine();
                            if (CheckTime(value))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Время не соответствует заданному формату");
                            }
                        }
                        updatedEvent.eventTime = value;
                        return;
                    default:
                        return;
                }
                Console.WriteLine("Обновлено!");
            }
            else
            {
                Console.WriteLine("Заданное мероприятие не найдено");
            }
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


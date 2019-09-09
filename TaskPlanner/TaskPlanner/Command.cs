using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskPlanner
{
    abstract class Command
    {
        protected string commandName; //Command name used to refer to it.
        protected string commandAction; //Used to describe the command itself

        protected Command(string name, string action)
        {
            commandName = name;
            commandAction = action;
        }

        public string GetName()
        {
            return commandName;
        }

        public abstract void Execute();

        public override string ToString()
        {
            return string.Format("{0, -10}\t{1}", commandName, commandAction);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoClickPro.Models
{
    public abstract class Action
    {
        public abstract void Run();
    }

    class KichBan: Action
    {
        List<Action> actions;
        public void Add(Action a)
        {
            this.actions.Add(a);
        }
        public void Del(Action a)
        {
            this.actions.Remove(a);
        }
        public override void Run()
        {
            foreach (var item in actions)
            {
                item.Run();
            }
        }
    }
}

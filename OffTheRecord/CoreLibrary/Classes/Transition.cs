using System;
using System.Collections.Generic;
using System.Text;

namespace OffTheRecord.CoreLibrary.Classes
{
    public class Transition
    {
        public string eventName { get; set; }

        public StateMachine Parent { get; set; }

        public State fromState { get; set; }


        public State toState { get; set; }

        public List<Action> actions { get; set; }

        public Transition()
        {
            this.actions = new List<Action>();
        }

        public void execute()
        {
            foreach (var action in this.actions)
            {
                action();
            }
            this.Parent.MoveState(this.toState);
        }
    }
}

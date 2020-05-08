using System;
using System.Collections.Generic;
using System.Text;

namespace OffTheRecord.CoreLibrary.internals
{
    public class StateMachineDefinition
    {
        public Dictionary<string, State> states { get; set; }
        public List<Transition> transitions { get; set; }

        public StateMachineDefinition()
        {
            this.states = new Dictionary<string, State>();
            this.transitions = new List<Transition>();
        }
    }
}

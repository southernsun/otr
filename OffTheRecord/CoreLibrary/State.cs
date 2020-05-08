using System;
using System.Collections.Generic;
using System.Text;

namespace OffTheRecord.CoreLibrary
{
    public class State
    {
        public string Name { get; set; }

        private internals.State stateDef;

        public List<Transition> Transitions { get; set; }

        public State(internals.State stateDef)
        {
            this.stateDef = stateDef;
            this.Transitions = new List<Transition>();
        }
    }
}

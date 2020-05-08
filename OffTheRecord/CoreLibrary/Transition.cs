using System;
using System.Collections.Generic;
using System.Text;

namespace OffTheRecord.CoreLibrary
{
    public class Transition
    {
        public string eventName { get; set; }

        public List<Action> actions { get; set; }

        public Transition()
        {
            this.actions = new List<Action>();
        }
    }
}

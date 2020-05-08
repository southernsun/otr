using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

using OffTheRecord.CoreLibrary.internals;

namespace OffTheRecord.CoreLibrary
{
    public class StateMachine
    {
        private StateMachineDefinition definition;
        private object callbackObject;

        private Dictionary<string, State> states = new Dictionary<string, State>();

        private Queue<string> eventQueue = new Queue<string>();
        public StateMachine(StateMachineDefinition definition, object callbackObject)
        {
            this.definition = definition;
            this.callbackObject = callbackObject;

            foreach (var keyVal in this.definition.states)
            {
                this.states.Add(keyVal.Key, new State(keyVal.Value) { Name = keyVal.Key });
            }
        }

        public void FireEvent(string eventName)
        {
            this.eventQueue.Enqueue(eventName);
        }
    }
}

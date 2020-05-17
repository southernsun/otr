using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading;
using OffTheRecord.CoreLibrary.internals;

namespace OffTheRecord.CoreLibrary.Classes
{
    public class StateMachine
    {
        private StateMachineDefinition definition;
        private object callbackObject;

        private Dictionary<string, State> states = new Dictionary<string, State>();

        private Dictionary<string, List<Transition>> eventMap = new Dictionary<string, List<Transition>>();

        private Queue<string> eventQueue = new Queue<string>();
        private Thread _thread;

        // for now it runs continuous.
        // we will evaluate at a later point.
        private bool isRunning = true;

        public State currentState { get; private set; }

        public StateMachine(StateMachineDefinition definition, object callbackObject)
        {
            this.definition = definition;
            this.callbackObject = callbackObject;

            foreach (var keyVal in this.definition.states)
            {
                var stateObj = new State(keyVal.Value) { Name = keyVal.Key };
                if (keyVal.Value.isDefault)
                {
                    this.MoveState(stateObj);
                }
                this.states.Add(keyVal.Key, stateObj);
            }

            var methodDict = new Dictionary<string, MethodInfo>();
            var methods = callbackObject.GetType().GetMethods();
            foreach (var meth in methods)
            {
                if (meth.DeclaringType != typeof(Object))
                {
                    methodDict.Add(meth.Name, meth);
                }
            }

            foreach (var trans in this.definition.transitions)
            {
                var toState = this.states[trans.to];
                var fromState = this.states[trans.from];
                var transObj = new Transition() { eventName = trans.eventName, toState = toState, fromState = fromState, Parent = this };

                foreach (var methName in trans.actions)
                {
                    var info = methodDict[methName];
                    transObj.actions.Add(delegate {
                        info.Invoke(callbackObject, new object[0]);
                    });
                }

                fromState.Transitions.Add(transObj);
                List<Transition> transList;
                if (this.eventMap.TryGetValue(trans.eventName, out transList))
                {
                    transList.Add(transObj);
                } 
                else
                {
                    List<Transition> list = new List<Transition>();
                    list.Add(transObj);
                    this.eventMap.Add(trans.eventName, list);
                }
            }

 

            this._thread = new Thread(this._think);
            this._thread.Start();
        }

        internal void MoveState(State toState)
        {
            this.currentState = toState;
        }

        private void _think()
        {
            while (this.isRunning)
            {
                string eventName;
                while (this.eventQueue.TryDequeue(out eventName))
                {
                    var transList = this.eventMap[eventName];
                    foreach (var trans in transList)
                    {
                        if (trans.fromState == this.currentState)
                        {
                            trans.execute();
                        }
                    }
                }
            }
        }

        public void FireEvent(string eventName)
        {
            this.eventQueue.Enqueue(eventName);
        }
    }
}

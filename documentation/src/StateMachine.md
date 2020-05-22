
# StateMachine

## Concept

You create one and then fire events into it.
as you fire events states change and code is executed.

## Technology

The first is the use of JSON.
JSON deserializes nicely.

and it actually has types unlike xml.

Types List
+ Object 
+ Array
+ String
+ Number (Float and Int)
+ Boolean

Current librabry is an open source library that has good stats and a simple api.

It deserializes to typed simple data objects that are then linked up in the thinking state machine.

The functional aspect will be triggered throung reflection.

If someone finds a more readable format for invoking reflection. go for it.

The way I always saw was.
Look up the invoke path on the type.
Trigger the invoke on the right instance.

Instantiates a state machine.
will lead to a new thread created.

## Diagrams

```plantuml
class StateMachine {
StateMachine(StateMachineDefinition definition, object callbackObject)
}

package internals {
    class StateMahineDefintion {
        + Dictionary<string, State> states { get; set; }
        + List<Transition> transitions { get; set; }
    }

    class State {
        + bool isDefault { get; set; }
    }

    Class Transition {
        + string from { get; set; }
        + string to { get; set; }

        + string eventName { get; set; }

        + List<string> actions { get; set; }

    }
}
```

## c#

```csharp
            var stateMachineDefinition = StateMachineUtils.Parse("samplestatemachine.json");
            this.cbObj = new StateMachineCallbacks();
            var state = new StateMachine(stateMachineDefinition, this.cbObj);
            this.sm = state;

```

## JSON for state machine

```json
{
  "states": {
    "start": {
      "isDefault": true
    },
    "initialized": {},
    "connecting": {},
    "connected": {}
  },
  "transitions": [
    {
      "from": "start",
      "to": "initialized",
      "eventName": "initialized"
    },
    {
      "from": "initialized",
      "to": "connecting",
      "eventName": "connect",
      "actions": [
        "bubbleConnecting"
      ]
    },
    {
      "from": "connecting",
      "to": "connected",
      "eventName": "connected",
      "actions": [
        "bubbleConnected"
      ]
    },
    {
      "from": "connected",
      "to": "initialized",
      "eventName": "disconnect",
      "actions": [
        "bubbleConnected"
      ]
    }
  ]
}
```

## The code hooks

The idea is if you have to marshal data to UI or other conetxts this is where you do it.


```csharp
    public class StateMachineCallbacks
    {
        public bool isConnnecting { get; private set; }
        public bool isConnnected { get; private set; }

        public void bubbleConnected()
        {
            this.isConnnecting = false;
            this.isConnnected = true;
            MarshalToUIContext.update(this);
        }

        public void bubbleConnecting()
        {
            this.isConnnecting = true;
            MarshalToUIContext.update(this);
        }
    }
```

## Example in PlantUML

```plantuml
[*] --> Start
Start : Every state machine should just start
Initialized : Execute an initialization pattern.


Start -> Initialized
Initialized --> Connecting
Connecting --> Connected
```

using System;
using System.Collections.Generic;
using System.Text;

using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OffTheRecord.CoreLibrary;
using OffTheRecord.CoreLibrary.internals;

namespace CoreLib.Tests
{
    [TestClass]
    public class StateMachineTests
    {
        [TestMethod]
        public void RunSampleStateMachine()
        {
            var stateMachineDefinition = StateMachineUtils.Parse("samplestatemachine.json");
            var state = new StateMachine(stateMachineDefinition, new object());

        }
    }
}

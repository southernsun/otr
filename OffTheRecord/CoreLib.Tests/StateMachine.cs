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
    public class StateMachine
    {
        [TestMethod]
        public void RunSampleStateMachine()
        {
            var state = new StateMachine(StateMachineUtils.Parse("samplestatemchine.json"), new object());

        }
    }
}

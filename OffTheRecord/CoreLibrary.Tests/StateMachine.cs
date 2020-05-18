using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OffTheRecord.CoreLibrary.Classes;
using OffTheRecord.CoreLibrary.internals;

namespace CoreLib.Tests
{
    public class StateMachineCallbacks
    {
        public bool isConnnecting { get; private set; }
        public bool isConnnected { get; private set; }

        public void bubbleConnected()
        {
            this.isConnnecting = false;
            this.isConnnected = true;
        }

        public void bubbleConnecting()
        {
            this.isConnnecting = true;
        }
    }

    [TestFixture]
    public class StateMachineTests
    {
        private StateMachine sm;
        private StateMachineCallbacks cbObj;

        [SetUp]
        public void constructStateMachine()
        {
            var stateMachineDefinition = StateMachineUtils.Parse("samplestatemachine.json");
            this.cbObj = new StateMachineCallbacks();
            var state = new StateMachine(stateMachineDefinition, this.cbObj);

            state.currentState.Name.Should().Be("start");
            this.sm = state;
        }

        [Test]
        public void Scenario()
        {
            this.sm.FireEvent("initialized");

            Thread.Sleep(10);

            this.sm.currentState.Name.Should().Be("initialized");
            //this.cbObj.isConnnecting.Should().BeTrue();

            this.sm.FireEvent("connect");
            Thread.Sleep(1);

            this.sm.currentState.Name.Should().Be("connecting");
            this.cbObj.isConnnected.Should().BeFalse();
            this.cbObj.isConnnecting.Should().BeTrue();


            this.sm.FireEvent("connected");
            Thread.Sleep(1);

            this.sm.currentState.Name.Should().Be("connected");
            this.cbObj.isConnnected.Should().BeTrue();
            this.cbObj.isConnnecting.Should().BeFalse();

        }

        //[Test]
        //public void Connected()
        //{
        //    this.sm.FireEvent("connect");
        //    Thread.Sleep(1);

        //    this.sm.currentState.Name.Should().Be("connected");
        //    this.cbObj.isConnnected.Should().BeTrue();
        //}
    }
}

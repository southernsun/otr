using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OffTheRecord.CoreLibrary.Classes;

namespace CoreLibrary.Tests
{
    [TestFixture]
    public class InstanceTagTest
    {
        [Test]
        public void IsValidShouldReturnFalseBetween0and100Hex([Range(1, 255, 1)] int x)
        {
            uint value = (uint) x;
            InstanceTag.IsValid(value).Should().BeFalse();
        }

        [Test]

        public void IsValid()
        {
            InstanceTag.IsValid(0).Should().BeTrue();
            InstanceTag.IsValid(256).Should().BeTrue();
        }
    }
}

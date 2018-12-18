using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcCSharp.Models;

namespace MvcUnitTestDemo.Models
{
    [TestClass]
    public class MathOperationsTests
    {
        [TestMethod]
        public void Adding_WithMissingOperands_ShouldReturn0()
        {
            //arrange
            var mathOp = new MathOperation();
            mathOp.NumberOne = null;
            mathOp.NumberTwo = null;
            mathOp.Operation = "Add";

            //act
            mathOp.Calculate();

            //assert
            Assert.AreEqual(0,mathOp.Answer,"Null values are not being evaluated properly.");

        }
    }
}

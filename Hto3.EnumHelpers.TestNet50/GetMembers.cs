﻿using System;
using Hto3.EnumHelpers.TestCore30.Assets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hto3.EnumHelpers.TestCore30
{
    [TestClass]
    public class GetMembers
    {
        [TestMethod]
        public void NormalUse()
        {
            //Arrange
            const String EXPECTED_FOR_APPLE = "Apple";
            const String EXPECTED_FOR_BANANA = "Banana";
            const String EXPECTED_FOR_GRAPE = "White Grape";
            const String EXPECTED_FOR_ORANGE = "Orange range";
            const Int32 AMOUNT_MEMBERS = 4;

            //Act
            var fruits = Hto3.EnumHelpers.EnumHelpers.GetMembers<FruitsEnum>();

            //Assert
            Assert.AreEqual(fruits.Count, AMOUNT_MEMBERS);
            Assert.AreEqual(fruits[FruitsEnum.Apple], EXPECTED_FOR_APPLE);
            Assert.AreEqual(fruits[FruitsEnum.Banana], EXPECTED_FOR_BANANA);
            Assert.AreEqual(fruits[FruitsEnum.Grape], EXPECTED_FOR_GRAPE);
            Assert.AreEqual(fruits[FruitsEnum.Orange], EXPECTED_FOR_ORANGE);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsNotAnEnumType()
        {
            //Act
            EnumHelpers.GetMembers<Int32>();

            //Assert
            Assert.Fail();
        }
    }
}

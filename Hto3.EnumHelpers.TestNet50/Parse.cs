using Hto3.EnumHelpers.TestCore30.Assets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hto3.EnumHelpers.TestCore30
{
    [TestClass]
    public class Parse
    {
        [TestMethod]
        public void NormalUseCaseSensitive()
        {
            //Arrange
            const FruitsEnum EXPECTED = FruitsEnum.Apple;

            //Act
            var result = EnumHelpers.Parse<FruitsEnum>("Apple");

            //Assert
            Assert.AreEqual(EXPECTED, result);
        }

        [TestMethod]
        public void NormalUseCaseInsensitive()
        {
            //Arrange
            const FruitsEnum EXPECTED = FruitsEnum.Apple;

            //Act
            var result = EnumHelpers.Parse<FruitsEnum>("apple", true);

            //Assert
            Assert.AreEqual(EXPECTED, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsNotAnEnum()
        {
            //Act
            EnumHelpers.Parse<Int32>("2");

            //Assert
            Assert.Fail();
        }
    }
}

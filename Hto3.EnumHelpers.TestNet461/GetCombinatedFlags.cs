using Hto3.EnumHelpers.TestNet461.Assets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.EnumHelpers.TestNet461
{
    [TestClass]
    public class GetCombinatedFlags
    {
        [TestMethod]
        public void CombinatedEnumWithThreeFlags()
        {
            //Arrange
            var COMBINATED_ENUM = FruitsSaladEnum.Melon | FruitsSaladEnum.Pear | FruitsSaladEnum.Watermelon;

            //Act
            var result = EnumHelpers.GetCombinatedFlags(COMBINATED_ENUM).ToArray();

            //Assert
            Assert.AreEqual(3, result.Length);
            Assert.IsTrue(result.Any(r => r == FruitsSaladEnum.Melon));
            Assert.IsTrue(result.Any(r => r == FruitsSaladEnum.Pear));
            Assert.IsTrue(result.Any(r => r == FruitsSaladEnum.Watermelon));
        }

        [TestMethod]
        public void CombinatedEnumWithOneFlag()
        {
            //Arrange
            var COMBINATED_ENUM_SINGLE_ITEM = FruitsSaladEnum.Watermelon;

            //Act
            var result = EnumHelpers.GetCombinatedFlags(COMBINATED_ENUM_SINGLE_ITEM).ToArray();

            //Assert
            Assert.AreEqual(1, result.Length);
            Assert.IsTrue(result.Any(r => r == FruitsSaladEnum.Watermelon));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IsNotAnEnumFlag()
        {
            //Arrange
            var NON_ENUM_FLAG = FruitsEnum.Apple;

            //Act
            var result = EnumHelpers.GetCombinatedFlags(NON_ENUM_FLAG).ToArray();

            //Assert
            Assert.Fail();
        }
    }
}

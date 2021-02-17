using Hto3.EnumHelpers.TestCore30.Assets;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.EnumHelpers.TestCore30
{
    [TestClass]
    public class GetDescription
    {
        [TestMethod]
        public void WithDescription()
        {
            Assert.AreEqual(FruitsEnum.Orange.GetDescription(), "Orange range");
        }

        [TestMethod]
        public void WhithoutDescription()
        {
            Assert.AreEqual(FruitsEnum.Apple.GetDescription(), "Apple");
        }

        [TestMethod]
        public void GetDescriptionOfAnUnknownEnumMember()
        {
            //Arrange
            const FruitsEnum UNKNOWN_ENUM_MEMBER = default(FruitsEnum);

            //Act - Assert
            Assert.IsNull(UNKNOWN_ENUM_MEMBER.GetDescription());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TryGetOfNullValue()
        {
            EnumHelpers.GetDescription(null);
        }
    }
}

﻿using System;
using Hto3.EnumHelpers.TestNet461.Assets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hto3.EnumHelpers.TestNet461
{
    [TestClass]
    public class Parse
    {
        [TestMethod]
        public void CaseSensitive()
        {
            Assert.AreEqual(EnumHelpers.Parse<FruitsEnum>("Orange"), FruitsEnum.Orange);
        }

        [TestMethod]
        public void CaseInsensitive()
        {
            Assert.AreEqual(EnumHelpers.Parse<FruitsEnum>("ORANGE", true), FruitsEnum.Orange);
        }
    }
}

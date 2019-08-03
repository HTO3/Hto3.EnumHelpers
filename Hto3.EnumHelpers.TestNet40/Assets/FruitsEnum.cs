using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hto3.EnumHelpers.TestNet40.Assets
{
    public enum FruitsEnum
    {
        Apple = 1,
        Banana = 2,
        [System.ComponentModel.Description("White Grape")]
        Grape = 3,
        [System.ComponentModel.Description("Orange range")]
        Orange = 4
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.EnumHelpers.TestCore30.Assets
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

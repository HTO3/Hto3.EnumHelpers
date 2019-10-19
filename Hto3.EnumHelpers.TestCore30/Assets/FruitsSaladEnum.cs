using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hto3.EnumHelpers.TestCore30.Assets
{
    [Flags]
    public enum FruitsSaladEnum
    {
        Watermelon = 1,
        Melon = 2,
        Pear = 4,
        [System.ComponentModel.Description("It's a kind of orange?")]
        Tangerine = 8
    }
}

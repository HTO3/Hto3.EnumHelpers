![logo](https://raw.githubusercontent.com/HTO3/Hto3.EnumHelpers/master/nuget-logo-small.png)

Hto3.EnumHelpers
========================================

#### Nuget Package

[![License](https://img.shields.io/github/license/HTO3/Hto3.EnumHelpers)](https://github.com/HTO3/Hto3.EnumHelpers/blob/master/LICENSE)
[![Hto3.EnumHelpers](https://img.shields.io/nuget/v/Hto3.EnumHelpers.svg)](https://www.nuget.org/packages/Hto3.EnumHelpers/)
[![Downloads](https://img.shields.io/nuget/dt/Hto3.EnumHelpers)](https://www.nuget.org/stats/packages/Hto3.EnumHelpers?groupby=Version)
[![Build Status](https://github.com/HTO3/Hto3.EnumHelpers/actions/workflows/publish.yml/badge.svg)](https://github.com/HTO3/Hto3.EnumHelpers/actions/workflows/publish.yml)
[![codecov](https://codecov.io/gh/HTO3/Hto3.EnumHelpers/branch/master/graph/badge.svg)](https://codecov.io/gh/HTO3/Hto3.EnumHelpers)
[![Codacy Badge](https://app.codacy.com/project/badge/Grade/644d2e61c30348018efe27a5c62b7218)](https://www.codacy.com/gh/HTO3/Hto3.EnumHelpers/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=HTO3/Hto3.EnumHelpers&amp;utm_campaign=Badge_Grade)

Features
--------
Helpers methods to handle enums solving common dev problems.

Related projects:
----------------
https://github.com/TylerBrinkley/Enums.NET Enums.NET is a high-performance type-safe .NET enum utility library which provides many operations as convenient extension methods. It is compatible with .NET Framework 4.5+ and .NET Standard 1.0+.

### GetMembers

Gets a dictionary containing in its keys the enums and their value the description text of the enum. The enum should be decorated with <i>DescriptionAttribute</i>.

```csharp
//Assuming this enum declaration
public enum FruitsEnum
{
    Apple = 1,
    Banana = 2,
    [System.ComponentModel.Description("White Grape")]
    Grape = 3,
    [System.ComponentModel.Description("Orange range")]
    Orange = 4
}

//Using GetMembers method
var fruits = EnumHelpers.GetMembers<FruitsEnum>();

//Got a dictionary with the members as result
fruits.Count == 4;
fruits[FruitsEnum.Apple] == "Apple";
fruits[FruitsEnum.Banana] == "Banana";
fruits[FruitsEnum.Grape] == "White Grape";
fruits[FruitsEnum.Orange] == "Orange range";
```

Providing the enum type as a parameter flavor is available too.

```csharp
//provide the enum type as a parameter
var fruits = EnumHelpers.GetMembers(typeof(FruitsEnum));
```

### Parse

Parse a string as an enum.

```csharp
//Assuming this enum declaration
public enum FruitsEnum
{
    Apple = 1
}

//Parse the string
EnumHelpers.Parse<FruitsEnum>("Apple") == FruitsEnum.Apple;
```

### GetDescription

Get the enum description. The enum should be decorated with <i>DescriptionAttribute</i> to get a fancy description, otherwise you will get the enum name.

```csharp
//Assuming this enum declaration
public enum FruitsEnum
{
    Apple = 1,
    [System.ComponentModel.Description("White Grape")]
    Grape = 3
}

//Using the extension method
FruitsEnum.Apple.GetDescription() == "Apple";
FruitsEnum.Grape.GetDescription() == "White Grape";
```

### GetCombinatedFlags

Get all combinated flag of a flagable enum.

```csharp
//Assuming this enum declaration
[Flags]
public enum FruitsSaladEnum
{
    Watermelon = 1,
    Melon = 2,
    Pear = 4,
    [System.ComponentModel.Description("It's a kind of orange?")]
    Tangerine = 8
}

//Using the extension method
var combinatedEnum = FruitsSaladEnum.Melon | FruitsSaladEnum.Pear | FruitsSaladEnum.Watermelon;
var result = EnumHelpers.GetCombinatedFlags(combinatedEnum).ToArray();

//You will get separated individuals
result.Length == 3;
result.Any(r => r == FruitsSaladEnum.Melon);
result.Any(r => r == FruitsSaladEnum.Pear);
result.Any(r => r == FruitsSaladEnum.Watermelon);
```
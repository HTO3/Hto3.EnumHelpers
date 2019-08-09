<img alt="logo" width="150" height="150" src="nuget-logo.png">

Hto3.EnumHelpers
========================================

#### Nuget Package
[![Hto3.EnumHelpers](https://img.shields.io/nuget/v/Hto3.EnumHelpers.svg)](https://www.nuget.org/packages/Hto3.EnumHelpers/)

Features
--------
Helpers methods to handle enums solving common dev problems.

### GetMembers

Gets a dictionary containing in its keys the enums and their value, the description text of the enum. The enum should be decorated with <i>DescriptionAttribute</i>.

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
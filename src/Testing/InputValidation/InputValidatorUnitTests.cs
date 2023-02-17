// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roll.InputValidation;

namespace Testing.InputValidation;
public class InputValidatorUnitTests
{
    [Fact]
    public void IsValidExistsTest()
    {
        InputValidator localValidator = new InputValidator();

        Assert.False( localValidator.IsValid(new String[]{}));
    }

    [Fact]
    public void IsValidEmptyStringTest()
    {
        InputValidator localValidator = new InputValidator();

        Assert.False(localValidator.IsValid(new String[] {" "}));
    }

    [Fact]
    public void IsValidInvalidStringTest()
    {
        InputValidator localValidator = new InputValidator();

        Assert.False(localValidator.IsValid(new String[] { "ThisShouldFailValidation" }));
    }

    [Theory]
    [InlineData(new object[] { new string[] { "1d4" } })]
    [InlineData(new object[] { new string[] { "1D6" } })]
    [InlineData(new object[] { new string[] { "1d8" } })]
    [InlineData(new object[] { new string[] { "1D10" } })]
    [InlineData(new object[] { new string[] { "1d100" } })]
    [InlineData(new object[] { new string[] { "1D12" } })]
    [InlineData(new object[] { new string[] { "1d20" } })]
    [InlineData(new object[] { new string[] { "1D36" } })]
    [InlineData(new object[] { new string[] { "9999999999999999d6" } })]
    [InlineData(new object[] { new string[] { "1D9999999999999999" } })]
    [InlineData(new object[] { new string[] { "9999999999999999d9999999999999999" } })]
    public void ValidInputTests(string[] args)
    {
        InputValidator localValidator = new InputValidator();

        Assert.True(localValidator.IsValid(args));
    }

    [Theory]
    [InlineData(new object[] { new string[] { "1d4z" } })]
    [InlineData(new object[] { new string[] { "l1d6" } })]
    [InlineData(new object[] { new string[] { "1B6" } })]
    [InlineData(new object[] { new string[] { "1d" } })]
    [InlineData(new object[] { new string[] { "D10" } })]
    [InlineData(new object[] { new string[] { "1d1O0" } })]
    [InlineData(new object[] { new string[] { "1d6", "1D6" } })] //Invalid because multiple parameters.
    [InlineData(new object[] { new string[] { " 1d6" } })]
    [InlineData(new object[] { new string[] { "1d6 " } })]
    [InlineData(new object[] { new string[] { " 1d6" } })]
    [InlineData(new object[] { new string[] { "1 d 6" } })]
    [InlineData(new object[] { new string[] { " 1d6 " } })]
    public void InvalidInputTests(string[] args)
    {
        InputValidator localValidator = new InputValidator();

        Assert.False(localValidator.IsValid(args));
    }

}

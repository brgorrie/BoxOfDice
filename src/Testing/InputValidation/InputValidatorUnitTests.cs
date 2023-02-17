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

}

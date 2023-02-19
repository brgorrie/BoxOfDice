// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Roll.InputValidation;

public interface IInputValidator
{
    /// <summary>
    /// Parses the first argument in the array and returns the number of rolls and number of sides values.
    /// Throws an exception if the input is invalid in that it:
    ///     * doesn't have the correct number of arguments
    ///     * there is one argument but it is an empty string
    ///     * the argument isn't of the 1d6 or 2D12 style of specifying die rolls. 
    /// </summary>
    (int Rolls, int Sides) ParseInput(string[] args);
}

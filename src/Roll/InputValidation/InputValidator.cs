// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Roll.InputValidation;

/*
 * The purpose of this class is to provide validation for command line inputs and return the
 * components of the parameter passed in.  
 */
public class InputValidator
{

    public bool IsValid(string[] args)
    {
        bool result = args.Length == 1 && !String.IsNullOrWhiteSpace(args[0]);
        if (result)
        {
            var pattern = "^(\\d+)(d)(\\d+)$";
            var match = Regex.Match(args[0], pattern, RegexOptions.IgnoreCase);
            result = match.Success;
        }
        return result;
    }

    public (int Rolls, int Sides) ParseInput(string[] args)
    {
        if (IsValid(args))
        {
            var input = args[0];
            var pattern = "^(\\d+)(d)(\\d+)$";
            var match = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
            if (match.Success)
            {
                return (int.Parse(match.Groups[1].Value), int.Parse(match.Groups[3].Value));
            }
        }

        throw new Exception("Invalid input format");
    }

}

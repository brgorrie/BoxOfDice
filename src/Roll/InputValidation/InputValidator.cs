// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Roll.InputValidation;
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

}

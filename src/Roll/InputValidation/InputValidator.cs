// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roll.InputValidation;
public class InputValidator
{
    public bool IsValid(string[] args)
    {
        return args.Length == 1 && !String.IsNullOrWhiteSpace(args[0]);
    }

}

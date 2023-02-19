// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Roll.OutputPrinting;

public interface IOutputPrinter
{
    void PrintResults(int[] results, int sides);
    void PrintArgumentException(ArgumentException argumentException);
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using UnitTestingExamples.Example1.Shared;

namespace UnitTestingExamples.Example1.HardToTest
{
    public static class CheckbookPrinter
    {
        public static void Print(User user, int lastPrintedCheckNumber, int numberOfChecks)
        {
            throw new NotImplementedException();
        }

        public static void Print(DateTime printDateTime)
        {
            throw new NotImplementedException();
        }
    }
}
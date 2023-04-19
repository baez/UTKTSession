using System;
using UnitTestingExamples.Example1.EasyToTest.Interfaces;

namespace UnitTestingExamples.Example1.EasyToTest.Shared
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}

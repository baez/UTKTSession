using System;
using UnitTestingExamples.Example1.EasyToTest.Interfaces;
using UnitTestingExamples.Example1.Shared;
using ConfigManager = UnitTestingExamples.Example1.Shared;

namespace UnitTestingExamples.Example1.EasyToTest
{
    public class ConfigurationManager : IConfigurationManager
    {
        public int NumberOfChecksSmallPack { get; set; }
        public int NumberOfChecksMediumPack { get; set; }
        public int NumberOfChecksLargePack { get; set; }


        public int GetNumberOfChecksToPrint(CheckbookSize checkbookSize)
        {
            switch (checkbookSize)
            {
                case CheckbookSize.Small:
                    return ConfigManager.ConfigurationManager.NumberOfChecksSmallPack;
                case CheckbookSize.Medium:
                    return ConfigManager.ConfigurationManager.NumberOfChecksMediumPack;
                case CheckbookSize.Large:
                    return ConfigManager.ConfigurationManager.NumberOfChecksLargePack;
                default:
                    throw new ArgumentException(nameof(checkbookSize));
            }
        }
    }
}

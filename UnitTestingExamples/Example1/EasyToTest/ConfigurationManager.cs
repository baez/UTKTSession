using System;
using UnitTestingExamples.Example1.EasyToTest.Interfaces;
using UnitTestingExamples.Example1.Shared;
using ConfigManager = UnitTestingExamples.Example1.Shared;

namespace UnitTestingExamples.Example1.EasyToTest
{
    public class ConfigurationManager : IConfigurationManager
    {
        public int NumberOfChecksSmallPack
        {
            get
            {
                return ConfigManager.ConfigurationManager.NumberOfChecksSmallPack;
            }

            set
            {
                ConfigManager.ConfigurationManager.NumberOfChecksSmallPack = value;
            }
        }

        public int NumberOfChecksMediumPack
        {
            get
            {
                return ConfigManager.ConfigurationManager.NumberOfChecksMediumPack;
            }

            set
            {
                ConfigManager.ConfigurationManager.NumberOfChecksMediumPack = value;
            }
        }

        public int NumberOfChecksLargePack
        {
            get
            {
                return ConfigManager.ConfigurationManager.NumberOfChecksLargePack;
            }

            set
            {
                ConfigManager.ConfigurationManager.NumberOfChecksLargePack = value;
            }
        }

        public int GetNumberOfChecksToPrint(CheckbookSize checkbookSize)
        {
            return ConfigManager.ConfigurationManager.GetNumberOfChecksToPrint(checkbookSize);
        }
    }
}

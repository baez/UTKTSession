using UnitTestingExamples.Example1.EasyToTest.Interfaces;
using UnitTestingExamples.Example1.Shared;
using ConfigManager = UnitTestingExamples.Example1.Shared;

namespace UnitTestingExamples.Example1.EasyToTest
{
    public class ConfigurationManager : IConfigurationManager
    {
        public int NumberOfChecksPerRow
        {
            get
            {
                return ConfigManager.ConfigurationManager.NumberOfChecksPerRow;
            }
        }

        public int NumberOfRowsPerPage
        {
            get
            {
                return ConfigManager.ConfigurationManager.NumberOfRowsPerPage; ;
            }
        }

        public decimal CheckLength
        {
            get
            {
                return ConfigManager.ConfigurationManager.CheckLength;
            }
        }

        public decimal CheckWidth
        {
            get
            {
                return ConfigManager.ConfigurationManager.CheckWidth;
            }
        }

        public int GetNumberOfChecksToPrint(CheckbookSize checkbookSize)
        {
            return ConfigManager.ConfigurationManager.NumberOfChecks(checkbookSize);
        }
    }
}

using System;

namespace UnitTestingExamples.Example1.Shared
{
    public static class ConfigurationManager
    {
        public static int NumberOfChecksPerRow { get; set; }
        public static int NumberOfRowsPerPage { get; set; }
        public static decimal checkLength { get; set; }
        public static decimal checkWidth { get; set; }
        public static int NumberOfChecksSmallPack { get; set; }
        public static int NumberOfChecksMediumPack { get; set; }
        public static int NumberOfChecksLargePack { get; set; }

        public static int GetNumberOfChecksToPrint(CheckbookSize checkbookSize)
        {
            switch (checkbookSize)
            {
                case CheckbookSize.Small:
                    return ConfigurationManager.NumberOfChecksSmallPack;
                case CheckbookSize.Medium:
                    return ConfigurationManager.NumberOfChecksMediumPack;
                case CheckbookSize.Large:
                    return ConfigurationManager.NumberOfChecksLargePack;
                default:
                    throw new ArgumentException(nameof(checkbookSize));
            }
        }
    }
}

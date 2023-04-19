using System;

namespace UnitTestingExamples.Example1.Shared
{
    public static class ConfigurationManager
    {
        private static readonly int numberOfChecksSmallPack;

        private static readonly int numberOfChecksMediumPack;

        private static readonly int numberOfChecksLargePack;

        public static int NumberOfChecksPerRow { get; }

        public static int NumberOfRowsPerPage { get; }

        public static decimal CheckLength { get; }

        public static decimal CheckWidth { get; }

        static ConfigurationManager()
        {
            NumberOfChecksPerRow = 2;
            NumberOfRowsPerPage = 4;
            CheckLength = 6.1m;
            CheckWidth = 2.5m;
            numberOfChecksSmallPack = 20;
            numberOfChecksMediumPack = 50;
            numberOfChecksLargePack = 100;
        }


    public static int NumberOfChecks(CheckbookSize checkbookSize)
        {
            switch (checkbookSize)
            {
                case CheckbookSize.Small:
                    return numberOfChecksSmallPack;
                case CheckbookSize.Medium:
                    return numberOfChecksMediumPack;
                case CheckbookSize.Large:
                    return numberOfChecksLargePack;
                default:
                    throw new ArgumentException(nameof(checkbookSize));
            }
        }
    }
}

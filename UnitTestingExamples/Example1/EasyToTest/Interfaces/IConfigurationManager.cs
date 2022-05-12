using UnitTestingExamples.Example1.Shared;

namespace UnitTestingExamples.Example1.EasyToTest.Interfaces
{
    public interface IConfigurationManager
    {
        int NumberOfChecksLargePack { get; set; }
        int NumberOfChecksMediumPack { get; set; }
        int NumberOfChecksSmallPack { get; set; }

        int GetNumberOfChecksToPrint(CheckbookSize checkbookSize);
    }
}
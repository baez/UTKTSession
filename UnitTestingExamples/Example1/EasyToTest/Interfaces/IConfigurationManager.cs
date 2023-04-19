using UnitTestingExamples.Example1.Shared;
namespace UnitTestingExamples.Example1.EasyToTest.Interfaces
{
    public interface IConfigurationManager
    {
        int NumberOfChecksPerRow { get; }

        int NumberOfRowsPerPage { get; }

        decimal CheckLength { get; }

        decimal CheckWidth { get; }

        int GetNumberOfChecksToPrint(CheckbookSize checkbookSize);
    }
}
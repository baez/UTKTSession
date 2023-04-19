using UnitTestingExamples.Example1.Shared.DataModels;

namespace UnitTestingExamples.Example1.EasyToTest.Interfaces
{
    public interface IAccountRepository
    {
        Account Get(string accountId);

        void SetLastCheckNumber(string accountNumber, int lastCheckNumber);
    }
}
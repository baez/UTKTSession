using System;
using UnitTestingExamples.Example1.EasyToTest.Interfaces;
using UnitTestingExamples.Example1.Shared;

namespace UnitTestingExamples.Example1.EasyToTest.Shared
{
    public class AccountRepository : IAccountRepository
    {
        public Account Get(string accountId)
        {
            throw new NotImplementedException();
        }

        public void SetLastCheckNumber(string accountNumber, int lastCheckNumber)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using UnitTestingExamples.Example1.EasyToTest.Interfaces;

namespace UnitTestingExamples.Example1.Shared
{
    public class AccountRepository
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

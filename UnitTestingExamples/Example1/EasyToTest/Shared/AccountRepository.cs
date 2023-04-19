using System.Collections.Generic;
using UnitTestingExamples.Example1.EasyToTest.Interfaces;
using UnitTestingExamples.Example1.Shared;

namespace UnitTestingExamples.Example1.EasyToTest.Shared
{
    public class AccountRepository : IAccountRepository
    {
        private const string testAccount = "001746";
        private const string testId = "001746Id";

        private static readonly IDictionary<string, Account> Customers = new Dictionary<string, Account>(
            new List<KeyValuePair<string, Account>>()
            {
                new KeyValuePair<string, Account>(testAccount, new Account { AccountNumber = testAccount, Id = testId })
            });

        public Account Get(string accountId)
        {
            return Customers[accountId];
        }

        public void SetLastCheckNumber(string accountId, int lastCheckNumber)
        {
            Customers[accountId].LastPrintedCheckNumber = lastCheckNumber;
        }
    }
}

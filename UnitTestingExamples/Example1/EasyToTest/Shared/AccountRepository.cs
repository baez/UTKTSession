using System.Collections.Generic;
using ExampleApplications.Example1.Shared.DataModels;
using UnitTestingExamples.Example1.EasyToTest.Interfaces;
using UnitTestingExamples.Example1.Shared.DataModels;

namespace UnitTestingExamples.Example1.EasyToTest.Shared
{
    public class AccountRepository : IAccountRepository
    {
        private const string testAccount1 = "T0017P";
        private const string testAccountId1 = "T0017P";
        private const string testAccount2 = "T0017B";
        private const string testAccountId2 = "T0017B";
        private const string testAccount3 = "T0017E";
        private const string testAccountId3 = "T0017E";

        private static readonly IDictionary<string, Account> Customers = new Dictionary<string, Account>(
            new List<KeyValuePair<string, Account>>()
            {
                new KeyValuePair<string, Account>(
                    testAccountId1, 
                    new Account { AccountNumber = testAccount1, Id = testAccountId1, AccountType = AccountType.Personal }),
                new KeyValuePair<string, Account>(
                    testAccountId2,
                    new Account { AccountNumber = testAccount2, Id = testAccountId2, AccountType = AccountType.Personal }),
                new KeyValuePair<string, Account>(
                    testAccountId3,
                    new Account { AccountNumber = testAccount3, Id = testAccountId3, AccountType = AccountType.Personal }),
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

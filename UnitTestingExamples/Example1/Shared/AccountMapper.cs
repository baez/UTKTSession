using CheckbookPrinting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestingExamples.Example1.Shared
{
    public static class AccountMapper
    {
        public static CustomerAccount Map(Account account)
        {
            return new CustomerAccount()
            {
                AccountNumber = account.AccountNumber,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Id = account.Id,
                LastPrintedCheckNumber = account.LastPrintedCheckNumber
            };
        }
    }
}

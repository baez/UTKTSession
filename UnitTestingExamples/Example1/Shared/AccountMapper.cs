using CheckbookPrinting;
using UnitTestingExamples.Example1.Shared.DataModels;

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

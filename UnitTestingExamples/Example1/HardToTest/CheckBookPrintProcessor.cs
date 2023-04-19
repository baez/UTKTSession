using System;
using CheckbookPrinting;
using ExampleApplications.Example1.Shared.DataModels;
using UnitTestingExamples.Example1.Shared;

namespace UnitTestingExamples.Example1.HardToTest
{
    public class CheckBookPrintProcessor
    {
        public void Process(string accountNumber, CheckbookType checkbookType, CheckbookSize checkbookSize)
        {
            try
            {
                // Get the last printed check number for customer account
                var accountRepository = new AccountRepository();
                var account = accountRepository.Get(accountNumber);

                // Get the checkbook size (# of checks in a checkbook)
                var checkbookPackSize = ConfigurationManager.NumberOfChecks(checkbookSize);

                // Map to PrintLibrary CustomerAccount
                var customerAccount = AccountMapper.Map(account);

                // Print the checks
                var printResult = CheckbookPrinter.Print(customerAccount, checkbookType, checkbookPackSize);
                if (printResult.Success)
                {
                    // Update user account with the last printed check number
                    var lastPrintedCheckNumber = customerAccount.LastPrintedCheckNumber + checkbookPackSize;
                    accountRepository.SetLastCheckNumber(customerAccount.AccountNumber, Convert.ToInt32(printResult.LastPrintedCheckNumber));
                }
                else
                {
                    var msg = string.Format("CheckbookPrinter Error: {0}", printResult.ErrorCode);
                    Console.WriteLine(msg);
                    throw new Exception(msg);
                }

                // Print customer invoice
                var invoiceAmount = this.CalculateInvoice(account.AccountType, checkbookType, checkbookSize);
                CheckbookPrinter.PrintInvoice(customerAccount, invoiceAmount);
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Additional business logic April 2023: 
        /// Customer will be invoiced based on account type, checkbook type and size
        /// We need to print the invode along witht checkbook and send it in the package
        ///     AccountType     CheckbookType & cost
        ///     -----------     --------------------
        ///     Personal        Standard:free, Business - small:$20, medium:$40, large:$50, Elite - small:$30, medium:$50, large:$60
        ///     Business        Standard:free, Business:free, Elite - Elite - small:$10, medium:$30, large:$40
        ///     BusinessElite   Free
        /// </summary>
        /// <param name="accoutType"></param>
        /// <param name="checkbookType"></param>
        /// <param name="checkbookSize"></param>
        /// <returns></returns>
        private decimal CalculateInvoice(AccountType accountType, CheckbookType checkbookType, CheckbookSize checkbookSize)
        {
            switch (accountType)
            {
                case AccountType.Personal:
                    if (checkbookType == CheckbookType.Business)
                    {
                        if (checkbookSize == CheckbookSize.Small)
                            return 20m;
                        else if (checkbookSize == CheckbookSize.Medium)
                            return 40m;
                        else if (checkbookSize == CheckbookSize.Large)
                            return 50m;
                    }
                    else if (checkbookType == CheckbookType.Elite)
                    {
                        if (checkbookSize == CheckbookSize.Small)
                            return 30m;
                        else if (checkbookSize == CheckbookSize.Medium)
                            return 50m;
                        else if (checkbookSize == CheckbookSize.Large)
                            return 60m;
                    }
                    return 0m;
                case AccountType.Business:
                    if (checkbookType == CheckbookType.Elite)
                    {
                        if (checkbookSize == CheckbookSize.Small)
                            return 10m;
                        else if (checkbookSize == CheckbookSize.Medium)
                            return 30m;
                        else if (checkbookSize == CheckbookSize.Large)
                            return 40m;
                    }
                    return 0m;
                default:
                    return 0m;
            }
        }
    }
}

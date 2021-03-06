using CheckbookPrinting;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestingExamples.Example1.Shared;

namespace UnitTestingExamples.Example1.HardToTest
{
    public class CheckBookRequestProcessor
    {
        public bool Process(string accountNumber, CheckbookType checkbookType, CheckbookSize checkbookSize)
        {
            try
            {
                // Get the last printed check number for customer account
                var accountRepository = new AccountRepository();
                var account = accountRepository.Get(accountNumber);

                // Get the checkbook size (# of checks in a checkbook)
                var checkbookPackSize = ConfigurationManager.GetNumberOfChecksToPrint(checkbookSize);

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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }
    }
}

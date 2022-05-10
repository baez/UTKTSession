using System;
using System.Collections.Generic;
using System.Text;
using UnitTestingExamples.Example1.Shared;

namespace UnitTestingExamples.Example1.HardToTest
{
    public class CheckBookRequestProcessor
    {
        public int Process(string userId, int numberOfChecks)
        {
            int lastPrintedCheckNumber = 0;
            try
            {
                var userDatabase = new UserRepository();
                var user = userDatabase.Get(userId);

                var accountRepository = new AccountRepository();
                lastPrintedCheckNumber = accountRepository.GetLastCheckNumber(user.AccountNumber);

                CheckbookPrinter.Print(user, lastPrintedCheckNumber, numberOfChecks);

                var printDateTime = DateTime.Now;
                CheckbookPrinter.Print(printDateTime);

                lastPrintedCheckNumber = lastPrintedCheckNumber + numberOfChecks;
                accountRepository.SetLastCheckNumber(user.AccountNumber, lastPrintedCheckNumber);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            return lastPrintedCheckNumber;
        }
    }
}

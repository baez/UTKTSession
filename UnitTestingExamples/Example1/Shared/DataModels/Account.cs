namespace UnitTestingExamples.Example1.Shared.DataModels
{
    using ExampleApplications.Example1.Shared.DataModels;

    public class Account
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AccountNumber { get; set; }

        public int LastPrintedCheckNumber { get; set; }

        public AccountType AccountType { get; set; }
    }
}

namespace CheckbookPrinting
{
    public class CustomerAccount
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountNumber { get; set; }
        public int LastPrintedCheckNumber { get; set; }
    }
}

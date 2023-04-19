namespace CheckbookPrinting
{
    public class CheckbookPrintResult
    {
        public bool Success { get; set; }
        public int ErrorCode { get; set; }
        public int LastPrintedCheckNumber { get; set; }
    }
}

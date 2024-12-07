using System.Data.SqlTypes;

namespace MLC.Models
{
    public class PCFile
    {
        public string? Reference { get; set; }
        public string? TransactionDate { get; set; }
        public string? Description { get; set; }
        public string? AcctNo { get; set; }
        public decimal? Debit { get; set; }
        public decimal? Credit { get; set; }
        public string? LineDescr {  get; set; }
    }
}

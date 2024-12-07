
namespace MLC.Models
{

    public class BMO
    {
        public int PMT_NR { get; set; }
        public decimal Amount { get; set; }
        public decimal Bank { get; set; }
        public decimal Transit { get; set; }
        public string Account { get; set; }
        public string? Reference { get; set; }
        public string? Memo { get; set; }   
        public decimal CPA { get; set; }

    }
}

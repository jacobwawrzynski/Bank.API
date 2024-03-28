using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Account : ModelBase
    {
        public string AccountNumber { get; set; }
        public string Currency { get; set; }
        public double Balance { get; set; }
        public string? UserId { get; set; }
        public User? User { get; set; }
        public ICollection<TransactionHistory> History { get; set; }
    }
}

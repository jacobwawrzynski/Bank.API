using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Transaction : ModelBase
    {
        public string AccountId { get; set; }
        public Account Account { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public double Amount { get; set; }
    }
}

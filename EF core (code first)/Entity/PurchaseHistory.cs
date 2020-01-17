using System;
using System.Collections.Generic;
using System.Text;

namespace EF_core__code_first_.Entity
{
    public sealed class PurchaseHistory
    {
        public long UserId { get; set; }
        public long ProductId { get; set; }

        public User User { get; set; }
        public Product Product { get; set; }

        public DateTime Date { get; set; }
    }
}

using System.Collections.Generic;

namespace EF_core__code_first_.Entity
{
    public sealed class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string Type { get; set; }
        public string Brand { get; set; }

        public IEnumerable<PurchaseHistory> PurchaseHistories { get; set; }

        public Product()
        {
            PurchaseHistories = new List<PurchaseHistory>();
        }
    }
}

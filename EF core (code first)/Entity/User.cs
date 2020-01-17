using System.Collections.Generic;

namespace EF_core__code_first_.Entity
{
    public class User
    {
        public long ID { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }

        public Person Person { get; set; }
        public SpecialQuestion SpecialQuestion { get; set; }
        public IEnumerable<PurchaseHistory> PurchaseHistories { get; set; }

        public User()
        {
            PurchaseHistories = new List<PurchaseHistory>();
        }
    }
}

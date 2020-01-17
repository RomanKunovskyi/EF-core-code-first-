using System;

namespace EF_core__code_first_.Entity
{
    public sealed class Person
    {
        public long UserId { get; set; }
        public User User { get; set; }


        public string Name { get; set; }
        public string Surname { get; set; }
        public long? PhoneNumber { get; set; }
        public DateTime BornDate { get; set; }
        public string Address { get; set; }

    }
}

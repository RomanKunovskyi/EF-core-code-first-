namespace EF_core__code_first_.Entity
{
    public sealed class SpecialQuestion
    {
        public long UserId { get; set; }
        public User User { get; set; }

        public string Question { get; set; }
        public string Answer { get; set; }
    }
}

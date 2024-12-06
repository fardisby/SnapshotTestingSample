namespace SnapshotTestingSample.Entity
{
    public class Account
    {
        public Guid AccounID { get; set; }
        public string? AccountName { get; set; }
        public string? Currency { get; set; }
        public string? Country { get; set; }
        public bool LocalAccount { get; set; }
        public bool Active { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}

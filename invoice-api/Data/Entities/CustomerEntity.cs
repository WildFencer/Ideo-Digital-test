using invoice_api.Data.Enums;

namespace invoice_api.Data.Entities
{
    public class CustomerEntity
    {
        public int Id { get; set; }
        public string? Surname { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public SubscripsionPeriodEnum SubscripsionPeriod { get; set; }
    }
}

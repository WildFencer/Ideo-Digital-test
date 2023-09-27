namespace invoice_api.Data.Entities
{
    public class InvoiceEntity
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public int CustomerId { get; set;}
        public int BillingStatusId { get; set; }
        public DateTime CreateDate { get; set; }


    }
}

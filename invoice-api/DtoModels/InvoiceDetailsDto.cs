namespace invoice_api.DtoModels
{
    public record InvoiceDetailsDto(int Id, decimal Amount, string Description, string CustomerName, string BillingPeriod, int BillingStatusId, DateTime CreateDate);
}

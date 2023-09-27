namespace invoice_api.DtoModels
{
    public record InvoiceDto(int Id, decimal Amount, string BillingStatus, DateTime CreateDate);
}

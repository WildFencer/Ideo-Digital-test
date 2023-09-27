namespace invoice_api.DtoModels
{
    public record UpdateInvoiceDto(int Id, decimal Amount, string Description, int CustomerId, int BillingStatusId);
}

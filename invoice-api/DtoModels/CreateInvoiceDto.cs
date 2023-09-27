namespace invoice_api.DtoModels
{
    public record CreateInvoiceDto(decimal Amount, string Description, int CustomerId, int BillingStatusId);
}

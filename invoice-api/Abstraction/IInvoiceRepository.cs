using invoice_api.DtoModels;

namespace invoice_api.Abstraction
{
    public interface IInvoiceRepository
    {
        Task<List<InvoiceDto>> GetAll();
        Task<InvoiceDetailsDto?> Get(int id);
        Task<InvoiceDetailsDto> Add(CreateInvoiceDto model);
        Task<InvoiceDetailsDto> Update(UpdateInvoiceDto model);
        Task Delete(int invoiceId);
    }
}

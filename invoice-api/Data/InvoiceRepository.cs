using invoice_api.Abstraction;
using invoice_api.Data.Entities;
using invoice_api.Data.Enums;
using invoice_api.DtoModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace invoice_api.Data
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IdeoDbContext _context;

        public InvoiceRepository(IdeoDbContext context)
        {
            _context = context;
        }

        public async Task<InvoiceDetailsDto> Add(CreateInvoiceDto model)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(i => i.Id == model.CustomerId);
            if (customer is null)
                throw new ArgumentException($"Error creating invoice. No customer with Id: {model.CustomerId}");

            var newInvoice = new InvoiceEntity()
            {
                Amount = model.Amount,
                CustomerId = model.CustomerId,
                Description = model.Description,
                BillingStatusId = model.BillingStatusId,
                CreateDate = DateTime.Today,
            };
            _context.Invoices.Add(newInvoice);
            await _context.SaveChangesAsync();

            return EntityToDetailDto(newInvoice, customer);
        }

        public async Task Delete(int invoiceId)
        {
            var invoice = await _context.Invoices.FindAsync(invoiceId);

            if (invoice == null)
                throw new ArgumentException($"Error deleting house with Id: {invoiceId}");

            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task<InvoiceDetailsDto?> Get(int id)
        {
            var invoice = await _context.Invoices.FirstOrDefaultAsync(i=> i.Id == id);

            if (invoice is null)
                return null;

            var customer = await _context.Customers.FirstOrDefaultAsync(i => i.Id == invoice.CustomerId);
            var billingPeriod = GetBillingPeriod(invoice.CreateDate, customer?.SubscripsionPeriod ?? SubscripsionPeriodEnum.None);

            return new InvoiceDetailsDto(invoice.Id, invoice.Amount, invoice.Description ?? "", $"{customer?.Name} {customer?.Surname}", billingPeriod, invoice.BillingStatusId, invoice.CreateDate);
        }

        public async Task<List<InvoiceDto>> GetAll()
        {
            var billingStatusesDB = await _context.BillingStatuses.ToListAsync();
            var billingStatuses = new Dictionary<int, string>();
            billingStatusesDB.ForEach(bs => billingStatuses.Add(bs.Id, bs.StatusName));

            return await _context.Invoices.Select(i =>
                new InvoiceDto(i.Id, i.Amount, billingStatuses[i.BillingStatusId], i.CreateDate)).ToListAsync();
        }

        public async Task<InvoiceDetailsDto> Update(UpdateInvoiceDto model)
        {
            var invoice = await _context.Invoices.FindAsync(model.Id);
            if (invoice == null)
                throw new ArgumentException($"Error updating invoice with Id: {model.Id}");

            var customer = await _context.Customers.FirstOrDefaultAsync(i => i.Id == model.CustomerId);
            if (customer is null)
                throw new ArgumentException($"Error updating invoice. No customer with Id: {model.CustomerId}");


            invoice.Amount = model.Amount;
            invoice.CustomerId = model.CustomerId;
            invoice.Description = model.Description;
            invoice.BillingStatusId = model.BillingStatusId;

            _context.Entry(invoice).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return EntityToDetailDto(invoice, customer);
        }

        private string GetBillingPeriod(DateTime invoiceDate, SubscripsionPeriodEnum subscribtionPeriod)
        {
            switch (subscribtionPeriod)
            {
                case SubscripsionPeriodEnum.None:
                    return "Unknown";
                case SubscripsionPeriodEnum.Daily:
                    return $"{invoiceDate.AddDays(-1).ToShortDateString()} - {invoiceDate.ToShortDateString()}";
                case SubscripsionPeriodEnum.Weekly:
                    return $"{invoiceDate.AddDays(-7).ToShortDateString()} - {invoiceDate.ToShortDateString()}";
                case SubscripsionPeriodEnum.Monthly:
                    return $"{invoiceDate.AddMonths(-1).ToShortDateString()} - {invoiceDate.ToShortDateString()}";
                case SubscripsionPeriodEnum.Yearly:
                    return $"{invoiceDate.AddYears(-1).ToShortDateString()} - {invoiceDate.ToShortDateString()}";
                default:
                    return "Unknown";
            }
        }

        private InvoiceDetailsDto EntityToDetailDto(InvoiceEntity entity, CustomerEntity customer)
        {
            return new InvoiceDetailsDto(
                entity.Id,
                entity.Amount,
                entity.Description ?? "",
                $"{customer?.Name} {customer?.Surname}",
                GetBillingPeriod(entity.CreateDate, customer.SubscripsionPeriod),
                entity.BillingStatusId,
                entity.CreateDate);
        }

    }
}

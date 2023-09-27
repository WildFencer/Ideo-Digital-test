using invoice_api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace invoice_api.Data
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<CustomerEntity>().HasData(new List<CustomerEntity>
            {
                new CustomerEntity
                {
                    Id = 1,
                    Name = "John",
                    Surname = "Dow",
                    Email = "jdow@gmail.com",
                    Address = "New York, USA",
                    SubscripsionPeriod = Enums.SubscripsionPeriodEnum.Weekly
                },
                new CustomerEntity
                {
                    Id = 2,
                    Name = "Israel",
                    Surname = "Israeli",
                    Email = "iisraeli@gmail.com",
                    Address = "Tel Aviv, Israel",
                    SubscripsionPeriod = Enums.SubscripsionPeriodEnum.Monthly
                },
                new CustomerEntity
                {
                    Id = 3,
                    Name = "Vasiliy",
                    Surname = "Pupkin",
                    Email = "vpupkin@mail.ru",
                    Address = "Saint Petersburg, Russian Federation",
                    SubscripsionPeriod = Enums.SubscripsionPeriodEnum.Daily
                }
            });

            builder.Entity<BillingStatusEntity>().HasData(new List<BillingStatusEntity>
            {
                new BillingStatusEntity
                {
                    Id = 1,
                    StatusName = "Pending"
                },
                new BillingStatusEntity
                {
                    Id = 2,
                    StatusName = "Paid"
                },
                new BillingStatusEntity
                {
                    Id = 3,
                    StatusName = "Overdue"
                }
            });

            builder.Entity<InvoiceEntity>().HasData(new List<InvoiceEntity>
            {
                new InvoiceEntity
                {
                    Id=1,
                    Description = "Tools",
                    Amount = 100,
                    CustomerId = 1,
                    BillingStatusId = 2,
                    CreateDate = new DateTime(2023, 9, 20)
                },
                new InvoiceEntity
                {
                    Id=2,
                    Description = "Software",
                    Amount = 1000,
                    CustomerId = 2,
                    BillingStatusId = 2,
                    CreateDate = new DateTime(2023, 7, 15)
                },
                new InvoiceEntity
                {
                    Id=3,
                    Description = "Toys",
                    Amount = 300,
                    CustomerId = 3,
                    BillingStatusId = 2,
                    CreateDate = new DateTime(2023, 9, 25)
                },
                new InvoiceEntity
                {
                    Id=4,
                    Description = "Vinille music disks",
                    Amount = 800,
                    CustomerId = 2,
                    BillingStatusId = 1,
                    CreateDate = new DateTime(2023, 8, 15)
                },
                new InvoiceEntity
                {
                    Id=5,
                    Description = "Vitamins",
                    Amount = 150,
                    CustomerId = 3,
                    BillingStatusId = 3,
                    CreateDate = new DateTime(2023, 9, 26)
                }
            });

        }
    }
}

using invoice_api.Abstraction;
using invoice_api.Data;
using invoice_api.DtoModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddDbContext<IdeoDbContext>(o =>
    o.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(p => p.WithOrigins("http://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod());

app.UseHttpsRedirection();

app.MapGet("/api/invoices", (IInvoiceRepository repo) => repo.GetAll())
    .Produces<InvoiceDto[]>(StatusCodes.Status200OK);

app.MapGet("/api/invoice/{invoiceId:int}", async (int invoiceId, IInvoiceRepository repo) =>
{
    var invoice = await repo.Get(invoiceId);
    if (invoice is null)
        return Results.Problem($"Invoice with ID {invoiceId} not found", statusCode: 404);
    return Results.Ok(invoice);
}).ProducesProblem(404).Produces<InvoiceDetailsDto>(StatusCodes.Status200OK);

app.MapPost("/api/invoices", async ([FromBody] CreateInvoiceDto model, IInvoiceRepository repo) =>
{
    var newInvoice = await repo.Add(model);
    return Results.Created($"/api/invoice/{newInvoice.Id}", newInvoice);
}).ProducesProblem(404).Produces<InvoiceDetailsDto?>(StatusCodes.Status201Created);

app.MapPut("/api/invoice", async ([FromBody] UpdateInvoiceDto model, IInvoiceRepository repo) =>
{
    if (await repo.Get(model.Id) is null)
        return Results.Problem($"Invoice with Id: {model.Id} was not found", statusCode: 404);

    var updatedInvoice = await repo.Update(model);
    return Results.Ok(updatedInvoice);
}).ProducesProblem(404).Produces<InvoiceDetailsDto?>(StatusCodes.Status200OK);

app.MapDelete("/api/invoice/{invoiceId:int}", async (int invoiceId, IInvoiceRepository repo) =>
{
    if (await repo.Get(invoiceId) is null)
        return Results.Problem($"Invoice with Id: {invoiceId} was not found", statusCode: 404);

    await repo.Delete(invoiceId);
    return Results.Ok();
}).ProducesProblem(404).Produces(StatusCodes.Status200OK);

app.Run();

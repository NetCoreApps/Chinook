using System;
using Chinook.ServiceModel.Types;
using ServiceStack;

namespace Chinook.ServiceModel;

[Route("/customers", "POST"), Tag(Tags.Store)]
public class CreateCustomers
    : IReturn<IdResponse>, IPost, ICreateDb<Customers>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public long? SupportRepId { get; set; }
}

[Route("/employees", "POST"), Tag(Tags.Store)]
public class CreateEmployees
    : IReturn<IdResponse>, IPost, ICreateDb<Employees>
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Title { get; set; }
    public long? ReportsTo { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? HireDate { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
}

[Route("/invoiceitems", "POST"), Tag(Tags.Store)]
public class CreateInvoiceItems
    : IReturn<IdResponse>, IPost, ICreateDb<InvoiceItems>
{
    public long InvoiceId { get; set; }
    public long TrackId { get; set; }
    public decimal UnitPrice { get; set; }
    public long Quantity { get; set; }
}

[Route("/invoices", "POST"), Tag(Tags.Store)]
public class CreateInvoices
    : IReturn<IdResponse>, IPost, ICreateDb<Invoices>
{
    public long CustomerId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public string BillingAddress { get; set; }
    public string BillingCity { get; set; }
    public string BillingState { get; set; }
    public string BillingCountry { get; set; }
    public string BillingPostalCode { get; set; }
    public decimal Total { get; set; }
}

[Route("/customers/{CustomerId}", "DELETE"), Tag(Tags.Store)]
public class DeleteCustomers
    : IReturn<IdResponse>, IDelete, IDeleteDb<Customers>
{
    public long CustomerId { get; set; }
}

[Route("/employees/{EmployeeId}", "DELETE"), Tag(Tags.Store)]
public class DeleteEmployees
    : IReturn<IdResponse>, IDelete, IDeleteDb<Employees>
{
    public long EmployeeId { get; set; }
}

[Route("/invoiceitems/{InvoiceLineId}", "DELETE"), Tag(Tags.Store)]
public class DeleteInvoiceItems
    : IReturn<IdResponse>, IDelete, IDeleteDb<InvoiceItems>
{
    public long InvoiceLineId { get; set; }
}

[Route("/invoices/{InvoiceId}", "DELETE"), Tag(Tags.Store)]
public class DeleteInvoices
    : IReturn<IdResponse>, IDelete, IDeleteDb<Invoices>
{
    public long InvoiceId { get; set; }
}

[Route("/customers/{CustomerId}", "PATCH"), Tag(Tags.Store)]
public class PatchCustomers
    : IReturn<IdResponse>, IPatch, IPatchDb<Customers>
{
    public long CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public long? SupportRepId { get; set; }
}

[Route("/employees/{EmployeeId}", "PATCH"), Tag(Tags.Store)]
public class PatchEmployees
    : IReturn<IdResponse>, IPatch, IPatchDb<Employees>
{
    public long EmployeeId { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Title { get; set; }
    public long? ReportsTo { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? HireDate { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
}

[Route("/invoiceitems/{InvoiceLineId}", "PATCH"), Tag(Tags.Store)]
public class PatchInvoiceItems
    : IReturn<IdResponse>, IPatch, IPatchDb<InvoiceItems>
{
    public long InvoiceLineId { get; set; }
    public long InvoiceId { get; set; }
    public long TrackId { get; set; }
    public decimal UnitPrice { get; set; }
    public long Quantity { get; set; }
}

[Route("/invoices/{InvoiceId}", "PATCH"), Tag(Tags.Store)]
public class PatchInvoices
    : IReturn<IdResponse>, IPatch, IPatchDb<Invoices>
{
    public long InvoiceId { get; set; }
    public long CustomerId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public string BillingAddress { get; set; }
    public string BillingCity { get; set; }
    public string BillingState { get; set; }
    public string BillingCountry { get; set; }
    public string BillingPostalCode { get; set; }
    public decimal Total { get; set; }
}

[Route("/customers", "GET"), Tag(Tags.Store)]
[Route("/customers/{CustomerId}", "GET")]
public class QueryCustomers
    : QueryDb<Customers>, IReturn<QueryResponse<Customers>>, IGet
{
    public long? CustomerId { get; set; }
}

[Route("/employees", "GET"), Tag(Tags.Store)]
[Route("/employees/{EmployeeId}", "GET")]
public class QueryEmployees
    : QueryDb<Employees>, IReturn<QueryResponse<Employees>>, IGet
{
    public long? EmployeeId { get; set; }
}

[Route("/invoiceitems", "GET"), Tag(Tags.Store)]
[Route("/invoiceitems/{InvoiceLineId}", "GET")]
public class QueryInvoiceItems
    : QueryDb<InvoiceItems>, IReturn<QueryResponse<InvoiceItems>>, IGet
{
    public long? InvoiceLineId { get; set; }
}

[Route("/invoices", "GET"), Tag(Tags.Store)]
[Route("/invoices/{InvoiceId}", "GET")]
public class QueryInvoices
    : QueryDb<Invoices>, IReturn<QueryResponse<Invoices>>, IGet
{
    public long? InvoiceId { get; set; }
}

[Route("/customers/{CustomerId}", "PUT"), Tag(Tags.Store)]
public class UpdateCustomers
    : IReturn<IdResponse>, IPut, IUpdateDb<Customers>
{
    public long CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
    public long? SupportRepId { get; set; }
}

[Route("/employees/{EmployeeId}", "PUT"), Tag(Tags.Store)]
public class UpdateEmployees
    : IReturn<IdResponse>, IPut, IUpdateDb<Employees>
{
    public long EmployeeId { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Title { get; set; }
    public long? ReportsTo { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTime? HireDate { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Email { get; set; }
}

[Route("/invoiceitems/{InvoiceLineId}", "PUT"), Tag(Tags.Store)]
public class UpdateInvoiceItems
    : IReturn<IdResponse>, IPut, IUpdateDb<InvoiceItems>
{
    public long InvoiceLineId { get; set; }
    public long InvoiceId { get; set; }
    public long TrackId { get; set; }
    public decimal UnitPrice { get; set; }
    public long Quantity { get; set; }
}

[Route("/invoices/{InvoiceId}", "PUT"), Tag(Tags.Store)]
public class UpdateInvoices
    : IReturn<IdResponse>, IPut, IUpdateDb<Invoices>
{
    public long InvoiceId { get; set; }
    public long CustomerId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public string BillingAddress { get; set; }
    public string BillingCity { get; set; }
    public string BillingState { get; set; }
    public string BillingCountry { get; set; }
    public string BillingPostalCode { get; set; }
    public decimal Total { get; set; }
}

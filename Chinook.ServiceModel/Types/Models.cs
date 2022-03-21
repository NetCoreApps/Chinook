using System;
using ServiceStack;
using ServiceStack.DataAnnotations;

namespace Chinook.ServiceModel.Types;

[Icon(Svg = "<svg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor' aria-hidden='true'><g fill='none' stroke-width='1.5'><path stroke='currentColor' d='M2 17.4V2.6a.6.6 0 0 1 .6-.6h14.8a.6.6 0 0 1 .6.6v14.8a.6.6 0 0 1-.6.6H2.6a.6.6 0 0 1-.6-.6Z'/><path stroke='currentColor' stroke-linecap='round' d='M8 22h13.4a.6.6 0 0 0 .6-.6V8'/><path fill='currentColor' d='M11 12.5a1.5 1.5 0 1 1-3 0a1.5 1.5 0 0 1 3 0Z'/><path stroke='currentColor' stroke-linecap='round' d='M11 12.5a1.5 1.5 0 1 1-3 0a1.5 1.5 0 0 1 3 0Zm0 0V6.6a.6.6 0 0 1 .6-.6H13'/></g></svg>")]
public class Albums
{
    [AutoIncrement]
    public long AlbumId { get; set; }

    [Required]
    public string Title { get; set; }

    [Ref(Model = nameof(Artists), RefId = nameof(ArtistId), RefLabel = nameof(Artists.Name))]
    public long ArtistId { get; set; }
}

[Icon(Svg = "<svg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor' aria-hidden='true'><path fill='currentColor' d='M12 2a9 9 0 0 0-9 9c0 4.17 2.84 7.67 6.69 8.69L12 22l2.31-2.31C18.16 18.67 21 15.17 21 11a9 9 0 0 0-9-9zm0 2c1.66 0 3 1.34 3 3s-1.34 3-3 3s-3-1.34-3-3s1.34-3 3-3zm0 14.3a7.2 7.2 0 0 1-6-3.22c.03-1.99 4-3.08 6-3.08c1.99 0 5.97 1.09 6 3.08a7.2 7.2 0 0 1-6 3.22z'/></svg>")]
public class Artists
{
    [AutoIncrement]
    public long ArtistId { get; set; }

    public string Name { get; set; }
}

[Icon(Svg = "<svg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor' aria-hidden='true'><path fill='currentColor' d='M19 2H5a2 2 0 0 0-2 2v14c0 1.1.9 2 2 2h4l2.29 2.29c.39.39 1.02.39 1.41 0L15 20h4c1.1 0 2-.9 2-2V4c0-1.1-.9-2-2-2zm-7 3.3c1.49 0 2.7 1.21 2.7 2.7s-1.21 2.7-2.7 2.7S9.3 9.49 9.3 8s1.21-2.7 2.7-2.7zM18 16H6v-.9c0-2 4-3.1 6-3.1s6 1.1 6 3.1v.9z'/></svg>")]
public class Customers
{
    [AutoIncrement]
    public long CustomerId { get; set; }

    [Computed]
    public string DisplayName => FirstName + " " + LastName;

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
    
    [Ref(Model = nameof(Employees), RefId = nameof(Employees.EmployeeId), RefLabel = nameof(Employees.LastName))]
    public long? SupportRepId { get; set; }

    public string Company { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    [Required]
    public string Email { get; set; }
}

[Icon(Svg = "<svg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor' aria-hidden='true'><path fill='currentColor' d='M19.745 4a2.25 2.25 0 0 1 2.25 2.25v11.505a2.25 2.25 0 0 1-2.25 2.25H4.25A2.25 2.25 0 0 1 2 17.755V6.25A2.25 2.25 0 0 1 4.25 4h15.495Zm0 1.5H4.25a.75.75 0 0 0-.75.75v11.505c0 .414.336.75.75.75l2.749-.001L7 15.75a1.75 1.75 0 0 1 1.606-1.744L8.75 14h6.495a1.75 1.75 0 0 1 1.744 1.607l.006.143l-.001 2.754h2.751a.75.75 0 0 0 .75-.75V6.25a.75.75 0 0 0-.75-.75ZM12 7a3 3 0 1 1 0 6a3 3 0 0 1 0-6Z'/></svg>")]
public class Employees
{
    [AutoIncrement]
    public long EmployeeId { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string FirstName { get; set; }

    public string Title { get; set; }
    [Ref(Model = nameof(Employees), RefId = nameof(ReportsTo), RefLabel = nameof(LastName))]
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

[Icon(Svg = "<svg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor' aria-hidden='true'><g fill='none' stroke-width='1.5'><path stroke='currentColor' stroke-linecap='round' stroke-linejoin='round' d='M15 2.2c4.564.926 8 4.962 8 9.8c0 4.838-3.436 8.873-8 9.8'/><path stroke='currentColor' stroke-linecap='round' stroke-linejoin='round' d='M15 9c1.141.284 2 1.519 2 3s-.859 2.716-2 3M1 2h10v20H1'/><path fill='currentColor' d='M4 15.5a1.5 1.5 0 1 1-3 0a1.5 1.5 0 0 1 3 0Z'/><path stroke='currentColor' stroke-linecap='round' d='M4 15.5a1.5 1.5 0 1 1-3 0a1.5 1.5 0 0 1 3 0Zm0 0V7.6a.6.6 0 0 1 .6-.6H7'/></g></svg>")]
public class Genres
{
    [AutoIncrement]
    public long GenreId { get; set; }

    public string Name { get; set; }
}

[Icon(Svg = "<svg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor' aria-hidden='true'><g fill='none' stroke='currentColor' stroke-linecap='round' stroke-linejoin='round' stroke-width='2'><path d='M11 5h10m-10 7h10m-10 7h10'/><rect width='4' height='4' x='3' y='3' rx='1'/><rect width='4' height='4' x='3' y='10' rx='1'/><rect width='4' height='4' x='3' y='17' rx='1'/></g></svg>")]
[Alias("invoice_items")]
public class InvoiceItems
{
    [AutoIncrement]
    public long InvoiceLineId { get; set; }

    [Ref(Model = nameof(Invoices), RefId = nameof(InvoiceId), RefLabel = nameof(Invoices.BillingAddress))]
    public long InvoiceId { get; set; }
    [Ref(Model = nameof(Tracks), RefId = nameof(TrackId), RefLabel = nameof(Tracks.Name))]
    public long TrackId { get; set; }
    [Format(FormatMethods.Currency)]
    public decimal UnitPrice { get; set; }
    public long Quantity { get; set; }
}

[Icon(Svg = "<svg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor' aria-hidden='true'><path fill='currentColor' d='M21 11h-3V4a1 1 0 0 0-1-1H3a1 1 0 0 0-1 1v14c0 1.654 1.346 3 3 3h14c1.654 0 3-1.346 3-3v-6a1 1 0 0 0-1-1zM5 19a1 1 0 0 1-1-1V5h12v13c0 .351.061.688.171 1H5zm15-1a1 1 0 0 1-2 0v-5h2v5z'/><path fill='currentColor' d='M6 7h8v2H6zm0 4h8v2H6zm5 4h3v2h-3z'/></svg>")]
public class Invoices
{
    [AutoIncrement]
    public long InvoiceId { get; set; }

    [Ref(Model = nameof(Customers), RefId = nameof(CustomerId), RefLabel = nameof(Customers.DisplayName))]
    public long CustomerId { get; set; }
    public DateTime InvoiceDate { get; set; }
    [Format(FormatMethods.Currency)]
    public decimal Total { get; set; }
    public string BillingAddress { get; set; }
    public string BillingCity { get; set; }
    public string BillingState { get; set; }
    public string BillingCountry { get; set; }
    public string BillingPostalCode { get; set; }
}

[Icon(Svg = "<svg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor' aria-hidden='true'><g fill='none' stroke='currentColor' stroke-linecap='round' stroke-linejoin='round' stroke-width='2'><path d='M14 3v4a1 1 0 0 0 1 1h4'/><path d='M17 21H7a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h7l5 5v11a2 2 0 0 1-2 2z'/><circle cx='11' cy='16' r='1'/><path d='M12 16v-5l2 1'/></g></svg>")]
[Alias("media_types")]
public class MediaTypes
{
    [AutoIncrement]
    public long MediaTypeId { get; set; }

    public string Name { get; set; }
}

[Icon(Svg = "<svg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor' aria-hidden='true'><path fill='currentColor' d='M15 6H3v2h12V6m0 4H3v2h12v-2M3 16h8v-2H3v2M17 6v8.18c-.31-.11-.65-.18-1-.18a3 3 0 0 0-3 3a3 3 0 0 0 3 3a3 3 0 0 0 3-3V8h3V6h-5Z'/></svg>")]
public class Playlists
{
    [AutoIncrement]
    public long PlaylistId { get; set; }

    public string Name { get; set; }
}

[Icon(Svg = "<svg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor' aria-hidden='true'><path fill='currentColor' d='M12 3v9.28a4.39 4.39 0 0 0-1.5-.28C8.01 12 6 14.01 6 16.5S8.01 21 10.5 21c2.31 0 4.2-1.75 4.45-4H15V6h4V3h-7z'/></svg>")]
public class Tracks
{
    [AutoIncrement]
    public long TrackId { get; set; }

    [Required]
    [Format(Method = "stylize", Options = "{cls:'text-pink-700'}")]
    public string Name { get; set; }

    [Ref(Model = nameof(Albums), RefId = nameof(AlbumId), RefLabel = nameof(Albums.Title))]
    public long? AlbumId { get; set; }
    [Ref(Model = nameof(MediaTypes), RefId = nameof(MediaTypeId), RefLabel = nameof(MediaTypes.Name))]
    public long MediaTypeId { get; set; }
    [Ref(Model = nameof(Genres), RefId = nameof(Tracks.GenreId), RefLabel = nameof(Genres.Name))]
    public long? GenreId { get; set; }
    public string Composer { get; set; }
    [IntlDateTime(Minute = DatePart.Digits2, Second = DatePart.Digits2, FractionalSecondDigits = 3)]
    public long Milliseconds { get; set; }
    [Format(FormatMethods.Bytes)]
    public long? Bytes { get; set; }
    [Format(FormatMethods.Currency)]
    public decimal UnitPrice { get; set; }
}

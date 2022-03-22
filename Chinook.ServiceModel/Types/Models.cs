using System;
using ServiceStack;
using ServiceStack.DataAnnotations;

namespace Chinook.ServiceModel.Types;

[Icon(Svg = Icons.Albums)]
public class Albums
{
    [AutoIncrement]
    public long AlbumId { get; set; }

    [Required]
    public string Title { get; set; }

    [Ref(Model = nameof(Artists), RefId = nameof(ArtistId), RefLabel = nameof(Artists.Name))]
    public long ArtistId { get; set; }
}

[Icon(Svg = Icons.Artists)]
public class Artists
{
    [AutoIncrement]
    public long ArtistId { get; set; }

    public string Name { get; set; }
}

[Icon(Svg = Icons.Customers)]
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

[Icon(Svg = Icons.Employees)]
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

[Icon(Svg = Icons.Genres)]
public class Genres
{
    [AutoIncrement]
    public long GenreId { get; set; }

    public string Name { get; set; }
}

[Icon(Svg = Icons.InvoiceItems)]
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

[Icon(Svg = Icons.Invoices)]
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

[Icon(Svg = Icons.MediaTypes)]
[Alias("media_types")]
public class MediaTypes
{
    [AutoIncrement]
    public long MediaTypeId { get; set; }

    public string Name { get; set; }
}

[Icon(Svg = Icons.Playlists)]
public class Playlists
{
    [AutoIncrement]
    public long PlaylistId { get; set; }

    public string Name { get; set; }
}

[Icon(Svg = Icons.Tracks)]
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

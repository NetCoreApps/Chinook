/* Options:
Date: 2021-03-30 01:55:03
Version: 5.105
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: https://localhost:5001
UsePath: /crud/all/csharp

//GlobalNamespace: 
//MakePartial: False
//MakeVirtual: False
//MakeInternal: False
//MakeDataContractsExtensible: False
//AddReturnMarker: True
//AddDescriptionAsComments: True
//AddDataContractAttributes: True
//AddIndexesToDataMembers: True
//AddGeneratedCodeAttributes: False
//AddResponseStatus: False
//AddImplicitVersion: 
//InitializeCollections: False
//ExportValueTypes: False
//IncludeTypes: 
//ExcludeTypes: 
//AddNamespaces: 
//AddDefaultXmlNamespace: 
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using ServiceStack;
using ServiceStack.DataAnnotations;
using Chinook.ServiceModel.Types;
using Chinook;
using Chinook.ServiceModel;


namespace Chinook
{

    [DataContract]
    public class MyTable
    {
        [DataMember(Order=1)]
        public int Id { get; set; }

        [DataMember(Order=2)]
        public string Name { get; set; }
    }
}

namespace Chinook.ServiceModel
{

    [Route("/albums", "POST")]
    [DataContract]
    public class CreateAlbums
        : IReturn<IdResponse>, IPost, ICreateDb<Albums>
    {
        [DataMember(Order=2)]
        public string Title { get; set; }

        [DataMember(Order=3)]
        public long ArtistId { get; set; }
    }

    [Route("/artists", "POST")]
    [DataContract]
    public class CreateArtists
        : IReturn<IdResponse>, IPost, ICreateDb<Artists>
    {
        [DataMember(Order=2)]
        public string Name { get; set; }
    }

    [Route("/customers", "POST")]
    [DataContract]
    public class CreateCustomers
        : IReturn<IdResponse>, IPost, ICreateDb<Customers>
    {
        [DataMember(Order=2)]
        public string FirstName { get; set; }

        [DataMember(Order=3)]
        public string LastName { get; set; }

        [DataMember(Order=4)]
        public string Company { get; set; }

        [DataMember(Order=5)]
        public string Address { get; set; }

        [DataMember(Order=6)]
        public string City { get; set; }

        [DataMember(Order=7)]
        public string State { get; set; }

        [DataMember(Order=8)]
        public string Country { get; set; }

        [DataMember(Order=9)]
        public string PostalCode { get; set; }

        [DataMember(Order=10)]
        public string Phone { get; set; }

        [DataMember(Order=11)]
        public string Fax { get; set; }

        [DataMember(Order=12)]
        public string Email { get; set; }

        [DataMember(Order=13)]
        public long? SupportRepId { get; set; }
    }

    [Route("/employees", "POST")]
    [DataContract]
    public class CreateEmployees
        : IReturn<IdResponse>, IPost, ICreateDb<Employees>
    {
        [DataMember(Order=2)]
        public string LastName { get; set; }

        [DataMember(Order=3)]
        public string FirstName { get; set; }

        [DataMember(Order=4)]
        public string Title { get; set; }

        [DataMember(Order=5)]
        public long? ReportsTo { get; set; }

        [DataMember(Order=6)]
        public DateTime? BirthDate { get; set; }

        [DataMember(Order=7)]
        public DateTime? HireDate { get; set; }

        [DataMember(Order=8)]
        public string Address { get; set; }

        [DataMember(Order=9)]
        public string City { get; set; }

        [DataMember(Order=10)]
        public string State { get; set; }

        [DataMember(Order=11)]
        public string Country { get; set; }

        [DataMember(Order=12)]
        public string PostalCode { get; set; }

        [DataMember(Order=13)]
        public string Phone { get; set; }

        [DataMember(Order=14)]
        public string Fax { get; set; }

        [DataMember(Order=15)]
        public string Email { get; set; }
    }

    [Route("/genres", "POST")]
    [DataContract]
    public class CreateGenres
        : IReturn<IdResponse>, IPost, ICreateDb<Genres>
    {
        [DataMember(Order=2)]
        public string Name { get; set; }
    }

    [Route("/invoiceitems", "POST")]
    [DataContract]
    public class CreateInvoiceItems
        : IReturn<IdResponse>, IPost, ICreateDb<InvoiceItems>
    {
        [DataMember(Order=2)]
        public long InvoiceId { get; set; }

        [DataMember(Order=3)]
        public long TrackId { get; set; }

        [DataMember(Order=4)]
        public decimal UnitPrice { get; set; }

        [DataMember(Order=5)]
        public long Quantity { get; set; }
    }

    [Route("/invoices", "POST")]
    [DataContract]
    public class CreateInvoices
        : IReturn<IdResponse>, IPost, ICreateDb<Invoices>
    {
        [DataMember(Order=2)]
        public long CustomerId { get; set; }

        [DataMember(Order=3)]
        public DateTime InvoiceDate { get; set; }

        [DataMember(Order=4)]
        public string BillingAddress { get; set; }

        [DataMember(Order=5)]
        public string BillingCity { get; set; }

        [DataMember(Order=6)]
        public string BillingState { get; set; }

        [DataMember(Order=7)]
        public string BillingCountry { get; set; }

        [DataMember(Order=8)]
        public string BillingPostalCode { get; set; }

        [DataMember(Order=9)]
        public decimal Total { get; set; }
    }

    [Route("/mediatypes", "POST")]
    [DataContract]
    public class CreateMediaTypes
        : IReturn<IdResponse>, IPost, ICreateDb<MediaTypes>
    {
        [DataMember(Order=2)]
        public string Name { get; set; }
    }

    [Route("/mytables", "POST")]
    [DataContract]
    public class CreateMyTable
        : IReturn<IdResponse>, IPost, ICreateDb<MyTable>
    {
        [DataMember(Order=2)]
        public string Name { get; set; }
    }

    [Route("/playlists", "POST")]
    [DataContract]
    public class CreatePlaylists
        : IReturn<IdResponse>, IPost, ICreateDb<Playlists>
    {
        [DataMember(Order=2)]
        public string Name { get; set; }
    }

    [Route("/tracks", "POST")]
    [DataContract]
    public class CreateTracks
        : IReturn<IdResponse>, IPost, ICreateDb<Tracks>
    {
        [DataMember(Order=2)]
        public string Name { get; set; }

        [DataMember(Order=3)]
        public long? AlbumId { get; set; }

        [DataMember(Order=4)]
        public long MediaTypeId { get; set; }

        [DataMember(Order=5)]
        public long? GenreId { get; set; }

        [DataMember(Order=6)]
        public string Composer { get; set; }

        [DataMember(Order=7)]
        public long Milliseconds { get; set; }

        [DataMember(Order=8)]
        public long? Bytes { get; set; }

        [DataMember(Order=9)]
        public decimal UnitPrice { get; set; }
    }

    [Route("/albums/{AlbumId}", "DELETE")]
    [DataContract]
    public class DeleteAlbums
        : IReturn<IdResponse>, IDelete, IDeleteDb<Albums>
    {
        [DataMember(Order=1)]
        public long AlbumId { get; set; }
    }

    [Route("/artists/{ArtistId}", "DELETE")]
    [DataContract]
    public class DeleteArtists
        : IReturn<IdResponse>, IDelete, IDeleteDb<Artists>
    {
        [DataMember(Order=1)]
        public long ArtistId { get; set; }
    }

    [Route("/customers/{CustomerId}", "DELETE")]
    [DataContract]
    public class DeleteCustomers
        : IReturn<IdResponse>, IDelete, IDeleteDb<Customers>
    {
        [DataMember(Order=1)]
        public long CustomerId { get; set; }
    }

    [Route("/employees/{EmployeeId}", "DELETE")]
    [DataContract]
    public class DeleteEmployees
        : IReturn<IdResponse>, IDelete, IDeleteDb<Employees>
    {
        [DataMember(Order=1)]
        public long EmployeeId { get; set; }
    }

    [Route("/genres/{GenreId}", "DELETE")]
    [DataContract]
    public class DeleteGenres
        : IReturn<IdResponse>, IDelete, IDeleteDb<Genres>
    {
        [DataMember(Order=1)]
        public long GenreId { get; set; }
    }

    [Route("/invoiceitems/{InvoiceLineId}", "DELETE")]
    [DataContract]
    public class DeleteInvoiceItems
        : IReturn<IdResponse>, IDelete, IDeleteDb<InvoiceItems>
    {
        [DataMember(Order=1)]
        public long InvoiceLineId { get; set; }
    }

    [Route("/invoices/{InvoiceId}", "DELETE")]
    [DataContract]
    public class DeleteInvoices
        : IReturn<IdResponse>, IDelete, IDeleteDb<Invoices>
    {
        [DataMember(Order=1)]
        public long InvoiceId { get; set; }
    }

    [Route("/mediatypes/{MediaTypeId}", "DELETE")]
    [DataContract]
    public class DeleteMediaTypes
        : IReturn<IdResponse>, IDelete, IDeleteDb<MediaTypes>
    {
        [DataMember(Order=1)]
        public long MediaTypeId { get; set; }
    }

    [Route("/mytables/{Id}", "DELETE")]
    [DataContract]
    public class DeleteMyTable
        : IReturn<IdResponse>, IDelete, IDeleteDb<MyTable>
    {
        [DataMember(Order=1)]
        public long Id { get; set; }
    }

    [Route("/playlists/{PlaylistId}", "DELETE")]
    [DataContract]
    public class DeletePlaylists
        : IReturn<IdResponse>, IDelete, IDeleteDb<Playlists>
    {
        [DataMember(Order=1)]
        public long PlaylistId { get; set; }
    }

    [Route("/tracks/{TrackId}", "DELETE")]
    [DataContract]
    public class DeleteTracks
        : IReturn<IdResponse>, IDelete, IDeleteDb<Tracks>
    {
        [DataMember(Order=1)]
        public long TrackId { get; set; }
    }

    [Route("/albums/{AlbumId}", "PATCH")]
    [DataContract]
    public class PatchAlbums
        : IReturn<IdResponse>, IPatch, IPatchDb<Albums>
    {
        [DataMember(Order=1)]
        public long AlbumId { get; set; }

        [DataMember(Order=2)]
        public string Title { get; set; }

        [DataMember(Order=3)]
        public long ArtistId { get; set; }
    }

    [Route("/artists/{ArtistId}", "PATCH")]
    [DataContract]
    public class PatchArtists
        : IReturn<IdResponse>, IPatch, IPatchDb<Artists>
    {
        [DataMember(Order=1)]
        public long ArtistId { get; set; }

        [DataMember(Order=2)]
        public string Name { get; set; }
    }

    [Route("/customers/{CustomerId}", "PATCH")]
    [DataContract]
    public class PatchCustomers
        : IReturn<IdResponse>, IPatch, IPatchDb<Customers>
    {
        [DataMember(Order=1)]
        public long CustomerId { get; set; }

        [DataMember(Order=2)]
        public string FirstName { get; set; }

        [DataMember(Order=3)]
        public string LastName { get; set; }

        [DataMember(Order=4)]
        public string Company { get; set; }

        [DataMember(Order=5)]
        public string Address { get; set; }

        [DataMember(Order=6)]
        public string City { get; set; }

        [DataMember(Order=7)]
        public string State { get; set; }

        [DataMember(Order=8)]
        public string Country { get; set; }

        [DataMember(Order=9)]
        public string PostalCode { get; set; }

        [DataMember(Order=10)]
        public string Phone { get; set; }

        [DataMember(Order=11)]
        public string Fax { get; set; }

        [DataMember(Order=12)]
        public string Email { get; set; }

        [DataMember(Order=13)]
        public long? SupportRepId { get; set; }
    }

    [Route("/employees/{EmployeeId}", "PATCH")]
    [DataContract]
    public class PatchEmployees
        : IReturn<IdResponse>, IPatch, IPatchDb<Employees>
    {
        [DataMember(Order=1)]
        public long EmployeeId { get; set; }

        [DataMember(Order=2)]
        public string LastName { get; set; }

        [DataMember(Order=3)]
        public string FirstName { get; set; }

        [DataMember(Order=4)]
        public string Title { get; set; }

        [DataMember(Order=5)]
        public long? ReportsTo { get; set; }

        [DataMember(Order=6)]
        public DateTime? BirthDate { get; set; }

        [DataMember(Order=7)]
        public DateTime? HireDate { get; set; }

        [DataMember(Order=8)]
        public string Address { get; set; }

        [DataMember(Order=9)]
        public string City { get; set; }

        [DataMember(Order=10)]
        public string State { get; set; }

        [DataMember(Order=11)]
        public string Country { get; set; }

        [DataMember(Order=12)]
        public string PostalCode { get; set; }

        [DataMember(Order=13)]
        public string Phone { get; set; }

        [DataMember(Order=14)]
        public string Fax { get; set; }

        [DataMember(Order=15)]
        public string Email { get; set; }
    }

    [Route("/genres/{GenreId}", "PATCH")]
    [DataContract]
    public class PatchGenres
        : IReturn<IdResponse>, IPatch, IPatchDb<Genres>
    {
        [DataMember(Order=1)]
        public long GenreId { get; set; }

        [DataMember(Order=2)]
        public string Name { get; set; }
    }

    [Route("/invoiceitems/{InvoiceLineId}", "PATCH")]
    [DataContract]
    public class PatchInvoiceItems
        : IReturn<IdResponse>, IPatch, IPatchDb<InvoiceItems>
    {
        [DataMember(Order=1)]
        public long InvoiceLineId { get; set; }

        [DataMember(Order=2)]
        public long InvoiceId { get; set; }

        [DataMember(Order=3)]
        public long TrackId { get; set; }

        [DataMember(Order=4)]
        public decimal UnitPrice { get; set; }

        [DataMember(Order=5)]
        public long Quantity { get; set; }
    }

    [Route("/invoices/{InvoiceId}", "PATCH")]
    [DataContract]
    public class PatchInvoices
        : IReturn<IdResponse>, IPatch, IPatchDb<Invoices>
    {
        [DataMember(Order=1)]
        public long InvoiceId { get; set; }

        [DataMember(Order=2)]
        public long CustomerId { get; set; }

        [DataMember(Order=3)]
        public DateTime InvoiceDate { get; set; }

        [DataMember(Order=4)]
        public string BillingAddress { get; set; }

        [DataMember(Order=5)]
        public string BillingCity { get; set; }

        [DataMember(Order=6)]
        public string BillingState { get; set; }

        [DataMember(Order=7)]
        public string BillingCountry { get; set; }

        [DataMember(Order=8)]
        public string BillingPostalCode { get; set; }

        [DataMember(Order=9)]
        public decimal Total { get; set; }
    }

    [Route("/mediatypes/{MediaTypeId}", "PATCH")]
    [DataContract]
    public class PatchMediaTypes
        : IReturn<IdResponse>, IPatch, IPatchDb<MediaTypes>
    {
        [DataMember(Order=1)]
        public long MediaTypeId { get; set; }

        [DataMember(Order=2)]
        public string Name { get; set; }
    }

    [Route("/mytables/{Id}", "PATCH")]
    [DataContract]
    public class PatchMyTable
        : IReturn<IdResponse>, IPatch, IPatchDb<MyTable>
    {
        [DataMember(Order=1)]
        public long Id { get; set; }

        [DataMember(Order=2)]
        public string Name { get; set; }
    }

    [Route("/playlists/{PlaylistId}", "PATCH")]
    [DataContract]
    public class PatchPlaylists
        : IReturn<IdResponse>, IPatch, IPatchDb<Playlists>
    {
        [DataMember(Order=1)]
        public long PlaylistId { get; set; }

        [DataMember(Order=2)]
        public string Name { get; set; }
    }

    [Route("/tracks/{TrackId}", "PATCH")]
    [DataContract]
    public class PatchTracks
        : IReturn<IdResponse>, IPatch, IPatchDb<Tracks>
    {
        [DataMember(Order=1)]
        public long TrackId { get; set; }

        [DataMember(Order=2)]
        public string Name { get; set; }

        [DataMember(Order=3)]
        public long? AlbumId { get; set; }

        [DataMember(Order=4)]
        public long MediaTypeId { get; set; }

        [DataMember(Order=5)]
        public long? GenreId { get; set; }

        [DataMember(Order=6)]
        public string Composer { get; set; }

        [DataMember(Order=7)]
        public long Milliseconds { get; set; }

        [DataMember(Order=8)]
        public long? Bytes { get; set; }

        [DataMember(Order=9)]
        public decimal UnitPrice { get; set; }
    }

    [Route("/albums/{AlbumId}", "PUT")]
    [DataContract]
    public class UpdateAlbums
        : IReturn<IdResponse>, IPut, IUpdateDb<Albums>
    {
        [DataMember(Order=1)]
        public long AlbumId { get; set; }

        [DataMember(Order=2)]
        public string Title { get; set; }

        [DataMember(Order=3)]
        public long ArtistId { get; set; }
    }

    [Route("/artists/{ArtistId}", "PUT")]
    [DataContract]
    public class UpdateArtists
        : IReturn<IdResponse>, IPut, IUpdateDb<Artists>
    {
        [DataMember(Order=1)]
        public long ArtistId { get; set; }

        [DataMember(Order=2)]
        public string Name { get; set; }
    }

    [Route("/customers/{CustomerId}", "PUT")]
    [DataContract]
    public class UpdateCustomers
        : IReturn<IdResponse>, IPut, IUpdateDb<Customers>
    {
        [DataMember(Order=1)]
        public long CustomerId { get; set; }

        [DataMember(Order=2)]
        public string FirstName { get; set; }

        [DataMember(Order=3)]
        public string LastName { get; set; }

        [DataMember(Order=4)]
        public string Company { get; set; }

        [DataMember(Order=5)]
        public string Address { get; set; }

        [DataMember(Order=6)]
        public string City { get; set; }

        [DataMember(Order=7)]
        public string State { get; set; }

        [DataMember(Order=8)]
        public string Country { get; set; }

        [DataMember(Order=9)]
        public string PostalCode { get; set; }

        [DataMember(Order=10)]
        public string Phone { get; set; }

        [DataMember(Order=11)]
        public string Fax { get; set; }

        [DataMember(Order=12)]
        public string Email { get; set; }

        [DataMember(Order=13)]
        public long? SupportRepId { get; set; }
    }

    [Route("/employees/{EmployeeId}", "PUT")]
    [DataContract]
    public class UpdateEmployees
        : IReturn<IdResponse>, IPut, IUpdateDb<Employees>
    {
        [DataMember(Order=1)]
        public long EmployeeId { get; set; }

        [DataMember(Order=2)]
        public string LastName { get; set; }

        [DataMember(Order=3)]
        public string FirstName { get; set; }

        [DataMember(Order=4)]
        public string Title { get; set; }

        [DataMember(Order=5)]
        public long? ReportsTo { get; set; }

        [DataMember(Order=6)]
        public DateTime? BirthDate { get; set; }

        [DataMember(Order=7)]
        public DateTime? HireDate { get; set; }

        [DataMember(Order=8)]
        public string Address { get; set; }

        [DataMember(Order=9)]
        public string City { get; set; }

        [DataMember(Order=10)]
        public string State { get; set; }

        [DataMember(Order=11)]
        public string Country { get; set; }

        [DataMember(Order=12)]
        public string PostalCode { get; set; }

        [DataMember(Order=13)]
        public string Phone { get; set; }

        [DataMember(Order=14)]
        public string Fax { get; set; }

        [DataMember(Order=15)]
        public string Email { get; set; }
    }

    [Route("/genres/{GenreId}", "PUT")]
    [DataContract]
    public class UpdateGenres
        : IReturn<IdResponse>, IPut, IUpdateDb<Genres>
    {
        [DataMember(Order=1)]
        public long GenreId { get; set; }

        [DataMember(Order=2)]
        public string Name { get; set; }
    }

    [Route("/invoiceitems/{InvoiceLineId}", "PUT")]
    [DataContract]
    public class UpdateInvoiceItems
        : IReturn<IdResponse>, IPut, IUpdateDb<InvoiceItems>
    {
        [DataMember(Order=1)]
        public long InvoiceLineId { get; set; }

        [DataMember(Order=2)]
        public long InvoiceId { get; set; }

        [DataMember(Order=3)]
        public long TrackId { get; set; }

        [DataMember(Order=4)]
        public decimal UnitPrice { get; set; }

        [DataMember(Order=5)]
        public long Quantity { get; set; }
    }

    [Route("/invoices/{InvoiceId}", "PUT")]
    [DataContract]
    public class UpdateInvoices
        : IReturn<IdResponse>, IPut, IUpdateDb<Invoices>
    {
        [DataMember(Order=1)]
        public long InvoiceId { get; set; }

        [DataMember(Order=2)]
        public long CustomerId { get; set; }

        [DataMember(Order=3)]
        public DateTime InvoiceDate { get; set; }

        [DataMember(Order=4)]
        public string BillingAddress { get; set; }

        [DataMember(Order=5)]
        public string BillingCity { get; set; }

        [DataMember(Order=6)]
        public string BillingState { get; set; }

        [DataMember(Order=7)]
        public string BillingCountry { get; set; }

        [DataMember(Order=8)]
        public string BillingPostalCode { get; set; }

        [DataMember(Order=9)]
        public decimal Total { get; set; }
    }

    [Route("/mediatypes/{MediaTypeId}", "PUT")]
    [DataContract]
    public class UpdateMediaTypes
        : IReturn<IdResponse>, IPut, IUpdateDb<MediaTypes>
    {
        [DataMember(Order=1)]
        public long MediaTypeId { get; set; }

        [DataMember(Order=2)]
        public string Name { get; set; }
    }

    [Route("/mytables/{Id}", "PUT")]
    [DataContract]
    public class UpdateMyTable
        : IReturn<IdResponse>, IPut, IUpdateDb<MyTable>
    {
        [DataMember(Order=1)]
        public long Id { get; set; }

        [DataMember(Order=2)]
        public string Name { get; set; }
    }

    [Route("/playlists/{PlaylistId}", "PUT")]
    [DataContract]
    public class UpdatePlaylists
        : IReturn<IdResponse>, IPut, IUpdateDb<Playlists>
    {
        [DataMember(Order=1)]
        public long PlaylistId { get; set; }

        [DataMember(Order=2)]
        public string Name { get; set; }
    }

    [Route("/tracks/{TrackId}", "PUT")]
    [DataContract]
    public class UpdateTracks
        : IReturn<IdResponse>, IPut, IUpdateDb<Tracks>
    {
        [DataMember(Order=1)]
        public long TrackId { get; set; }

        [DataMember(Order=2)]
        public string Name { get; set; }

        [DataMember(Order=3)]
        public long? AlbumId { get; set; }

        [DataMember(Order=4)]
        public long MediaTypeId { get; set; }

        [DataMember(Order=5)]
        public long? GenreId { get; set; }

        [DataMember(Order=6)]
        public string Composer { get; set; }

        [DataMember(Order=7)]
        public long Milliseconds { get; set; }

        [DataMember(Order=8)]
        public long? Bytes { get; set; }

        [DataMember(Order=9)]
        public decimal UnitPrice { get; set; }
    }
}

namespace Chinook.ServiceModel.Types
{

    [DataContract]
    public class Albums
    {
        [DataMember(Order=1)]
        public long AlbumId { get; set; }

        [DataMember(Order=2)]
        [Required]
        public string Title { get; set; }

        [DataMember(Order=3)]
        public long ArtistId { get; set; }
    }

    [DataContract]
    public class Artists
    {
        [DataMember(Order=1)]
        public long ArtistId { get; set; }

        [DataMember(Order=2)]
        public string Name { get; set; }
    }

    [DataContract]
    public class Customers
    {
        [DataMember(Order=1)]
        public long CustomerId { get; set; }

        [DataMember(Order=2)]
        [Required]
        public string FirstName { get; set; }

        [DataMember(Order=3)]
        [Required]
        public string LastName { get; set; }

        [DataMember(Order=4)]
        public string Company { get; set; }

        [DataMember(Order=5)]
        public string Address { get; set; }

        [DataMember(Order=6)]
        public string City { get; set; }

        [DataMember(Order=7)]
        public string State { get; set; }

        [DataMember(Order=8)]
        public string Country { get; set; }

        [DataMember(Order=9)]
        public string PostalCode { get; set; }

        [DataMember(Order=10)]
        public string Phone { get; set; }

        [DataMember(Order=11)]
        public string Fax { get; set; }

        [DataMember(Order=12)]
        [Required]
        public string Email { get; set; }

        [DataMember(Order=13)]
        public long? SupportRepId { get; set; }
    }

    [DataContract]
    public class Employees
    {
        [DataMember(Order=1)]
        public long EmployeeId { get; set; }

        [DataMember(Order=2)]
        [Required]
        public string LastName { get; set; }

        [DataMember(Order=3)]
        [Required]
        public string FirstName { get; set; }

        [DataMember(Order=4)]
        public string Title { get; set; }

        [DataMember(Order=5)]
        public long? ReportsTo { get; set; }

        [DataMember(Order=6)]
        public DateTime? BirthDate { get; set; }

        [DataMember(Order=7)]
        public DateTime? HireDate { get; set; }

        [DataMember(Order=8)]
        public string Address { get; set; }

        [DataMember(Order=9)]
        public string City { get; set; }

        [DataMember(Order=10)]
        public string State { get; set; }

        [DataMember(Order=11)]
        public string Country { get; set; }

        [DataMember(Order=12)]
        public string PostalCode { get; set; }

        [DataMember(Order=13)]
        public string Phone { get; set; }

        [DataMember(Order=14)]
        public string Fax { get; set; }

        [DataMember(Order=15)]
        public string Email { get; set; }
    }

    [DataContract]
    public class Genres
    {
        [DataMember(Order=1)]
        public long GenreId { get; set; }

        [DataMember(Order=2)]
        public string Name { get; set; }
    }

    [DataContract]
    public class InvoiceItems
    {
        [DataMember(Order=1)]
        public long InvoiceLineId { get; set; }

        [DataMember(Order=2)]
        public long InvoiceId { get; set; }

        [DataMember(Order=3)]
        public long TrackId { get; set; }

        [DataMember(Order=4)]
        public decimal UnitPrice { get; set; }

        [DataMember(Order=5)]
        public long Quantity { get; set; }
    }

    [DataContract]
    public class Invoices
    {
        [DataMember(Order=1)]
        public long InvoiceId { get; set; }

        [DataMember(Order=2)]
        public long CustomerId { get; set; }

        [DataMember(Order=3)]
        public DateTime InvoiceDate { get; set; }

        [DataMember(Order=4)]
        public string BillingAddress { get; set; }

        [DataMember(Order=5)]
        public string BillingCity { get; set; }

        [DataMember(Order=6)]
        public string BillingState { get; set; }

        [DataMember(Order=7)]
        public string BillingCountry { get; set; }

        [DataMember(Order=8)]
        public string BillingPostalCode { get; set; }

        [DataMember(Order=9)]
        public decimal Total { get; set; }
    }

    [DataContract]
    public class MediaTypes
    {
        [DataMember(Order=1)]
        public long MediaTypeId { get; set; }

        [DataMember(Order=2)]
        public string Name { get; set; }
    }

    [DataContract]
    public class Playlists
    {
        [DataMember(Order=1)]
        public long PlaylistId { get; set; }

        [DataMember(Order=2)]
        public string Name { get; set; }
    }

    [DataContract]
    public class Tracks
    {
        [DataMember(Order=1)]
        public long TrackId { get; set; }

        [DataMember(Order=2)]
        [Required]
        public string Name { get; set; }

        [DataMember(Order=3)]
        public long? AlbumId { get; set; }

        [DataMember(Order=4)]
        public long MediaTypeId { get; set; }

        [DataMember(Order=5)]
        public long? GenreId { get; set; }

        [DataMember(Order=6)]
        public string Composer { get; set; }

        [DataMember(Order=7)]
        public long Milliseconds { get; set; }

        [DataMember(Order=8)]
        public long? Bytes { get; set; }

        [DataMember(Order=9)]
        public decimal UnitPrice { get; set; }
    }
}

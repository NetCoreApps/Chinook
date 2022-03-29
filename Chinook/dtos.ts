/* Options:
Date: 2022-03-30 02:41:30
Version: 6.03
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: https://localhost:5001

//GlobalNamespace: 
//MakePropertiesOptional: False
//AddServiceStackTypes: True
//AddResponseStatus: False
//AddImplicitVersion: 
//AddDescriptionAsComments: True
//IncludeTypes: 
//ExcludeTypes: 
//DefaultImports: 
*/


export interface IReturn<T>
{
    createResponse(): T;
}

export interface IReturnVoid
{
    createResponse(): void;
}

export interface IGet
{
}

export interface IPost
{
}

export interface ICreateDb<Table>
{
}

export interface IDelete
{
}

export interface IDeleteDb<Table>
{
}

export interface IPatch
{
}

export interface IPatchDb<Table>
{
}

export interface IPut
{
}

export interface IUpdateDb<Table>
{
}

// @DataContract
export class QueryBase
{
    // @DataMember(Order=1)
    public skip?: number;

    // @DataMember(Order=2)
    public take?: number;

    // @DataMember(Order=3)
    public orderBy: string;

    // @DataMember(Order=4)
    public orderByDesc: string;

    // @DataMember(Order=5)
    public include: string;

    // @DataMember(Order=6)
    public fields: string;

    // @DataMember(Order=7)
    public meta: { [index: string]: string; };

    public constructor(init?: Partial<QueryBase>) { (Object as any).assign(this, init); }
}

export class QueryDb<T> extends QueryBase
{

    public constructor(init?: Partial<QueryDb<T>>) { super(init); (Object as any).assign(this, init); }
}

// @Icon(Svg="<svg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor' aria-hidden='true'><g fill='none' stroke-width='1.5'><path stroke='currentColor' d='M2 17.4V2.6a.6.6 0 0 1 .6-.6h14.8a.6.6 0 0 1 .6.6v14.8a.6.6 0 0 1-.6.6H2.6a.6.6 0 0 1-.6-.6Z'/><path stroke='currentColor' stroke-linecap='round' d='M8 22h13.4a.6.6 0 0 0 .6-.6V8'/><path fill='currentColor' d='M11 12.5a1.5 1.5 0 1 1-3 0a1.5 1.5 0 0 1 3 0Z'/><path stroke='currentColor' stroke-linecap='round' d='M11 12.5a1.5 1.5 0 1 1-3 0a1.5 1.5 0 0 1 3 0Zm0 0V6.6a.6.6 0 0 1 .6-.6H13'/></g></svg>")
export class Albums
{
    public albumId: number;
    // @Required()
    // @Format(Method="stylize", Options="{cls:'text-rose-500'}")
    public title: string;

    // @Ref(Model="Artists", RefId="ArtistId", RefLabel="Name")
    public artistId: number;

    public constructor(init?: Partial<Albums>) { (Object as any).assign(this, init); }
}

// @Icon(Svg="<svg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor' aria-hidden='true'><path fill='currentColor' d='M12 2a9 9 0 0 0-9 9c0 4.17 2.84 7.67 6.69 8.69L12 22l2.31-2.31C18.16 18.67 21 15.17 21 11a9 9 0 0 0-9-9zm0 2c1.66 0 3 1.34 3 3s-1.34 3-3 3s-3-1.34-3-3s1.34-3 3-3zm0 14.3a7.2 7.2 0 0 1-6-3.22c.03-1.99 4-3.08 6-3.08c1.99 0 5.97 1.09 6 3.08a7.2 7.2 0 0 1-6 3.22z'/></svg>")
export class Artists
{
    public artistId: number;
    public name: string;

    public constructor(init?: Partial<Artists>) { (Object as any).assign(this, init); }
}

// @Icon(Svg="<svg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor' aria-hidden='true'><g fill='none' stroke-width='1.5'><path stroke='currentColor' stroke-linecap='round' stroke-linejoin='round' d='M15 2.2c4.564.926 8 4.962 8 9.8c0 4.838-3.436 8.873-8 9.8'/><path stroke='currentColor' stroke-linecap='round' stroke-linejoin='round' d='M15 9c1.141.284 2 1.519 2 3s-.859 2.716-2 3M1 2h10v20H1'/><path fill='currentColor' d='M4 15.5a1.5 1.5 0 1 1-3 0a1.5 1.5 0 0 1 3 0Z'/><path stroke='currentColor' stroke-linecap='round' d='M4 15.5a1.5 1.5 0 1 1-3 0a1.5 1.5 0 0 1 3 0Zm0 0V7.6a.6.6 0 0 1 .6-.6H7'/></g></svg>")
export class Genres
{
    public genreId: number;
    public name: string;

    public constructor(init?: Partial<Genres>) { (Object as any).assign(this, init); }
}

// @Icon(Svg="<svg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor' aria-hidden='true'><g fill='none' stroke='currentColor' stroke-linecap='round' stroke-linejoin='round' stroke-width='2'><path d='M14 3v4a1 1 0 0 0 1 1h4'/><path d='M17 21H7a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h7l5 5v11a2 2 0 0 1-2 2z'/><circle cx='11' cy='16' r='1'/><path d='M12 16v-5l2 1'/></g></svg>")
export class MediaTypes
{
    public mediaTypeId: number;
    public name: string;

    public constructor(init?: Partial<MediaTypes>) { (Object as any).assign(this, init); }
}

// @Icon(Svg="<svg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor' aria-hidden='true'><path fill='currentColor' d='M15 6H3v2h12V6m0 4H3v2h12v-2M3 16h8v-2H3v2M17 6v8.18c-.31-.11-.65-.18-1-.18a3 3 0 0 0-3 3a3 3 0 0 0 3 3a3 3 0 0 0 3-3V8h3V6h-5Z'/></svg>")
export class Playlists
{
    public playlistId: number;
    public name: string;

    public constructor(init?: Partial<Playlists>) { (Object as any).assign(this, init); }
}

// @Icon(Svg="<svg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor' aria-hidden='true'><path fill='currentColor' d='M12 3v9.28a4.39 4.39 0 0 0-1.5-.28C8.01 12 6 14.01 6 16.5S8.01 21 10.5 21c2.31 0 4.2-1.75 4.45-4H15V6h4V3h-7z'/></svg>")
export class Tracks
{
    public trackId: number;
    // @Required()
    // @Format(Method="stylize", Options="{cls:'text-rose-500'}")
    public name: string;

    // @Ref(Model="Albums", RefId="AlbumId", RefLabel="Title")
    public albumId?: number;

    // @Ref(Model="MediaTypes", RefId="MediaTypeId", RefLabel="Name")
    public mediaTypeId: number;

    // @Ref(Model="Genres", RefId="GenreId", RefLabel="Name")
    public genreId?: number;

    public composer: string;
    // @IntlDateTime(FractionalSecondDigits=3, Minute=DatePart.Digits2, Second=DatePart.Digits2)
    public milliseconds: number;

    // @Format(Method="bytes")
    public bytes?: number;

    // @Format(Method="currency")
    public unitPrice: number;

    public constructor(init?: Partial<Tracks>) { (Object as any).assign(this, init); }
}

// @Icon(Svg="<svg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor' aria-hidden='true'><path fill='currentColor' d='M19 2H5a2 2 0 0 0-2 2v14c0 1.1.9 2 2 2h4l2.29 2.29c.39.39 1.02.39 1.41 0L15 20h4c1.1 0 2-.9 2-2V4c0-1.1-.9-2-2-2zm-7 3.3c1.49 0 2.7 1.21 2.7 2.7s-1.21 2.7-2.7 2.7S9.3 9.49 9.3 8s1.21-2.7 2.7-2.7zM18 16H6v-.9c0-2 4-3.1 6-3.1s6 1.1 6 3.1v.9z'/></svg>")
export class Customers
{
    public customerId: number;
    // @Computed()
    public displayName: string;

    // @Required()
    public firstName: string;

    // @Required()
    public lastName: string;

    // @Ref(Model="Employees", RefId="EmployeeId", RefLabel="LastName")
    public supportRepId?: number;

    public company: string;
    public address: string;
    public city: string;
    public state: string;
    public country: string;
    public postalCode: string;
    // @Format(Method="linkTel")
    public phone: string;

    // @Format(Method="linkTel")
    public fax: string;

    // @Required()
    // @Format(Method="linkMailTo")
    public email: string;

    public constructor(init?: Partial<Customers>) { (Object as any).assign(this, init); }
}

// @Icon(Svg="<svg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor' aria-hidden='true'><path fill='currentColor' d='M19.745 4a2.25 2.25 0 0 1 2.25 2.25v11.505a2.25 2.25 0 0 1-2.25 2.25H4.25A2.25 2.25 0 0 1 2 17.755V6.25A2.25 2.25 0 0 1 4.25 4h15.495Zm0 1.5H4.25a.75.75 0 0 0-.75.75v11.505c0 .414.336.75.75.75l2.749-.001L7 15.75a1.75 1.75 0 0 1 1.606-1.744L8.75 14h6.495a1.75 1.75 0 0 1 1.744 1.607l.006.143l-.001 2.754h2.751a.75.75 0 0 0 .75-.75V6.25a.75.75 0 0 0-.75-.75ZM12 7a3 3 0 1 1 0 6a3 3 0 0 1 0-6Z'/></svg>")
export class Employees
{
    public employeeId: number;
    // @Required()
    public lastName: string;

    // @Required()
    public firstName: string;

    public title: string;
    // @Ref(Model="Employees", RefId="ReportsTo", RefLabel="LastName")
    public reportsTo?: number;

    public birthDate?: string;
    public hireDate?: string;
    public address: string;
    public city: string;
    public state: string;
    public country: string;
    public postalCode: string;
    // @Format(Method="linkTel")
    public phone: string;

    // @Format(Method="linkTel")
    public fax: string;

    // @Format(Method="linkMailTo", Options="{subject:'Call Help Desk'}")
    public email: string;

    public constructor(init?: Partial<Employees>) { (Object as any).assign(this, init); }
}

// @Icon(Svg="<svg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor' aria-hidden='true'><g fill='none' stroke='currentColor' stroke-linecap='round' stroke-linejoin='round' stroke-width='2'><path d='M11 5h10m-10 7h10m-10 7h10'/><rect width='4' height='4' x='3' y='3' rx='1'/><rect width='4' height='4' x='3' y='10' rx='1'/><rect width='4' height='4' x='3' y='17' rx='1'/></g></svg>")
export class InvoiceItems
{
    public invoiceLineId: number;
    // @Ref(Model="Invoices", RefId="InvoiceId", RefLabel="BillingAddress")
    public invoiceId: number;

    // @Ref(Model="Tracks", RefId="TrackId", RefLabel="Name")
    public trackId: number;

    // @Format(Method="currency")
    public unitPrice: number;

    public quantity: number;

    public constructor(init?: Partial<InvoiceItems>) { (Object as any).assign(this, init); }
}

// @Icon(Svg="<svg xmlns='http://www.w3.org/2000/svg' fill='none' viewBox='0 0 24 24' stroke='currentColor' aria-hidden='true'><path fill='currentColor' d='M21 11h-3V4a1 1 0 0 0-1-1H3a1 1 0 0 0-1 1v14c0 1.654 1.346 3 3 3h14c1.654 0 3-1.346 3-3v-6a1 1 0 0 0-1-1zM5 19a1 1 0 0 1-1-1V5h12v13c0 .351.061.688.171 1H5zm15-1a1 1 0 0 1-2 0v-5h2v5z'/><path fill='currentColor' d='M6 7h8v2H6zm0 4h8v2H6zm5 4h3v2h-3z'/></svg>")
export class Invoices
{
    public invoiceId: number;
    // @Ref(Model="Customers", RefId="CustomerId", RefLabel="DisplayName")
    public customerId: number;

    public invoiceDate: string;
    // @Format(Method="currency")
    public total: number;

    public billingAddress: string;
    public billingCity: string;
    public billingState: string;
    public billingCountry: string;
    public billingPostalCode: string;

    public constructor(init?: Partial<Invoices>) { (Object as any).assign(this, init); }
}

// @DataContract
export class ResponseError
{
    // @DataMember(Order=1)
    public errorCode: string;

    // @DataMember(Order=2)
    public fieldName: string;

    // @DataMember(Order=3)
    public message: string;

    // @DataMember(Order=4)
    public meta: { [index: string]: string; };

    public constructor(init?: Partial<ResponseError>) { (Object as any).assign(this, init); }
}

// @DataContract
export class ResponseStatus
{
    // @DataMember(Order=1)
    public errorCode: string;

    // @DataMember(Order=2)
    public message: string;

    // @DataMember(Order=3)
    public stackTrace: string;

    // @DataMember(Order=4)
    public errors: ResponseError[];

    // @DataMember(Order=5)
    public meta: { [index: string]: string; };

    public constructor(init?: Partial<ResponseStatus>) { (Object as any).assign(this, init); }
}

export class HelloResponse
{
    public result: string;

    public constructor(init?: Partial<HelloResponse>) { (Object as any).assign(this, init); }
}

// @DataContract
export class QueryResponse<T>
{
    // @DataMember(Order=1)
    public offset: number;

    // @DataMember(Order=2)
    public total: number;

    // @DataMember(Order=3)
    public results: T[];

    // @DataMember(Order=4)
    public meta: { [index: string]: string; };

    // @DataMember(Order=5)
    public responseStatus: ResponseStatus;

    public constructor(init?: Partial<QueryResponse<T>>) { (Object as any).assign(this, init); }
}

// @DataContract
export class IdResponse
{
    // @DataMember(Order=1)
    public id: string;

    // @DataMember(Order=2)
    public responseStatus: ResponseStatus;

    public constructor(init?: Partial<IdResponse>) { (Object as any).assign(this, init); }
}

// @Route("/hello")
// @Route("/hello/{Name}")
export class Hello implements IReturn<HelloResponse>
{
    public name: string;

    public constructor(init?: Partial<Hello>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'Hello'; }
    public getMethod() { return 'POST'; }
    public createResponse() { return new HelloResponse(); }
}

// @Route("/albums", "GET")
// @Route("/albums/{AlbumId}", "GET")
export class QueryAlbums extends QueryDb<Albums> implements IReturn<QueryResponse<Albums>>, IGet
{
    public albumId?: number;

    public constructor(init?: Partial<QueryAlbums>) { super(init); (Object as any).assign(this, init); }
    public getTypeName() { return 'QueryAlbums'; }
    public getMethod() { return 'GET'; }
    public createResponse() { return new QueryResponse<Albums>(); }
}

// @Route("/artists", "GET")
// @Route("/artists/{ArtistId}", "GET")
export class QueryArtists extends QueryDb<Artists> implements IReturn<QueryResponse<Artists>>, IGet
{
    public artistId?: number;
    public artistIdBetween: number[];
    public nameStartsWith: string;

    public constructor(init?: Partial<QueryArtists>) { super(init); (Object as any).assign(this, init); }
    public getTypeName() { return 'QueryArtists'; }
    public getMethod() { return 'GET'; }
    public createResponse() { return new QueryResponse<Artists>(); }
}

// @Route("/genres", "GET")
// @Route("/genres/{GenreId}", "GET")
export class QueryGenres extends QueryDb<Genres> implements IReturn<QueryResponse<Genres>>, IGet
{
    public genreId?: number;

    public constructor(init?: Partial<QueryGenres>) { super(init); (Object as any).assign(this, init); }
    public getTypeName() { return 'QueryGenres'; }
    public getMethod() { return 'GET'; }
    public createResponse() { return new QueryResponse<Genres>(); }
}

// @Route("/mediatypes", "GET")
// @Route("/mediatypes/{MediaTypeId}", "GET")
export class QueryMediaTypes extends QueryDb<MediaTypes> implements IReturn<QueryResponse<MediaTypes>>, IGet
{
    public mediaTypeId?: number;

    public constructor(init?: Partial<QueryMediaTypes>) { super(init); (Object as any).assign(this, init); }
    public getTypeName() { return 'QueryMediaTypes'; }
    public getMethod() { return 'GET'; }
    public createResponse() { return new QueryResponse<MediaTypes>(); }
}

// @Route("/playlists", "GET")
// @Route("/playlists/{PlaylistId}", "GET")
export class QueryPlaylists extends QueryDb<Playlists> implements IReturn<QueryResponse<Playlists>>, IGet
{
    public playlistId?: number;

    public constructor(init?: Partial<QueryPlaylists>) { super(init); (Object as any).assign(this, init); }
    public getTypeName() { return 'QueryPlaylists'; }
    public getMethod() { return 'GET'; }
    public createResponse() { return new QueryResponse<Playlists>(); }
}

// @Route("/tracks", "GET")
// @Route("/tracks/{TrackId}", "GET")
export class QueryTracks extends QueryDb<Tracks> implements IReturn<QueryResponse<Tracks>>, IGet
{
    public trackId?: number;
    public nameContains: string;

    public constructor(init?: Partial<QueryTracks>) { super(init); (Object as any).assign(this, init); }
    public getTypeName() { return 'QueryTracks'; }
    public getMethod() { return 'GET'; }
    public createResponse() { return new QueryResponse<Tracks>(); }
}

// @Route("/customers", "GET")
// @Route("/customers/{CustomerId}", "GET")
export class QueryCustomers extends QueryDb<Customers> implements IReturn<QueryResponse<Customers>>, IGet
{
    public customerId?: number;

    public constructor(init?: Partial<QueryCustomers>) { super(init); (Object as any).assign(this, init); }
    public getTypeName() { return 'QueryCustomers'; }
    public getMethod() { return 'GET'; }
    public createResponse() { return new QueryResponse<Customers>(); }
}

// @Route("/employees", "GET")
// @Route("/employees/{EmployeeId}", "GET")
export class QueryEmployees extends QueryDb<Employees> implements IReturn<QueryResponse<Employees>>, IGet
{
    public employeeId?: number;

    public constructor(init?: Partial<QueryEmployees>) { super(init); (Object as any).assign(this, init); }
    public getTypeName() { return 'QueryEmployees'; }
    public getMethod() { return 'GET'; }
    public createResponse() { return new QueryResponse<Employees>(); }
}

// @Route("/invoiceitems", "GET")
// @Route("/invoiceitems/{InvoiceLineId}", "GET")
export class QueryInvoiceItems extends QueryDb<InvoiceItems> implements IReturn<QueryResponse<InvoiceItems>>, IGet
{
    public invoiceLineId?: number;

    public constructor(init?: Partial<QueryInvoiceItems>) { super(init); (Object as any).assign(this, init); }
    public getTypeName() { return 'QueryInvoiceItems'; }
    public getMethod() { return 'GET'; }
    public createResponse() { return new QueryResponse<InvoiceItems>(); }
}

// @Route("/invoices", "GET")
// @Route("/invoices/{InvoiceId}", "GET")
export class QueryInvoices extends QueryDb<Invoices> implements IReturn<QueryResponse<Invoices>>, IGet
{
    public invoiceId?: number;

    public constructor(init?: Partial<QueryInvoices>) { super(init); (Object as any).assign(this, init); }
    public getTypeName() { return 'QueryInvoices'; }
    public getMethod() { return 'GET'; }
    public createResponse() { return new QueryResponse<Invoices>(); }
}

// @Route("/albums", "POST")
export class CreateAlbums implements IReturn<IdResponse>, IPost, ICreateDb<Albums>
{
    // @Validate(Validator="NotEmpty")
    public title: string;

    // @Validate(Validator="GreaterThan(0)")
    public artistId: number;

    public constructor(init?: Partial<CreateAlbums>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'CreateAlbums'; }
    public getMethod() { return 'POST'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/artists", "POST")
export class CreateArtists implements IReturn<IdResponse>, IPost, ICreateDb<Artists>
{
    public name: string;

    public constructor(init?: Partial<CreateArtists>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'CreateArtists'; }
    public getMethod() { return 'POST'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/genres", "POST")
export class CreateGenres implements IReturn<IdResponse>, IPost, ICreateDb<Genres>
{
    public name: string;

    public constructor(init?: Partial<CreateGenres>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'CreateGenres'; }
    public getMethod() { return 'POST'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/mediatypes", "POST")
export class CreateMediaTypes implements IReturn<IdResponse>, IPost, ICreateDb<MediaTypes>
{
    public name: string;

    public constructor(init?: Partial<CreateMediaTypes>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'CreateMediaTypes'; }
    public getMethod() { return 'POST'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/playlists", "POST")
export class CreatePlaylists implements IReturn<IdResponse>, IPost, ICreateDb<Playlists>
{
    public name: string;

    public constructor(init?: Partial<CreatePlaylists>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'CreatePlaylists'; }
    public getMethod() { return 'POST'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/tracks", "POST")
export class CreateTracks implements IReturn<IdResponse>, IPost, ICreateDb<Tracks>
{
    public name: string;
    public albumId?: number;
    public mediaTypeId: number;
    public genreId?: number;
    public composer: string;
    public milliseconds: number;
    public bytes?: number;
    public unitPrice: number;

    public constructor(init?: Partial<CreateTracks>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'CreateTracks'; }
    public getMethod() { return 'POST'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/albums/{AlbumId}", "DELETE")
export class DeleteAlbums implements IReturn<IdResponse>, IDelete, IDeleteDb<Albums>
{
    public albumId: number;

    public constructor(init?: Partial<DeleteAlbums>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'DeleteAlbums'; }
    public getMethod() { return 'DELETE'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/artists/{ArtistId}", "DELETE")
export class DeleteArtists implements IReturn<IdResponse>, IDelete, IDeleteDb<Artists>
{
    public artistId: number;

    public constructor(init?: Partial<DeleteArtists>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'DeleteArtists'; }
    public getMethod() { return 'DELETE'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/genres/{GenreId}", "DELETE")
export class DeleteGenres implements IReturn<IdResponse>, IDelete, IDeleteDb<Genres>
{
    public genreId: number;

    public constructor(init?: Partial<DeleteGenres>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'DeleteGenres'; }
    public getMethod() { return 'DELETE'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/mediatypes/{MediaTypeId}", "DELETE")
export class DeleteMediaTypes implements IReturn<IdResponse>, IDelete, IDeleteDb<MediaTypes>
{
    public mediaTypeId: number;

    public constructor(init?: Partial<DeleteMediaTypes>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'DeleteMediaTypes'; }
    public getMethod() { return 'DELETE'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/playlists/{PlaylistId}", "DELETE")
export class DeletePlaylists implements IReturn<IdResponse>, IDelete, IDeleteDb<Playlists>
{
    public playlistId: number;

    public constructor(init?: Partial<DeletePlaylists>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'DeletePlaylists'; }
    public getMethod() { return 'DELETE'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/tracks/{TrackId}", "DELETE")
export class DeleteTracks implements IReturn<IdResponse>, IDelete, IDeleteDb<Tracks>
{
    public trackId: number;

    public constructor(init?: Partial<DeleteTracks>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'DeleteTracks'; }
    public getMethod() { return 'DELETE'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/albums/{AlbumId}", "PATCH")
export class PatchAlbums implements IReturn<IdResponse>, IPatch, IPatchDb<Albums>
{
    public albumId: number;
    public title: string;
    public artistId: number;

    public constructor(init?: Partial<PatchAlbums>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'PatchAlbums'; }
    public getMethod() { return 'PATCH'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/artists/{ArtistId}", "PATCH")
export class PatchArtists implements IReturn<IdResponse>, IPatch, IPatchDb<Artists>
{
    public artistId: number;
    public name: string;

    public constructor(init?: Partial<PatchArtists>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'PatchArtists'; }
    public getMethod() { return 'PATCH'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/genres/{GenreId}", "PATCH")
export class PatchGenres implements IReturn<IdResponse>, IPatch, IPatchDb<Genres>
{
    public genreId: number;
    public name: string;

    public constructor(init?: Partial<PatchGenres>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'PatchGenres'; }
    public getMethod() { return 'PATCH'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/mediatypes/{MediaTypeId}", "PATCH")
export class PatchMediaTypes implements IReturn<IdResponse>, IPatch, IPatchDb<MediaTypes>
{
    public mediaTypeId: number;
    public name: string;

    public constructor(init?: Partial<PatchMediaTypes>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'PatchMediaTypes'; }
    public getMethod() { return 'PATCH'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/playlists/{PlaylistId}", "PATCH")
export class PatchPlaylists implements IReturn<IdResponse>, IPatch, IPatchDb<Playlists>
{
    public playlistId: number;
    public name: string;

    public constructor(init?: Partial<PatchPlaylists>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'PatchPlaylists'; }
    public getMethod() { return 'PATCH'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/tracks/{TrackId}", "PATCH")
export class PatchTracks implements IReturn<IdResponse>, IPatch, IPatchDb<Tracks>
{
    public trackId: number;
    public name: string;
    public albumId?: number;
    public mediaTypeId: number;
    public genreId?: number;
    public composer: string;
    public milliseconds: number;
    public bytes?: number;
    public unitPrice: number;

    public constructor(init?: Partial<PatchTracks>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'PatchTracks'; }
    public getMethod() { return 'PATCH'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/albums/{AlbumId}", "PUT")
export class UpdateAlbums implements IReturn<IdResponse>, IPut, IUpdateDb<Albums>
{
    public albumId: number;
    public title: string;
    public artistId: number;

    public constructor(init?: Partial<UpdateAlbums>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'UpdateAlbums'; }
    public getMethod() { return 'PUT'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/artists/{ArtistId}", "PUT")
export class UpdateArtists implements IReturn<IdResponse>, IPut, IUpdateDb<Artists>
{
    public artistId: number;
    public name: string;

    public constructor(init?: Partial<UpdateArtists>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'UpdateArtists'; }
    public getMethod() { return 'PUT'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/genres/{GenreId}", "PUT")
export class UpdateGenres implements IReturn<IdResponse>, IPut, IUpdateDb<Genres>
{
    public genreId: number;
    public name: string;

    public constructor(init?: Partial<UpdateGenres>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'UpdateGenres'; }
    public getMethod() { return 'PUT'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/mediatypes/{MediaTypeId}", "PUT")
export class UpdateMediaTypes implements IReturn<IdResponse>, IPut, IUpdateDb<MediaTypes>
{
    public mediaTypeId: number;
    public name: string;

    public constructor(init?: Partial<UpdateMediaTypes>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'UpdateMediaTypes'; }
    public getMethod() { return 'PUT'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/playlists/{PlaylistId}", "PUT")
export class UpdatePlaylists implements IReturn<IdResponse>, IPut, IUpdateDb<Playlists>
{
    public playlistId: number;
    public name: string;

    public constructor(init?: Partial<UpdatePlaylists>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'UpdatePlaylists'; }
    public getMethod() { return 'PUT'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/tracks/{TrackId}", "PUT")
export class UpdateTracks implements IReturn<IdResponse>, IPut, IUpdateDb<Tracks>
{
    public trackId: number;
    public name: string;
    public albumId?: number;
    public mediaTypeId: number;
    public genreId?: number;
    public composer: string;
    public milliseconds: number;
    public bytes?: number;
    public unitPrice: number;

    public constructor(init?: Partial<UpdateTracks>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'UpdateTracks'; }
    public getMethod() { return 'PUT'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/customers", "POST")
export class CreateCustomers implements IReturn<IdResponse>, IPost, ICreateDb<Customers>
{
    public firstName: string;
    public lastName: string;
    public company: string;
    public address: string;
    public city: string;
    public state: string;
    public country: string;
    public postalCode: string;
    public phone: string;
    public fax: string;
    public email: string;
    public supportRepId?: number;

    public constructor(init?: Partial<CreateCustomers>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'CreateCustomers'; }
    public getMethod() { return 'POST'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/employees", "POST")
export class CreateEmployees implements IReturn<IdResponse>, IPost, ICreateDb<Employees>
{
    public lastName: string;
    public firstName: string;
    public title: string;
    public reportsTo?: number;
    public birthDate?: string;
    public hireDate?: string;
    public address: string;
    public city: string;
    public state: string;
    public country: string;
    public postalCode: string;
    public phone: string;
    public fax: string;
    public email: string;

    public constructor(init?: Partial<CreateEmployees>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'CreateEmployees'; }
    public getMethod() { return 'POST'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/invoiceitems", "POST")
export class CreateInvoiceItems implements IReturn<IdResponse>, IPost, ICreateDb<InvoiceItems>
{
    public invoiceId: number;
    public trackId: number;
    public unitPrice: number;
    public quantity: number;

    public constructor(init?: Partial<CreateInvoiceItems>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'CreateInvoiceItems'; }
    public getMethod() { return 'POST'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/invoices", "POST")
export class CreateInvoices implements IReturn<IdResponse>, IPost, ICreateDb<Invoices>
{
    public customerId: number;
    public invoiceDate: string;
    public billingAddress: string;
    public billingCity: string;
    public billingState: string;
    public billingCountry: string;
    public billingPostalCode: string;
    public total: number;

    public constructor(init?: Partial<CreateInvoices>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'CreateInvoices'; }
    public getMethod() { return 'POST'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/customers/{CustomerId}", "DELETE")
export class DeleteCustomers implements IReturn<IdResponse>, IDelete, IDeleteDb<Customers>
{
    public customerId: number;

    public constructor(init?: Partial<DeleteCustomers>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'DeleteCustomers'; }
    public getMethod() { return 'DELETE'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/employees/{EmployeeId}", "DELETE")
export class DeleteEmployees implements IReturn<IdResponse>, IDelete, IDeleteDb<Employees>
{
    public employeeId: number;

    public constructor(init?: Partial<DeleteEmployees>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'DeleteEmployees'; }
    public getMethod() { return 'DELETE'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/invoiceitems/{InvoiceLineId}", "DELETE")
export class DeleteInvoiceItems implements IReturn<IdResponse>, IDelete, IDeleteDb<InvoiceItems>
{
    public invoiceLineId: number;

    public constructor(init?: Partial<DeleteInvoiceItems>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'DeleteInvoiceItems'; }
    public getMethod() { return 'DELETE'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/invoices/{InvoiceId}", "DELETE")
export class DeleteInvoices implements IReturn<IdResponse>, IDelete, IDeleteDb<Invoices>
{
    public invoiceId: number;

    public constructor(init?: Partial<DeleteInvoices>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'DeleteInvoices'; }
    public getMethod() { return 'DELETE'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/customers/{CustomerId}", "PATCH")
export class PatchCustomers implements IReturn<IdResponse>, IPatch, IPatchDb<Customers>
{
    public customerId: number;
    public firstName: string;
    public lastName: string;
    public company: string;
    public address: string;
    public city: string;
    public state: string;
    public country: string;
    public postalCode: string;
    public phone: string;
    public fax: string;
    public email: string;
    public supportRepId?: number;

    public constructor(init?: Partial<PatchCustomers>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'PatchCustomers'; }
    public getMethod() { return 'PATCH'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/employees/{EmployeeId}", "PATCH")
export class PatchEmployees implements IReturn<IdResponse>, IPatch, IPatchDb<Employees>
{
    public employeeId: number;
    public lastName: string;
    public firstName: string;
    public title: string;
    public reportsTo?: number;
    public birthDate?: string;
    public hireDate?: string;
    public address: string;
    public city: string;
    public state: string;
    public country: string;
    public postalCode: string;
    public phone: string;
    public fax: string;
    public email: string;

    public constructor(init?: Partial<PatchEmployees>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'PatchEmployees'; }
    public getMethod() { return 'PATCH'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/invoiceitems/{InvoiceLineId}", "PATCH")
export class PatchInvoiceItems implements IReturn<IdResponse>, IPatch, IPatchDb<InvoiceItems>
{
    public invoiceLineId: number;
    public invoiceId: number;
    public trackId: number;
    public unitPrice: number;
    public quantity: number;

    public constructor(init?: Partial<PatchInvoiceItems>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'PatchInvoiceItems'; }
    public getMethod() { return 'PATCH'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/invoices/{InvoiceId}", "PATCH")
export class PatchInvoices implements IReturn<IdResponse>, IPatch, IPatchDb<Invoices>
{
    public invoiceId: number;
    public customerId: number;
    public invoiceDate: string;
    public billingAddress: string;
    public billingCity: string;
    public billingState: string;
    public billingCountry: string;
    public billingPostalCode: string;
    public total: number;

    public constructor(init?: Partial<PatchInvoices>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'PatchInvoices'; }
    public getMethod() { return 'PATCH'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/customers/{CustomerId}", "PUT")
export class UpdateCustomers implements IReturn<IdResponse>, IPut, IUpdateDb<Customers>
{
    public customerId: number;
    public firstName: string;
    public lastName: string;
    public company: string;
    public address: string;
    public city: string;
    public state: string;
    public country: string;
    public postalCode: string;
    public phone: string;
    public fax: string;
    public email: string;
    public supportRepId?: number;

    public constructor(init?: Partial<UpdateCustomers>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'UpdateCustomers'; }
    public getMethod() { return 'PUT'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/employees/{EmployeeId}", "PUT")
export class UpdateEmployees implements IReturn<IdResponse>, IPut, IUpdateDb<Employees>
{
    public employeeId: number;
    public lastName: string;
    public firstName: string;
    public title: string;
    public reportsTo?: number;
    public birthDate?: string;
    public hireDate?: string;
    public address: string;
    public city: string;
    public state: string;
    public country: string;
    public postalCode: string;
    public phone: string;
    public fax: string;
    public email: string;

    public constructor(init?: Partial<UpdateEmployees>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'UpdateEmployees'; }
    public getMethod() { return 'PUT'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/invoiceitems/{InvoiceLineId}", "PUT")
export class UpdateInvoiceItems implements IReturn<IdResponse>, IPut, IUpdateDb<InvoiceItems>
{
    public invoiceLineId: number;
    public invoiceId: number;
    public trackId: number;
    public unitPrice: number;
    public quantity: number;

    public constructor(init?: Partial<UpdateInvoiceItems>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'UpdateInvoiceItems'; }
    public getMethod() { return 'PUT'; }
    public createResponse() { return new IdResponse(); }
}

// @Route("/invoices/{InvoiceId}", "PUT")
export class UpdateInvoices implements IReturn<IdResponse>, IPut, IUpdateDb<Invoices>
{
    public invoiceId: number;
    public customerId: number;
    public invoiceDate: string;
    public billingAddress: string;
    public billingCity: string;
    public billingState: string;
    public billingCountry: string;
    public billingPostalCode: string;
    public total: number;

    public constructor(init?: Partial<UpdateInvoices>) { (Object as any).assign(this, init); }
    public getTypeName() { return 'UpdateInvoices'; }
    public getMethod() { return 'PUT'; }
    public createResponse() { return new IdResponse(); }
}


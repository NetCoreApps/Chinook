/* Options:
Date: 2023-11-28 15:28:06
Version: 8.01
Tip: To override a DTO option, remove "//" prefix before updating
BaseUrl: https://localhost:5001

//AddServiceStackTypes: True
//AddDocAnnotations: True
//AddDescriptionAsComments: True
//IncludeTypes: 
//ExcludeTypes: 
//DefaultImports: 
*/

"use strict";
export class QueryBase {
    /** @param {{skip?:number,take?:number,orderBy?:string,orderByDesc?:string,include?:string,fields?:string,meta?:{ [index: string]: string; }}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {?number} */
    skip;
    /** @type {?number} */
    take;
    /** @type {string} */
    orderBy;
    /** @type {string} */
    orderByDesc;
    /** @type {string} */
    include;
    /** @type {string} */
    fields;
    /** @type {{ [index: string]: string; }} */
    meta;
}
/** @typedef T {any} */
export class QueryDb extends QueryBase {
    /** @param {{skip?:number,take?:number,orderBy?:string,orderByDesc?:string,include?:string,fields?:string,meta?:{ [index: string]: string; }}} [init] */
    constructor(init) { super(init); Object.assign(this, init) }
}
export class Albums {
    /** @param {{albumId?:number,title?:string,artistId?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    albumId;
    /** @type {string} */
    title;
    /** @type {number} */
    artistId;
}
export class Artists {
    /** @param {{artistId?:number,name?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    artistId;
    /** @type {string} */
    name;
}
export class Genres {
    /** @param {{genreId?:number,name?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    genreId;
    /** @type {string} */
    name;
}
export class MediaTypes {
    /** @param {{mediaTypeId?:number,name?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    mediaTypeId;
    /** @type {string} */
    name;
}
export class Playlists {
    /** @param {{playlistId?:number,name?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    playlistId;
    /** @type {string} */
    name;
}
export class Tracks {
    /** @param {{trackId?:number,name?:string,albumId?:number,mediaTypeId?:number,genreId?:number,composer?:string,milliseconds?:number,bytes?:number,unitPrice?:number,album?:Albums,mediaType?:MediaTypes,genre?:Genres}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    trackId;
    /** @type {string} */
    name;
    /** @type {?number} */
    albumId;
    /** @type {number} */
    mediaTypeId;
    /** @type {?number} */
    genreId;
    /** @type {string} */
    composer;
    /** @type {number} */
    milliseconds;
    /** @type {?number} */
    bytes;
    /** @type {number} */
    unitPrice;
    /** @type {Albums} */
    album;
    /** @type {MediaTypes} */
    mediaType;
    /** @type {Genres} */
    genre;
}
export class Customers {
    /** @param {{customerId?:number,displayName?:string,firstName?:string,lastName?:string,supportRepId?:number,company?:string,address?:string,city?:string,state?:string,country?:string,postalCode?:string,phone?:string,fax?:string,email?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    customerId;
    /** @type {string} */
    displayName;
    /** @type {string} */
    firstName;
    /** @type {string} */
    lastName;
    /** @type {?number} */
    supportRepId;
    /** @type {string} */
    company;
    /** @type {string} */
    address;
    /** @type {string} */
    city;
    /** @type {string} */
    state;
    /** @type {string} */
    country;
    /** @type {string} */
    postalCode;
    /** @type {string} */
    phone;
    /** @type {string} */
    fax;
    /** @type {string} */
    email;
}
export class Employees {
    /** @param {{employeeId?:number,lastName?:string,firstName?:string,title?:string,reportsTo?:number,birthDate?:string,hireDate?:string,address?:string,city?:string,state?:string,country?:string,postalCode?:string,phone?:string,fax?:string,email?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    employeeId;
    /** @type {string} */
    lastName;
    /** @type {string} */
    firstName;
    /** @type {string} */
    title;
    /** @type {?number} */
    reportsTo;
    /** @type {?string} */
    birthDate;
    /** @type {?string} */
    hireDate;
    /** @type {string} */
    address;
    /** @type {string} */
    city;
    /** @type {string} */
    state;
    /** @type {string} */
    country;
    /** @type {string} */
    postalCode;
    /** @type {string} */
    phone;
    /** @type {string} */
    fax;
    /** @type {string} */
    email;
}
export class InvoiceItems {
    /** @param {{invoiceLineId?:number,invoiceId?:number,trackId?:number,unitPrice?:number,quantity?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    invoiceLineId;
    /** @type {number} */
    invoiceId;
    /** @type {number} */
    trackId;
    /** @type {number} */
    unitPrice;
    /** @type {number} */
    quantity;
}
export class Invoices {
    /** @param {{invoiceId?:number,customerId?:number,invoiceDate?:string,total?:number,billingAddress?:string,billingCity?:string,billingState?:string,billingCountry?:string,billingPostalCode?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    invoiceId;
    /** @type {number} */
    customerId;
    /** @type {string} */
    invoiceDate;
    /** @type {number} */
    total;
    /** @type {string} */
    billingAddress;
    /** @type {string} */
    billingCity;
    /** @type {string} */
    billingState;
    /** @type {string} */
    billingCountry;
    /** @type {string} */
    billingPostalCode;
}
export class ResponseError {
    /** @param {{errorCode?:string,fieldName?:string,message?:string,meta?:{ [index: string]: string; }}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string} */
    errorCode;
    /** @type {string} */
    fieldName;
    /** @type {string} */
    message;
    /** @type {{ [index: string]: string; }} */
    meta;
}
export class ResponseStatus {
    /** @param {{errorCode?:string,message?:string,stackTrace?:string,errors?:ResponseError[],meta?:{ [index: string]: string; }}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string} */
    errorCode;
    /** @type {string} */
    message;
    /** @type {string} */
    stackTrace;
    /** @type {ResponseError[]} */
    errors;
    /** @type {{ [index: string]: string; }} */
    meta;
}
export class HelloResponse {
    /** @param {{result?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string} */
    result;
}
/** @typedef T {any} */
export class QueryResponse {
    /** @param {{offset?:number,total?:number,results?:T[],meta?:{ [index: string]: string; },responseStatus?:ResponseStatus}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    offset;
    /** @type {number} */
    total;
    /** @type {T[]} */
    results;
    /** @type {{ [index: string]: string; }} */
    meta;
    /** @type {ResponseStatus} */
    responseStatus;
}
export class IdResponse {
    /** @param {{id?:string,responseStatus?:ResponseStatus}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string} */
    id;
    /** @type {ResponseStatus} */
    responseStatus;
}
export class Hello {
    /** @param {{name?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string} */
    name;
    getTypeName() { return 'Hello' }
    getMethod() { return 'POST' }
    createResponse() { return new HelloResponse() }
}
export class QueryAlbums extends QueryDb {
    /** @param {{albumId?:number,skip?:number,take?:number,orderBy?:string,orderByDesc?:string,include?:string,fields?:string,meta?:{ [index: string]: string; }}} [init] */
    constructor(init) { super(init); Object.assign(this, init) }
    /** @type {?number} */
    albumId;
    getTypeName() { return 'QueryAlbums' }
    getMethod() { return 'GET' }
    createResponse() { return new QueryResponse() }
}
export class QueryArtists extends QueryDb {
    /** @param {{artistId?:number,artistIdBetween?:number[],nameStartsWith?:string,skip?:number,take?:number,orderBy?:string,orderByDesc?:string,include?:string,fields?:string,meta?:{ [index: string]: string; }}} [init] */
    constructor(init) { super(init); Object.assign(this, init) }
    /** @type {?number} */
    artistId;
    /** @type {number[]} */
    artistIdBetween;
    /** @type {string} */
    nameStartsWith;
    getTypeName() { return 'QueryArtists' }
    getMethod() { return 'GET' }
    createResponse() { return new QueryResponse() }
}
export class QueryGenres extends QueryDb {
    /** @param {{genreId?:number,skip?:number,take?:number,orderBy?:string,orderByDesc?:string,include?:string,fields?:string,meta?:{ [index: string]: string; }}} [init] */
    constructor(init) { super(init); Object.assign(this, init) }
    /** @type {?number} */
    genreId;
    getTypeName() { return 'QueryGenres' }
    getMethod() { return 'GET' }
    createResponse() { return new QueryResponse() }
}
export class QueryMediaTypes extends QueryDb {
    /** @param {{mediaTypeId?:number,skip?:number,take?:number,orderBy?:string,orderByDesc?:string,include?:string,fields?:string,meta?:{ [index: string]: string; }}} [init] */
    constructor(init) { super(init); Object.assign(this, init) }
    /** @type {?number} */
    mediaTypeId;
    getTypeName() { return 'QueryMediaTypes' }
    getMethod() { return 'GET' }
    createResponse() { return new QueryResponse() }
}
export class QueryPlaylists extends QueryDb {
    /** @param {{playlistId?:number,skip?:number,take?:number,orderBy?:string,orderByDesc?:string,include?:string,fields?:string,meta?:{ [index: string]: string; }}} [init] */
    constructor(init) { super(init); Object.assign(this, init) }
    /** @type {?number} */
    playlistId;
    getTypeName() { return 'QueryPlaylists' }
    getMethod() { return 'GET' }
    createResponse() { return new QueryResponse() }
}
export class QueryTracks extends QueryDb {
    /** @param {{trackId?:number,nameContains?:string,skip?:number,take?:number,orderBy?:string,orderByDesc?:string,include?:string,fields?:string,meta?:{ [index: string]: string; }}} [init] */
    constructor(init) { super(init); Object.assign(this, init) }
    /** @type {?number} */
    trackId;
    /** @type {string} */
    nameContains;
    getTypeName() { return 'QueryTracks' }
    getMethod() { return 'GET' }
    createResponse() { return new QueryResponse() }
}
export class QueryCustomers extends QueryDb {
    /** @param {{customerId?:number,skip?:number,take?:number,orderBy?:string,orderByDesc?:string,include?:string,fields?:string,meta?:{ [index: string]: string; }}} [init] */
    constructor(init) { super(init); Object.assign(this, init) }
    /** @type {?number} */
    customerId;
    getTypeName() { return 'QueryCustomers' }
    getMethod() { return 'GET' }
    createResponse() { return new QueryResponse() }
}
export class QueryEmployees extends QueryDb {
    /** @param {{employeeId?:number,skip?:number,take?:number,orderBy?:string,orderByDesc?:string,include?:string,fields?:string,meta?:{ [index: string]: string; }}} [init] */
    constructor(init) { super(init); Object.assign(this, init) }
    /** @type {?number} */
    employeeId;
    getTypeName() { return 'QueryEmployees' }
    getMethod() { return 'GET' }
    createResponse() { return new QueryResponse() }
}
export class QueryInvoiceItems extends QueryDb {
    /** @param {{invoiceLineId?:number,skip?:number,take?:number,orderBy?:string,orderByDesc?:string,include?:string,fields?:string,meta?:{ [index: string]: string; }}} [init] */
    constructor(init) { super(init); Object.assign(this, init) }
    /** @type {?number} */
    invoiceLineId;
    getTypeName() { return 'QueryInvoiceItems' }
    getMethod() { return 'GET' }
    createResponse() { return new QueryResponse() }
}
export class QueryInvoices extends QueryDb {
    /** @param {{invoiceId?:number,skip?:number,take?:number,orderBy?:string,orderByDesc?:string,include?:string,fields?:string,meta?:{ [index: string]: string; }}} [init] */
    constructor(init) { super(init); Object.assign(this, init) }
    /** @type {?number} */
    invoiceId;
    getTypeName() { return 'QueryInvoices' }
    getMethod() { return 'GET' }
    createResponse() { return new QueryResponse() }
}
export class CreateAlbums {
    /** @param {{title?:string,artistId?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string} */
    title;
    /** @type {number} */
    artistId;
    getTypeName() { return 'CreateAlbums' }
    getMethod() { return 'POST' }
    createResponse() { return new IdResponse() }
}
export class CreateArtists {
    /** @param {{name?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string} */
    name;
    getTypeName() { return 'CreateArtists' }
    getMethod() { return 'POST' }
    createResponse() { return new IdResponse() }
}
export class CreateGenres {
    /** @param {{name?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string} */
    name;
    getTypeName() { return 'CreateGenres' }
    getMethod() { return 'POST' }
    createResponse() { return new IdResponse() }
}
export class CreateMediaTypes {
    /** @param {{name?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string} */
    name;
    getTypeName() { return 'CreateMediaTypes' }
    getMethod() { return 'POST' }
    createResponse() { return new IdResponse() }
}
export class CreatePlaylists {
    /** @param {{name?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string} */
    name;
    getTypeName() { return 'CreatePlaylists' }
    getMethod() { return 'POST' }
    createResponse() { return new IdResponse() }
}
export class CreateTracks {
    /** @param {{name?:string,albumId?:number,mediaTypeId?:number,genreId?:number,composer?:string,milliseconds?:number,bytes?:number,unitPrice?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string} */
    name;
    /** @type {?number} */
    albumId;
    /** @type {number} */
    mediaTypeId;
    /** @type {?number} */
    genreId;
    /** @type {string} */
    composer;
    /** @type {number} */
    milliseconds;
    /** @type {?number} */
    bytes;
    /** @type {number} */
    unitPrice;
    getTypeName() { return 'CreateTracks' }
    getMethod() { return 'POST' }
    createResponse() { return new IdResponse() }
}
export class DeleteAlbums {
    /** @param {{albumId?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    albumId;
    getTypeName() { return 'DeleteAlbums' }
    getMethod() { return 'DELETE' }
    createResponse() { return new IdResponse() }
}
export class DeleteArtists {
    /** @param {{artistId?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    artistId;
    getTypeName() { return 'DeleteArtists' }
    getMethod() { return 'DELETE' }
    createResponse() { return new IdResponse() }
}
export class DeleteGenres {
    /** @param {{genreId?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    genreId;
    getTypeName() { return 'DeleteGenres' }
    getMethod() { return 'DELETE' }
    createResponse() { return new IdResponse() }
}
export class DeleteMediaTypes {
    /** @param {{mediaTypeId?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    mediaTypeId;
    getTypeName() { return 'DeleteMediaTypes' }
    getMethod() { return 'DELETE' }
    createResponse() { return new IdResponse() }
}
export class DeletePlaylists {
    /** @param {{playlistId?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    playlistId;
    getTypeName() { return 'DeletePlaylists' }
    getMethod() { return 'DELETE' }
    createResponse() { return new IdResponse() }
}
export class DeleteTracks {
    /** @param {{trackId?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    trackId;
    getTypeName() { return 'DeleteTracks' }
    getMethod() { return 'DELETE' }
    createResponse() { return new IdResponse() }
}
export class PatchAlbums {
    /** @param {{albumId?:number,title?:string,artistId?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    albumId;
    /** @type {string} */
    title;
    /** @type {number} */
    artistId;
    getTypeName() { return 'PatchAlbums' }
    getMethod() { return 'PATCH' }
    createResponse() { return new IdResponse() }
}
export class PatchArtists {
    /** @param {{artistId?:number,name?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    artistId;
    /** @type {string} */
    name;
    getTypeName() { return 'PatchArtists' }
    getMethod() { return 'PATCH' }
    createResponse() { return new IdResponse() }
}
export class PatchGenres {
    /** @param {{genreId?:number,name?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    genreId;
    /** @type {string} */
    name;
    getTypeName() { return 'PatchGenres' }
    getMethod() { return 'PATCH' }
    createResponse() { return new IdResponse() }
}
export class PatchMediaTypes {
    /** @param {{mediaTypeId?:number,name?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    mediaTypeId;
    /** @type {string} */
    name;
    getTypeName() { return 'PatchMediaTypes' }
    getMethod() { return 'PATCH' }
    createResponse() { return new IdResponse() }
}
export class PatchPlaylists {
    /** @param {{playlistId?:number,name?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    playlistId;
    /** @type {string} */
    name;
    getTypeName() { return 'PatchPlaylists' }
    getMethod() { return 'PATCH' }
    createResponse() { return new IdResponse() }
}
export class PatchTracks {
    /** @param {{trackId?:number,name?:string,albumId?:number,mediaTypeId?:number,genreId?:number,composer?:string,milliseconds?:number,bytes?:number,unitPrice?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    trackId;
    /** @type {string} */
    name;
    /** @type {?number} */
    albumId;
    /** @type {number} */
    mediaTypeId;
    /** @type {?number} */
    genreId;
    /** @type {string} */
    composer;
    /** @type {number} */
    milliseconds;
    /** @type {?number} */
    bytes;
    /** @type {number} */
    unitPrice;
    getTypeName() { return 'PatchTracks' }
    getMethod() { return 'PATCH' }
    createResponse() { return new IdResponse() }
}
export class UpdateAlbums {
    /** @param {{albumId?:number,title?:string,artistId?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    albumId;
    /** @type {string} */
    title;
    /** @type {number} */
    artistId;
    getTypeName() { return 'UpdateAlbums' }
    getMethod() { return 'PUT' }
    createResponse() { return new IdResponse() }
}
export class UpdateArtists {
    /** @param {{artistId?:number,name?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    artistId;
    /** @type {string} */
    name;
    getTypeName() { return 'UpdateArtists' }
    getMethod() { return 'PUT' }
    createResponse() { return new IdResponse() }
}
export class UpdateGenres {
    /** @param {{genreId?:number,name?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    genreId;
    /** @type {string} */
    name;
    getTypeName() { return 'UpdateGenres' }
    getMethod() { return 'PUT' }
    createResponse() { return new IdResponse() }
}
export class UpdateMediaTypes {
    /** @param {{mediaTypeId?:number,name?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    mediaTypeId;
    /** @type {string} */
    name;
    getTypeName() { return 'UpdateMediaTypes' }
    getMethod() { return 'PUT' }
    createResponse() { return new IdResponse() }
}
export class UpdatePlaylists {
    /** @param {{playlistId?:number,name?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    playlistId;
    /** @type {string} */
    name;
    getTypeName() { return 'UpdatePlaylists' }
    getMethod() { return 'PUT' }
    createResponse() { return new IdResponse() }
}
export class UpdateTracks {
    /** @param {{trackId?:number,name?:string,albumId?:number,mediaTypeId?:number,genreId?:number,composer?:string,milliseconds?:number,bytes?:number,unitPrice?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    trackId;
    /** @type {string} */
    name;
    /** @type {?number} */
    albumId;
    /** @type {number} */
    mediaTypeId;
    /** @type {?number} */
    genreId;
    /** @type {string} */
    composer;
    /** @type {number} */
    milliseconds;
    /** @type {?number} */
    bytes;
    /** @type {number} */
    unitPrice;
    getTypeName() { return 'UpdateTracks' }
    getMethod() { return 'PUT' }
    createResponse() { return new IdResponse() }
}
export class CreateCustomers {
    /** @param {{firstName?:string,lastName?:string,company?:string,address?:string,city?:string,state?:string,country?:string,postalCode?:string,phone?:string,fax?:string,email?:string,supportRepId?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string} */
    firstName;
    /** @type {string} */
    lastName;
    /** @type {string} */
    company;
    /** @type {string} */
    address;
    /** @type {string} */
    city;
    /** @type {string} */
    state;
    /** @type {string} */
    country;
    /** @type {string} */
    postalCode;
    /** @type {string} */
    phone;
    /** @type {string} */
    fax;
    /** @type {string} */
    email;
    /** @type {?number} */
    supportRepId;
    getTypeName() { return 'CreateCustomers' }
    getMethod() { return 'POST' }
    createResponse() { return new IdResponse() }
}
export class CreateEmployees {
    /** @param {{lastName?:string,firstName?:string,title?:string,reportsTo?:number,birthDate?:string,hireDate?:string,address?:string,city?:string,state?:string,country?:string,postalCode?:string,phone?:string,fax?:string,email?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {string} */
    lastName;
    /** @type {string} */
    firstName;
    /** @type {string} */
    title;
    /** @type {?number} */
    reportsTo;
    /** @type {?string} */
    birthDate;
    /** @type {?string} */
    hireDate;
    /** @type {string} */
    address;
    /** @type {string} */
    city;
    /** @type {string} */
    state;
    /** @type {string} */
    country;
    /** @type {string} */
    postalCode;
    /** @type {string} */
    phone;
    /** @type {string} */
    fax;
    /** @type {string} */
    email;
    getTypeName() { return 'CreateEmployees' }
    getMethod() { return 'POST' }
    createResponse() { return new IdResponse() }
}
export class CreateInvoiceItems {
    /** @param {{invoiceId?:number,trackId?:number,unitPrice?:number,quantity?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    invoiceId;
    /** @type {number} */
    trackId;
    /** @type {number} */
    unitPrice;
    /** @type {number} */
    quantity;
    getTypeName() { return 'CreateInvoiceItems' }
    getMethod() { return 'POST' }
    createResponse() { return new IdResponse() }
}
export class CreateInvoices {
    /** @param {{customerId?:number,invoiceDate?:string,billingAddress?:string,billingCity?:string,billingState?:string,billingCountry?:string,billingPostalCode?:string,total?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    customerId;
    /** @type {string} */
    invoiceDate;
    /** @type {string} */
    billingAddress;
    /** @type {string} */
    billingCity;
    /** @type {string} */
    billingState;
    /** @type {string} */
    billingCountry;
    /** @type {string} */
    billingPostalCode;
    /** @type {number} */
    total;
    getTypeName() { return 'CreateInvoices' }
    getMethod() { return 'POST' }
    createResponse() { return new IdResponse() }
}
export class DeleteCustomers {
    /** @param {{customerId?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    customerId;
    getTypeName() { return 'DeleteCustomers' }
    getMethod() { return 'DELETE' }
    createResponse() { return new IdResponse() }
}
export class DeleteEmployees {
    /** @param {{employeeId?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    employeeId;
    getTypeName() { return 'DeleteEmployees' }
    getMethod() { return 'DELETE' }
    createResponse() { return new IdResponse() }
}
export class DeleteInvoiceItems {
    /** @param {{invoiceLineId?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    invoiceLineId;
    getTypeName() { return 'DeleteInvoiceItems' }
    getMethod() { return 'DELETE' }
    createResponse() { return new IdResponse() }
}
export class DeleteInvoices {
    /** @param {{invoiceId?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    invoiceId;
    getTypeName() { return 'DeleteInvoices' }
    getMethod() { return 'DELETE' }
    createResponse() { return new IdResponse() }
}
export class PatchCustomers {
    /** @param {{customerId?:number,firstName?:string,lastName?:string,company?:string,address?:string,city?:string,state?:string,country?:string,postalCode?:string,phone?:string,fax?:string,email?:string,supportRepId?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    customerId;
    /** @type {string} */
    firstName;
    /** @type {string} */
    lastName;
    /** @type {string} */
    company;
    /** @type {string} */
    address;
    /** @type {string} */
    city;
    /** @type {string} */
    state;
    /** @type {string} */
    country;
    /** @type {string} */
    postalCode;
    /** @type {string} */
    phone;
    /** @type {string} */
    fax;
    /** @type {string} */
    email;
    /** @type {?number} */
    supportRepId;
    getTypeName() { return 'PatchCustomers' }
    getMethod() { return 'PATCH' }
    createResponse() { return new IdResponse() }
}
export class PatchEmployees {
    /** @param {{employeeId?:number,lastName?:string,firstName?:string,title?:string,reportsTo?:number,birthDate?:string,hireDate?:string,address?:string,city?:string,state?:string,country?:string,postalCode?:string,phone?:string,fax?:string,email?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    employeeId;
    /** @type {string} */
    lastName;
    /** @type {string} */
    firstName;
    /** @type {string} */
    title;
    /** @type {?number} */
    reportsTo;
    /** @type {?string} */
    birthDate;
    /** @type {?string} */
    hireDate;
    /** @type {string} */
    address;
    /** @type {string} */
    city;
    /** @type {string} */
    state;
    /** @type {string} */
    country;
    /** @type {string} */
    postalCode;
    /** @type {string} */
    phone;
    /** @type {string} */
    fax;
    /** @type {string} */
    email;
    getTypeName() { return 'PatchEmployees' }
    getMethod() { return 'PATCH' }
    createResponse() { return new IdResponse() }
}
export class PatchInvoiceItems {
    /** @param {{invoiceLineId?:number,invoiceId?:number,trackId?:number,unitPrice?:number,quantity?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    invoiceLineId;
    /** @type {number} */
    invoiceId;
    /** @type {number} */
    trackId;
    /** @type {number} */
    unitPrice;
    /** @type {number} */
    quantity;
    getTypeName() { return 'PatchInvoiceItems' }
    getMethod() { return 'PATCH' }
    createResponse() { return new IdResponse() }
}
export class PatchInvoices {
    /** @param {{invoiceId?:number,customerId?:number,invoiceDate?:string,billingAddress?:string,billingCity?:string,billingState?:string,billingCountry?:string,billingPostalCode?:string,total?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    invoiceId;
    /** @type {number} */
    customerId;
    /** @type {string} */
    invoiceDate;
    /** @type {string} */
    billingAddress;
    /** @type {string} */
    billingCity;
    /** @type {string} */
    billingState;
    /** @type {string} */
    billingCountry;
    /** @type {string} */
    billingPostalCode;
    /** @type {number} */
    total;
    getTypeName() { return 'PatchInvoices' }
    getMethod() { return 'PATCH' }
    createResponse() { return new IdResponse() }
}
export class UpdateCustomers {
    /** @param {{customerId?:number,firstName?:string,lastName?:string,company?:string,address?:string,city?:string,state?:string,country?:string,postalCode?:string,phone?:string,fax?:string,email?:string,supportRepId?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    customerId;
    /** @type {string} */
    firstName;
    /** @type {string} */
    lastName;
    /** @type {string} */
    company;
    /** @type {string} */
    address;
    /** @type {string} */
    city;
    /** @type {string} */
    state;
    /** @type {string} */
    country;
    /** @type {string} */
    postalCode;
    /** @type {string} */
    phone;
    /** @type {string} */
    fax;
    /** @type {string} */
    email;
    /** @type {?number} */
    supportRepId;
    getTypeName() { return 'UpdateCustomers' }
    getMethod() { return 'PUT' }
    createResponse() { return new IdResponse() }
}
export class UpdateEmployees {
    /** @param {{employeeId?:number,lastName?:string,firstName?:string,title?:string,reportsTo?:number,birthDate?:string,hireDate?:string,address?:string,city?:string,state?:string,country?:string,postalCode?:string,phone?:string,fax?:string,email?:string}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    employeeId;
    /** @type {string} */
    lastName;
    /** @type {string} */
    firstName;
    /** @type {string} */
    title;
    /** @type {?number} */
    reportsTo;
    /** @type {?string} */
    birthDate;
    /** @type {?string} */
    hireDate;
    /** @type {string} */
    address;
    /** @type {string} */
    city;
    /** @type {string} */
    state;
    /** @type {string} */
    country;
    /** @type {string} */
    postalCode;
    /** @type {string} */
    phone;
    /** @type {string} */
    fax;
    /** @type {string} */
    email;
    getTypeName() { return 'UpdateEmployees' }
    getMethod() { return 'PUT' }
    createResponse() { return new IdResponse() }
}
export class UpdateInvoiceItems {
    /** @param {{invoiceLineId?:number,invoiceId?:number,trackId?:number,unitPrice?:number,quantity?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    invoiceLineId;
    /** @type {number} */
    invoiceId;
    /** @type {number} */
    trackId;
    /** @type {number} */
    unitPrice;
    /** @type {number} */
    quantity;
    getTypeName() { return 'UpdateInvoiceItems' }
    getMethod() { return 'PUT' }
    createResponse() { return new IdResponse() }
}
export class UpdateInvoices {
    /** @param {{invoiceId?:number,customerId?:number,invoiceDate?:string,billingAddress?:string,billingCity?:string,billingState?:string,billingCountry?:string,billingPostalCode?:string,total?:number}} [init] */
    constructor(init) { Object.assign(this, init) }
    /** @type {number} */
    invoiceId;
    /** @type {number} */
    customerId;
    /** @type {string} */
    invoiceDate;
    /** @type {string} */
    billingAddress;
    /** @type {string} */
    billingCity;
    /** @type {string} */
    billingState;
    /** @type {string} */
    billingCountry;
    /** @type {string} */
    billingPostalCode;
    /** @type {number} */
    total;
    getTypeName() { return 'UpdateInvoices' }
    getMethod() { return 'PUT' }
    createResponse() { return new IdResponse() }
}


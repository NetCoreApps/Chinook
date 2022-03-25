using System;
using ServiceStack;
using ServiceStack.DataAnnotations;
using Chinook.ServiceModel.Types;
using Chinook.ServiceModel;

namespace Chinook.ServiceModel;

[Route("/albums", "POST"), Tag(Tags.Media)]
public class CreateAlbums
    : IReturn<IdResponse>, IPost, ICreateDb<Albums>
{
    [ValidateNotEmpty]
    public string Title { get; set; }
    [ValidateGreaterThan(0)]
    public long ArtistId { get; set; }
}

[Route("/artists", "POST"), Tag(Tags.Media)]
public class CreateArtists
    : IReturn<IdResponse>, IPost, ICreateDb<Artists>
{
    public string Name { get; set; }
}

[Route("/genres", "POST"), Tag(Tags.Media)]
public class CreateGenres
    : IReturn<IdResponse>, IPost, ICreateDb<Genres>
{
    public string Name { get; set; }
}

[Route("/mediatypes", "POST"), Tag(Tags.Media)]
public class CreateMediaTypes
    : IReturn<IdResponse>, IPost, ICreateDb<MediaTypes>
{
    public string Name { get; set; }
}

[Route("/playlists", "POST"), Tag(Tags.Media)]
public class CreatePlaylists
    : IReturn<IdResponse>, IPost, ICreateDb<Playlists>
{
    public string Name { get; set; }
}

[Route("/tracks", "POST"), Tag(Tags.Media)]
public class CreateTracks
    : IReturn<IdResponse>, IPost, ICreateDb<Tracks>
{
    public string Name { get; set; }
    public long? AlbumId { get; set; }
    public long MediaTypeId { get; set; }
    public long? GenreId { get; set; }
    public string Composer { get; set; }
    public long Milliseconds { get; set; }
    public long? Bytes { get; set; }
    public decimal UnitPrice { get; set; }
}

[Route("/albums/{AlbumId}", "DELETE"), Tag(Tags.Media)]
public class DeleteAlbums
    : IReturn<IdResponse>, IDelete, IDeleteDb<Albums>
{
    public long AlbumId { get; set; }
}

[Route("/artists/{ArtistId}", "DELETE"), Tag(Tags.Media)]
public class DeleteArtists
    : IReturn<IdResponse>, IDelete, IDeleteDb<Artists>
{
    public long ArtistId { get; set; }
}

[Route("/genres/{GenreId}", "DELETE"), Tag(Tags.Media)]
public class DeleteGenres
    : IReturn<IdResponse>, IDelete, IDeleteDb<Genres>
{
    public long GenreId { get; set; }
}

[Route("/mediatypes/{MediaTypeId}", "DELETE"), Tag(Tags.Media)]
public class DeleteMediaTypes
    : IReturn<IdResponse>, IDelete, IDeleteDb<MediaTypes>
{
    public long MediaTypeId { get; set; }
}

[Route("/playlists/{PlaylistId}", "DELETE"), Tag(Tags.Media)]
public class DeletePlaylists
    : IReturn<IdResponse>, IDelete, IDeleteDb<Playlists>
{
    public long PlaylistId { get; set; }
}

[Route("/tracks/{TrackId}", "DELETE"), Tag(Tags.Media)]
public class DeleteTracks
    : IReturn<IdResponse>, IDelete, IDeleteDb<Tracks>
{
    public long TrackId { get; set; }
}

[Route("/albums/{AlbumId}", "PATCH"), Tag(Tags.Media)]
public class PatchAlbums
    : IReturn<IdResponse>, IPatch, IPatchDb<Albums>
{
    public long AlbumId { get; set; }
    public string Title { get; set; }
    public long ArtistId { get; set; }
}

[Route("/artists/{ArtistId}", "PATCH"), Tag(Tags.Media)]
public class PatchArtists
    : IReturn<IdResponse>, IPatch, IPatchDb<Artists>
{
    public long ArtistId { get; set; }
    public string Name { get; set; }
}

[Route("/genres/{GenreId}", "PATCH"), Tag(Tags.Media)]
public class PatchGenres
    : IReturn<IdResponse>, IPatch, IPatchDb<Genres>
{
    public long GenreId { get; set; }
    public string Name { get; set; }
}

[Route("/mediatypes/{MediaTypeId}", "PATCH"), Tag(Tags.Media)]
public class PatchMediaTypes
    : IReturn<IdResponse>, IPatch, IPatchDb<MediaTypes>
{
    public long MediaTypeId { get; set; }
    public string Name { get; set; }
}

[Route("/playlists/{PlaylistId}", "PATCH"), Tag(Tags.Media)]
public class PatchPlaylists
    : IReturn<IdResponse>, IPatch, IPatchDb<Playlists>
{
    public long PlaylistId { get; set; }
    public string Name { get; set; }
}

[Route("/tracks/{TrackId}", "PATCH"), Tag(Tags.Media)]
public class PatchTracks
    : IReturn<IdResponse>, IPatch, IPatchDb<Tracks>
{
    public long TrackId { get; set; }
    public string Name { get; set; }
    public long? AlbumId { get; set; }
    public long MediaTypeId { get; set; }
    public long? GenreId { get; set; }
    public string Composer { get; set; }
    public long Milliseconds { get; set; }
    public long? Bytes { get; set; }
    public decimal UnitPrice { get; set; }
}

[Route("/albums", "GET"), Tag(Tags.Media)]
[Route("/albums/{AlbumId}", "GET")]
public class QueryAlbums
    : QueryDb<Albums>, IReturn<QueryResponse<Albums>>, IGet
{
    public long? AlbumId { get; set; }
}

[Route("/artists", "GET"), Tag(Tags.Media)]
[Route("/artists/{ArtistId}", "GET")]
public class QueryArtists
    : QueryDb<Artists>, IReturn<QueryResponse<Artists>>, IGet
{
    public long? ArtistId { get; set; }
    public long[] ArtistIdBetween { get; set; }
    public string NameStartsWith { get; set; }
}

[Route("/genres", "GET"), Tag(Tags.Media)]
[Route("/genres/{GenreId}", "GET")]
public class QueryGenres
    : QueryDb<Genres>, IReturn<QueryResponse<Genres>>, IGet
{
    public long? GenreId { get; set; }
}

[Route("/mediatypes", "GET"), Tag(Tags.Media)]
[Route("/mediatypes/{MediaTypeId}", "GET")]
public class QueryMediaTypes
    : QueryDb<MediaTypes>, IReturn<QueryResponse<MediaTypes>>, IGet
{
    public long? MediaTypeId { get; set; }
}

[Route("/playlists", "GET"), Tag(Tags.Media)]
[Route("/playlists/{PlaylistId}", "GET")]
public class QueryPlaylists
    : QueryDb<Playlists>, IReturn<QueryResponse<Playlists>>, IGet
{
    public long? PlaylistId { get; set; }
}

[Route("/tracks", "GET"), Tag(Tags.Media)]
[Route("/tracks/{TrackId}", "GET")]
public class QueryTracks
    : QueryDb<Tracks>, IReturn<QueryResponse<Tracks>>, IGet
{
    public long? TrackId { get; set; }
    public string NameContains { get; set; }
}

[Route("/albums/{AlbumId}", "PUT"), Tag(Tags.Media)]
public class UpdateAlbums
    : IReturn<IdResponse>, IPut, IUpdateDb<Albums>
{
    public long AlbumId { get; set; }
    public string Title { get; set; }
    public long ArtistId { get; set; }
}

[Route("/artists/{ArtistId}", "PUT"), Tag(Tags.Media)]
public class UpdateArtists
    : IReturn<IdResponse>, IPut, IUpdateDb<Artists>
{
    public long ArtistId { get; set; }
    public string Name { get; set; }
}

[Route("/genres/{GenreId}", "PUT"), Tag(Tags.Media)]
public class UpdateGenres
    : IReturn<IdResponse>, IPut, IUpdateDb<Genres>
{
    public long GenreId { get; set; }
    public string Name { get; set; }
}

[Route("/mediatypes/{MediaTypeId}", "PUT"), Tag(Tags.Media)]
public class UpdateMediaTypes
    : IReturn<IdResponse>, IPut, IUpdateDb<MediaTypes>
{
    public long MediaTypeId { get; set; }
    public string Name { get; set; }
}

[Route("/playlists/{PlaylistId}", "PUT"), Tag(Tags.Media)]
public class UpdatePlaylists
    : IReturn<IdResponse>, IPut, IUpdateDb<Playlists>
{
    public long PlaylistId { get; set; }
    public string Name { get; set; }
}

[Route("/tracks/{TrackId}", "PUT"), Tag(Tags.Media)]
public class UpdateTracks
    : IReturn<IdResponse>, IPut, IUpdateDb<Tracks>
{
    public long TrackId { get; set; }
    public string Name { get; set; }
    public long? AlbumId { get; set; }
    public long MediaTypeId { get; set; }
    public long? GenreId { get; set; }
    public string Composer { get; set; }
    public long Milliseconds { get; set; }
    public long? Bytes { get; set; }
    public decimal UnitPrice { get; set; }
}
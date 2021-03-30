using System;
using System.Linq;
using NUnit.Framework;
using ServiceStack;
using ServiceStack.Text;
using Chinook.ServiceModel;
using Chinook.ServiceModel.Types;

namespace Chinook.Tests
{
    [Ignore("AutoQuery & CRUD Example")]
    public class AutoQueryCrudTests
    {
        JsonServiceClient client = new("https://localhost:5001");

        [Test]
        public void Can_create_and_query_new_Artist_Album_and_Track()
        {
            var genres = client.Get(new QueryGenres()).Results.ToDictionary(x => x.Name);
            var mediaTypes = client.Get(new QueryMediaTypes()).Results.ToDictionary(x => x.Name);
            
            var newArtist = client.Post(new CreateArtists {
                Name = "PSY"
            });
            var artistId = newArtist.Id.ToLong();
            var newAlbum = client.Post(new CreateAlbums {
                ArtistId = artistId,
                Title = "Psy 6 (Six Rules), Part 1",
            });
            var albumId = newAlbum.Id.ToLong();
            var newTrack = client.Post(new CreateTracks {
                AlbumId = albumId,
                Name = "Gangnam Style",
                Composer = "Park Jae-sang",
                Milliseconds = (long)new TimeSpan(0,3,39).TotalMilliseconds,
                GenreId = genres["Electronica/Dance"].GenreId,
                UnitPrice = 0.99m,
                MediaTypeId = mediaTypes["AAC audio file"].MediaTypeId,
                Bytes = 6683350,
            });

            var track = client.Get(new QueryTracks {
                TrackId = newTrack.Id.ToLong(), 
            });
            track.PrintDump();
        }

        [Test]
        public void Example_Artists_Query()
        {
            var response = client.Get(new QueryArtists {
                ArtistIdBetween = new long[]{ 1, 100 },
                NameStartsWith = "F",
            });
            response.PrintDump();
        }

        [Test]
        public void Example_Tracks_Query()
        {
            var response = client.Get(new QueryTracks {
                NameContains = "Heart",
                Skip = 5,
                Take = 10,
                Fields = "TrackId,Name,Milliseconds"
            });
            response.PrintDump();
        }
    }
}
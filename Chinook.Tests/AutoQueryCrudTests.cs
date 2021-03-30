using System;
using System.Linq;
using NUnit.Framework;
using ServiceStack;
using ServiceStack.Text;
using Chinook.ServiceModel;

namespace Chinook.Tests
{
    public class AutoQueryCrudTests
    {
        [Test]
        public void Can_create_and_query_new_Artist_Album_and_Track()
        {
            var client = new JsonServiceClient("https://localhost:5001");

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
    }
}
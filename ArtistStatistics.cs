using RadioStatistics.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadioStatistics
{
    public class ArtistStatistics : IArtistStatistics
    {
        public IEnumerable<Artist> Artists { get; set; }
        public ArtistStatistics(IEnumerable<Artist> artists)
        {
            Artists = artists;
        }

        // 4 
        public IEnumerable<ArtistMetadata> GetArtistsAndAlbumCount()
        {
            return Artists.ToList().Select(a => new ArtistMetadata { Name = a.Name, AlbumCount = a.Albums.Count() }).ToList();
        }


        // 2
        public IEnumerable<Artist> GetArtistsOrderdByName()
        {
            return Artists.OrderBy(a => a.Name).ToList();
        }


        // 5
        public Artist GetArtistWithMostAlbums()
        {
            return Artists.OrderByDescending(a => a.Albums.Count()).FirstOrDefault();
        }

        // 1
        public IEnumerable<Artist> GetCatchyNamedArtists()
        {
            return Artists.Where(a => a.Name.Length < 7).ToList();
        }

        // 7 
        public IEnumerable<Artist> GetDiggingArtists()
        {
            return Artists.Where(artis => artis.Albums.Any(t => t.Tracks.Any(d => d.Duration.TotalHours == 1))).ToList();
        }

        // 9
        public IEnumerable<Artist> GetEligibleForIsraelArtists()
        {
            return Artists.Where(artis => artis.Albums.Any(t => t.Tracks.Sum(d => d.Duration.TotalMinutes) >= 120)).ToList();
        }


        // 3
        public Artist GetFirstArtistWithTwoAlbums()
        {
            return Artists.FirstOrDefault(a => a.Albums.Count() == 2);
        }


        // 8
        public IEnumerable<Artist> GetSlackerArtists()
        {
            return Artists.Where(artis => artis.Albums.Any(t => t.Tracks.Count(d => d.Duration.TotalSeconds < 60) >= 2)).ToList();
        }

        // 6
        public IEnumerable<Artist> GetYoungArtists()
        {
            return Artists.Where(a => a.Albums.Count() > 0 && a.Albums.Count() <= 2).ToList();
        }



        // 10
        public IEnumerable<Artist> GetWritersBlockArtists() 
        {
            return Artists.Where(artis => artis.Albums.Any(t => t.Tracks.GroupBy(g => g.Name).Count() >= 3)).ToList();
            
        }
    }
}

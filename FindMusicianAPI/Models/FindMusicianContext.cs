using Microsoft.EntityFrameworkCore;

namespace FindMusicianAPI.Models
{

    public class FindMusicianContext : DbContext
    {

        public FindMusicianContext(DbContextOptions<FindMusicianContext> options) : base(options) { }

        public DbSet<FindMusicianAPI.Models.Artist> Artist { get; set; }

        public DbSet<FindMusicianAPI.Models.Event> Event { get; set; }

    }


}
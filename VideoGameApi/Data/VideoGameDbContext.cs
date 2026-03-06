using Microsoft.EntityFrameworkCore;
using VideoGameApi.Controllers;

namespace VideoGameApi.Data
{
    public class VideoGameDbContext : DbContext
    {
        public VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : base(options)
        {
            
        }
        public DbSet<VideoGame> VideoGame => Set<VideoGame>();
    }
}

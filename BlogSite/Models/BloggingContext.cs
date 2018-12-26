using Microsoft.EntityFrameworkCore;

namespace BlogSite.Models
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UnmappedIntegerValue> UnmappedIntegerValue { get; set; }
        public DbSet<UnmappedDoubleValue> UnmappedDoubleValue { get; set; }
    }
}
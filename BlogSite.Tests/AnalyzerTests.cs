using System;
using BlogSite.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BlogSite.Tests
{
    public class AnalyzerTests
    {
        [Fact]
        public void CountOfBlogsReturnsValueFronDatabase()
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=BlogSite;Trusted_Connection=True;ConnectRetryCount=0";
            var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
            optionsBuilder.UseSqlServer(connection);
            BloggingContext bloggingContext = new BloggingContext(optionsBuilder.Options);

            Analyzer analyzer = new Analyzer(bloggingContext);
            Assert.Equal(3, analyzer.GetCountOfBlogs());
        }
    }
}

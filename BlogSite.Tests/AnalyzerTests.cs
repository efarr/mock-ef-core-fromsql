using System;
using BlogSite.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BlogSite.Tests
{
    public class AnalyzerTests
    {
        private static BloggingContext GetBloggingContext()
        {
            var options = new DbContextOptionsBuilder<BloggingContext>().UseInMemoryDatabase(databaseName: "Test").Options;
            return new BloggingContext(options);
        }

        [Fact]
        public void CountOfBlogsReturnsValueFronDatabase()
        {
            var bloggingContext = GetBloggingContext();

            Analyzer analyzer = new Analyzer(bloggingContext);
            Assert.Equal(3, analyzer.GetCountOfBlogs());
        }

        [Fact]
        public void AverageNumberOfPostsReturnsValueFronDatabase()
        {
            var bloggingContext = GetBloggingContext();

            Analyzer analyzer = new Analyzer(bloggingContext);
            Assert.Equal(3.5, analyzer.GetAveragePostsPerBlogs());
        }
    }
}

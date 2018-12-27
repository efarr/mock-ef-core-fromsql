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

            var response = new AsyncEnumerableQueryableReturn<UnmappedIntegerValue>(new UnmappedIntegerValue { Value = 3 });

            bloggingContext.UnmappedIntegerValue = bloggingContext.UnmappedIntegerValue.MockFromSql(response);

            Analyzer analyzer = new Analyzer(bloggingContext);
            Assert.Equal(3, analyzer.GetCountOfBlogs());
        }

        [Fact]
        public void AverageNumberOfPostsReturnsValueFronDatabase()
        {
            var bloggingContext = GetBloggingContext();

            var response = new AsyncEnumerableQueryableReturn<UnmappedDoubleValue>(new UnmappedDoubleValue { Value = 3.5 });

            bloggingContext.UnmappedDoubleValue = bloggingContext.UnmappedDoubleValue.MockFromSql(response);

            Analyzer analyzer = new Analyzer(bloggingContext);
            Assert.Equal(3.5, analyzer.GetAveragePostsPerBlogs());
        }

    }
}

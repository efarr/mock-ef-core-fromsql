using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Models
{
    [NotMapped]
    public class UnmappedIntegerValue
    {
        [Key]
        public int Value { get; set; }
    }
    [NotMapped]
    public class UnmappedDoubleValue
    {
        [Key]
        public double Value { get; set; }
    }

    public class Analyzer : IAnalyzer
    {
        private readonly BloggingContext _bloggingContext;

        public Analyzer(BloggingContext bloggingContext)
        {
            _bloggingContext = bloggingContext;
        }

        public int GetCountOfBlogs()
        {
            var result = _bloggingContext.UnmappedIntegerValue.FromSql("exec dbo.uspCountOfBlogs");
            return result.First().Value;
        }

        public double GetAveragePostsPerBlogs()
        {
            var result = _bloggingContext.UnmappedIntegerValue.FromSql("exec dbo.uspAverageNumPosts");
            return result.First().Value;
        }
    }
}

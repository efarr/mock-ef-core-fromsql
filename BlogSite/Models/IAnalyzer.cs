namespace BlogSite.Models
{
    public interface IAnalyzer
    {
        int GetCountOfBlogs();
        double GetAveragePostsPerBlogs();

    }
}
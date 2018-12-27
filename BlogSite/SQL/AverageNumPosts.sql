USE BlogSite;
GO
DROP PROCEDURE IF EXISTS dbo.uspAverageNumPosts;
GO
CREATE PROCEDURE uspAverageNumPosts
AS
	declare @blogCount float
	declare @postCount float
	select @blogCount = count(*) from Blogs
	select @postCount = count(*) from Posts
	select @postCount / @blogCount
GO
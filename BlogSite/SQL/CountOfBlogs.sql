USE BlogSite;
GO
DROP PROCEDURE IF EXISTS dbo.uspCountOfBlogs;
GO
CREATE PROCEDURE uspCountOfBlogs
AS
	SELECT count(*) FROM Blogs
GO
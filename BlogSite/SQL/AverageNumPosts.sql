use BlogSite;
go
create procedure uspAverageNumPosts
as
	declare @blogCount float
	declare @postCount float
	select @blogCount = count(*) from Blogs
	select @postCount = count(*) from Posts
	select @postCount / @blogCount
go
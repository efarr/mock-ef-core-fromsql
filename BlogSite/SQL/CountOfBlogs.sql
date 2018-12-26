use BlogSite;
go
create procedure uspCountOfBlogs
as
	select count(*) from Blogs
go
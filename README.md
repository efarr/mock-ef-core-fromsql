## Example code for mocking Entity Framework stored procedure calls for tests.

Entity Framework Core has the wonderfully useful in-memory database that means you don't need to mock out the database for tests. Just spin up and in-memory database, load some test data, and off you go. 

If you have to support a legacy database with stored procedures, and your code can't avoid calling those sprocs, you are out of luck. There is no in-memory support for the FromSql extension method or sprocs.

This code is an example of how to use Moq to mock out the missing functionality required to fake out calls to FromSql.

### Adding Stored Proceedures through EF migrations

EF code-first doesn't expect you to have stored procedures; so, you won't find any support for creating sprocs through migrations. This sample shows how to add them in, anyway.

First, add your create scripts as project resources. I added my two scripts under a directory I called SQL.

Second, add an empty migration with this command:

```
dotnet ef migrations add StoredProcs
```

Add the code you see in the Up method in 20181227202527_StoredProcs.cs.

Finally, run the migrations:

```
dotnet ef database update
```
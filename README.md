## Chinook

Auto generate typed AutoQuery & CRUD APIs around SQLite's sample Chinook Database.

1. Create new empty Web App

    $ x new web Chinook

2. [Mix](https://docs.servicestack.net/mix-tool) in AutoQuery [AutoGen](https://gist.github.com/gistlyn/464a80c15cb3af4f41db7810082dc00c), OrmLite [SQLite](https://gist.github.com/gistlyn/a670c1d9b0ac06caa6a7fbb9b1d44176) and [chinook.sqlite](https://gist.github.com/gistlyn/aa62996dce3a6c1c8680beb8ab98126f) database:

    $ x mix autocrudgen sqlite chinook.sqlite

This configures our App to use AutoQuery & SQLite dependencies & config, which then needs to be updated to reference the local **chinook.sqlite** database:

```csharp
public void Configure(IServiceCollection services)
{
    services.AddSingleton<IDbConnectionFactory>(new OrmLiteConnectionFactory(
        Configuration.GetConnectionString("DefaultConnection") 
        ?? "chinook.sqlite",
        SqliteDialect.Provider));
}
```

### Instant Servicified Database

That's all that's required to generate a AutoQuery and AutoQuery CRUD typed API around [SQLite's sample Chinook Database](https://www.sqlitetutorial.net/sqlite-sample-database/) that we can run with:

    $ dotnet run

Then Navigate to the `/metadata` page to view all AutoQuery APIs for each table in the Chinook DB:

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/autoquery/chinook-autogen-metadata.png)

Drilling down to a single API will show details about each API, including its Routes and the schema for Request, Response and all other DTOs used:

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/autoquery/chinook-autogen-createtracks.png)


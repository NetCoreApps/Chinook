## Chinook

Auto generate typed AutoQuery & CRUD APIs around SQLite's sample Chinook Database.

1. Create new empty Web App

```
$ x new web Chinook
```

2. [Mix](https://docs.servicestack.net/mix-tool) in AutoQuery [AutoGen](https://gist.github.com/gistlyn/464a80c15cb3af4f41db7810082dc00c), OrmLite [SQLite](https://gist.github.com/gistlyn/a670c1d9b0ac06caa6a7fbb9b1d44176) and [chinook.sqlite](https://gist.github.com/gistlyn/aa62996dce3a6c1c8680beb8ab98126f) database:

```
$ x mix autocrudgen sqlite chinook.sqlite
```

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


### Deployments

The `x mix` tool is used to jump start our deployments via GitHub Actions.

Your server setup will depend on which `release-*` template you use, the one with the smallest infrastructure footprint is the `release-ghr-vanilla` that uses GitHub Container Repository to store your Docker images. See our [full tutorial for details on server setup using Digital Ocean](https://docs.servicestack.net/do-github-action-mix-deployment).

- In the root of your repository run `x mix build release-ghr-vanilla` or other release strategy (See `GitHub` tag in `x mix` for details).
- Create a Dockerfile with `x mix docker-dotnet`.
- Adjust pathing in [`.github/workflows/build.yml`](https://github.com/NetCoreApps/Chinook/blob/main/.github/workflows/build.yml#L23) to point to Chinook.sln and Chinook.Tests.
- Adjust [Dockerfile `WORKDIR` to `Chinook` directory that contains the Chinook.sln](https://github.com/NetCoreApps/Chinook/blob/main/Dockerfile#L5) file.
- Update your repository secrets based on readme in `.github/workflows/readme.md`
- Create a release to deploy your application.

 Your hosting setup will be different based on which template you select, 

- Using your DNS provider, create a subdomain `A` record pointing to your hosted Linux server
- Remote to your Linux server to install Docker and `docker-compose`.
- Use `deploy/nginx-proxy-compose.yml` to run nginx-proxy on your Linux server.

See our full `x mix` GitHub Action Tutorials in the ServiceStack docs.

- [Deploying to Digital Ocean Droplet directly via GitHub Actions and SSH](https://docs.servicestack.net/do-github-action-mix-deployment)
- [GitHub Actions mix template - Deploy to AWS ECS](https://docs.servicestack.net/mix-github-actions-aws-ecs)

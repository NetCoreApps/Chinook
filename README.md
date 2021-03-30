## Chinook

Auto generate typed AutoQuery & CRUD APIs around SQLite's sample Chinook Database.

1. Create new empty Web App

```
$ x new web Chinook
```

2. [Mix](https://docs.servicestack.net/mix-tool) in AutoQuery [AutoGen](https://gist.github.com/gistlyn/464a80c15cb3af4f41db7810082dc00c), OrmLite [SQLite](https://gist.github.com/gistlyn/a670c1d9b0ac06caa6a7fbb9b1d44176) and [chinook.sqlite](https://gist.github.com/gistlyn/aa62996dce3a6c1c8680beb8ab98126f) database:

```
$ cd Chinook
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

### Metadata pages

Navigate to the `/metadata` page to view all AutoQuery APIs for each table in the Chinook DB:

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/autoquery/chinook-autogen-metadata.png)

Navigating to an API will drill down to show more details about each API, including schemas for Request, Response and all other DTOs used, its Routes & Auth Info:

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/autoquery/chinook-autogen-createtracks.png)

### Querying APIs

With AutoQuery & CRUD APIs generated for each of Chinook's RDBMS tables we can now start querying fields on each table
with any of the built-in [Implicit Querying Conventions](https://docs.servicestack.net/autoquery-rdbms#implicit-conventions), 
e.g. We can view all artists starting `F%` within the first 100 registered artists with:

https://localhost:5001/artists?ArtistIdBetween=1,100&NameStartsWith=F

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/autoquery/chinook-autoquery-artists.png)

All the standard querying functions are available, e.g. Sorting for [Multiple OrderBy's](https://docs.servicestack.net/autoquery-rdbms#multiple-orderbys),
Page through query results with [Skip and Take](https://docs.servicestack.net/autoquery-rdbms#paging-and-ordering),
selecting [Custom Fields](https://docs.servicestack.net/autoquery-rdbms#custom-fields) & applying [custom JSON configuration](https://docs.servicestack.net/customize-json-responses), e.g:

https://localhost:5001/tracks?NameContains=Heart&OrderBy=Name&Skip=5&Take=10&fields=TrackId,Name,Milliseconds&jsconfig=ExcludeDefaultValues

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/autoquery/chinook-autoquery-tracks.png)

All APIs support standard [HTTP Content Negotiation](https://docs.servicestack.net/routing#content-negotiation) options, e.g. 
you can request the response in JSON my appending the route with a `.json` format specifier: 

https://localhost:5001/tracks.json?NameContains=Heart&OrderBy=Name&Skip=5&Take=10&fields=TrackId,Name,Milliseconds&jsconfig=ExcludeDefaultValues

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/autoquery/chinook-autoquery-tracks-json.png)

## Convert to code-first Services

ServiceStack's [AutoGen feature](https://docs.servicestack.net/autogen) creates typed ServiceStack Services in memory
based on the configured RDBMS Schema at Startup, they're indistinguishable from hand-crafted code-first Services and can 
take advantage of ecosystem of features around ServiceStack Services like 
[Add ServiceStack Reference](https://docs.servicestack.net/add-servicestack-reference) for generating rich, typed APIs
around popular Web, Mobile and Desktop programming languages.

The disadvantage of autogen Services is that they only exist as generated Types at runtime limiting their ability to 
be easily enhanced further. When further customization is needed the AutoGen Types can be synthesized into Typed
C# DTOs by generating them in your ServiceModel project with:

    $ cd Chinook.ServiceModel
    $ x csharp https://localhost:5001 -path /crud/all/csharp

Which generates the C# Models and APIs that would otherwise have been generated at Startup, which since they exist in 
source code no longer need to be generated and can now be disabled by removing AutoGen's `AutoRegister` directive:

```csharp
appHost.Plugins.Add(new AutoQueryFeature {
    MaxLimit = 1000,
    IncludeTotal = true,
    // GenerateCrudServices = new GenerateCrudServices {
    //     AutoRegister = true,
    //     AddDataContractAttributes = false,
    // }
});
```

Should you wish to apply any App conventions or additional validation & authorization to the generated Services 
(e.g. for write operations or selected tables), the [code generation can be customized](https://docs.servicestack.net/autogen#customize-code-generation-to-include-app-conventions)
before generating the types.

### Using generated Services

After a restart, the Chinook App switches from a DB-first generated ServiceStack App to a standard code-first ServiceStack App
with the same exact functionality except that the Typed AutoQuery APIs exists as C# source code which can be easily enhanced,
e.g. with [Declarative or Authorization attributes](https://docs.servicestack.net/declarative-validation).

A trait of ServiceStack, is that its Service Models are symmetrical, that is, the same server DTOs used to define your Services Contract 
can be used as-is in its [Smart, Generic Service Clients](https://docs.servicestack.net/csharp-client) to enable an end-to-end Typed API.

Which means we already have everything we need to immediately start developing client applications against its AutoQuery CRUD APIs. 
Lets test this out by using the Typed DTOs to add PSY's iconic "Gangnam Style" to our Chinook database:

```csharp
// Fetch Lookup Tables
var genres = client.Get(new QueryGenres()).Results.ToDictionary(x => x.Name);
var mediaTypes = client.Get(new QueryMediaTypes()).Results.ToDictionary(x => x.Name);

// Create new Artist, Album & Track
var newArtist = client.Post(new CreateArtists { Name = "PSY" });
var newAlbum = client.Post(new CreateAlbums {
    ArtistId = newArtist.Id.ToLong(),
    Title = "Psy 6 (Six Rules), Part 1",
});
client.Post(new CreateTracks {
    AlbumId = newAlbum.Id.ToLong(),
    Name = "Gangnam Style",
    Composer = "Park Jae-sang",
    Milliseconds = (long)new TimeSpan(0,3,39).TotalMilliseconds,
    GenreId = genres["Electronica/Dance"].GenreId,
    UnitPrice = 0.99m,
    MediaTypeId = mediaTypes["AAC audio file"].MediaTypeId,
    Bytes = 6683350,
});
```

We can then quickly view the results of any Service Response with built-in [Dump Utils](https://docs.servicestack.net/dump-utils):

```csharp
var track = client.Get(new QueryTracks {
    TrackId = newTrack.Id.ToLong(), 
});
track.PrintDump();
```

Which outputs:

    {
        offset: 0,
        total: 1,
        results: 
        [
            {
                trackId: 3504,
                name: Gangnam Style,
                albumId: 348,
                mediaTypeId: 5,
                genreId: 15,
                composer: Park Jae-sang,
                milliseconds: 219000,
                bytes: 6683350,
                unitPrice: 0.99
            }
        ]
    }

Viewing the same query in a browser:

https://localhost:5001/tracks?TrackId=3504

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/autoquery/chinook-crud-gangnam-style.png)

### Extending AutoQuery Services

Before our App is ready to ship, lets extend the existing AutoQuery Services by formalizing the implicit queries 
we used above into typed properties so they can be used by Typed clients as well:

```csharp
public class QueryArtists : QueryDb<Artists>, IGet
{
    public long? ArtistId { get; set; }
    public long[] ArtistIdBetween { get; set; }
    public string NameStartsWith { get; set; }
}

public class QueryTracks : QueryDb<Tracks>, IGet
{
    public long? TrackId { get; set; }
    public string NameContains { get; set; }
}
```

By adding typed properties for all the filters we want available to our API consumers, we make them discoverable & 
accessible to all [ServiceStack Reference languages](https://docs.servicestack.net/add-servicestack-reference)
who can consume them as normal. Here's the above implicit queries accessed from a Typed C# Client: 

```csharp
var response = client.Get(new QueryArtists {
    ArtistIdBetween = new long[]{ 1, 100 },
    NameStartsWith = "F",
});
response.PrintDump();

var response = client.Get(new QueryTracks {
    NameContains = "Heart",
    Skip = 5,
    Take = 10,
    Fields = "TrackId,Name,Milliseconds"
});
response.PrintDump();
```

## Deployments

Our enhanced AutoGen populated Chinook App is now ready to ship! Lets get it deployed with GitHub Actions & Mix:

### Include chinook.sqlite

To deploy the embedded `chinook.sqlite` with our App, set its File Properties to **Copy if newer**:

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/autoquery/chinook.sqlite-properties.png)

Or manually by adding the following to the `Chinook.csproj`.

```xml
<ItemGroup>
  <None Remove="chinook.sqlite" />
  <Content Include="chinook.sqlite">
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
  </Content>
</ItemGroup>
```

## Deploy to Digital Ocean droplet using GitHub Actions and SSH

Getting our application deployed, we can use GitHub Actions as our CI. There are `x mix` templates for GitHub Actions, we are going to use `release-ghr-vanilla` as it has minimal infrastructure without tying us to a specific cloud vendor. We'll use Digital Ocean in this case since they offer cheap **$5 /month** Droplets that we can host multiple small applications on.

<details>
  <summary>Create a new droplet</summary>
  
The basic droplet we are going to create will have the following configuration.

- Distribution - Ubuntu 20.04 LTS
- Plan - Basic
- $5 /month
- Data center region
- VPC - default
- Authentication - SSH keys, create a new one just for this server, follow the instructions on the right hand panel.

Leave the remaining options as default.

### Enable floating IP

Once your Droplet is started, you'll want to `Enable Floating IP` so that we have a static public IP address to route to for a domain/subdomain.

This can be done via 
- `Manage` 
- `Droplets`
- `Select your droplet`
- click `Enable Floating IP` at the top right.

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/mix/digital-ocean-enable-floating-ip.png)

</details>

<details>
  <summary>Setup Server Instance</summary>

Now that our Droplet is running and has a public static IP address, we'll want to setup Docker and docker-compose.

SSH into your Droplet using the appropriate SSH key and your preferred SSH client (straight `ssh`, Putty for Windows, etc).

Eg, with a Linux `ssh` client, the command would be `ssh root@<your_IP_or_domain>` as `root` is the default user setup when creating an Ubuntu droplet.

> Note: the user may change depending on your server setup, see `man ssh` for more info.

### Setup Docker

```bash
curl -fsSL https://get.docker.com -o get-docker.sh
sudo sh get-docker.sh
```

### Setup Docker Compose

```bash
sudo curl -L "https://github.com/docker/compose/releases/download/1.27.4/docker-compose-$(uname -s)-$(uname -m)" -o /usr/local/bin/docker-compose
sudo chmod +x /usr/local/bin/docker-compose
```
Run `docker-compose --version` to confirm.

### Setup nginx-proxy and letsencrypt companion

Now we have Docker and docker-compose installed on our new Droplet, we want to setup a nginx reverse proxy running in Docker. This will handle mapping a domain/subdomain requests to specific docker applications as well as TLS registration via LetEncrypt. When a new docker container starts up and joins the bridge network, the nginx and letsencrypt companion detect the new application and look to see if routing and TLS certificate is needed.

In the `x mix release-ghr-vanilla` template, we include `deploy/nginx-proxy-compose.yml` file which can be copied to the droplet and run.

You can use `scp` or just creating a new file via server text editor to copy the short YML file over. For this example, we are going to copy it straight to the `~/` (home) directory.

```
scp -i <path to private ssh key> ./nginx-proxy-compose.yml root@<floating-ip>:~/nginx-proxy-compose.yml
```

Once copied, we can use `docker-compose` to bring up the nginx reverse proxy.

```bash
docker-compose -f ~/nginx-proxy-compose.yml up -d
```

To confirm these are running, you can run `docker ps` so have a look at what containers are running on your server.
</details>

<details>
  <summary>Setup Domain</summary>

Now our droplet server is all setup to host our docker apps lets configure a domain name to point to our server. Specifically, we want to create an `A` record pointing to our Floating IP of our droplet using our preferred DNS provider, e.g. using Google Domains:

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/autoquery/chinook-google-domains.png)

</details>

## Mix in preferred GitHub Actions Deployment workflow

After the deployment server is configured, we can mix in the desired GitHub Actions to enable CI for our App 
that build and run its tests on every check-in and packages and deploys the App on each GitHub release.

We can easily do this on ServiceStack projects, in their root directory by mixing in the `build` and `release-ghr-vanilla` actions:

    $ x mix build release-ghr-vanilla

`build` adds the `build.yml` GitHub Action that **builds** our project and runs its **tests**.

`release-ghr-vanilla` adds the GitHub Actions below to use Docker to package the application, pushes the resulting Docker image to GitHub Container Registry 
([ghcr.io](https://ghcr.io/)) and deploys the application via SSH + `docker-compose` to our new Droplet:

- **.github/workflows/release.yml** - Release GitHub Action Workflow
- **deploy/docker-compose-template.yml** - Templated docker-compose file used by the application
- **deploy/nginx-proxy-compose.yml** - File provided to get nginx reserve proxy setup as used by steps above.

<details>
  <summary>Setup GitHub Repository</summary>

To integrate the GitHub Actions with our deployment environment we'll need enable improved container support and configure required deployment variables.

### Enable Enable improved container support

The account or organization of your repository at the time of writing needs to [Enable improved container support](https://docs.github.com/en/packages/guides/enabling-improved-container-support):

1. Goto `Account` > `Settings` > `Packages` > `Improved container support`
2. Select `Enable improved container support` and Save

### Create Deployment Secrets

The `release-ghr-vanilla` mix template needs 6 pieces of information to perform the deployment.

- `CR_PAT` - GitHub Personal Token with read/write access to packages
- `DEPLOY_HOST` - Hostname to SSH to, should be a domain or subdomain with `A` record pointing to server's IP
- `DEPLOY_PORT` - SSH port (default 22)
- `DEPLOY_USERNAME` - Login for SSH, E.g. `ubuntu`, `ec2-user`, `root`
- `DEPLOY_KEY` - SSH private key used to remotely access deploy server/app host
- `LETSENCRYPT_EMAIL` - Email address for LetsEncrypt TLS certificate generation

`CR_PAT` and `DEPLOY_KEY` should be treated as highly confidential, but for the rest, we used the following values.

Secrets can be added using the [GitHub CLI](https://cli.github.com) or GitHub UI to add [repository secrets](https://docs.github.com/en/actions/reference/encrypted-secrets#creating-encrypted-secrets-for-a-repository) used by the GitHub Actions, e.g:

    $ gh secret set DEPLOY_HOST       -b"chinook.netcore.io"
    $ gh secret set DEPLOY_PORT       -b"22"
    $ gh secret set DEPLOY_USERNAME   -b"root"
    $ gh secret set LETSENCRYPT_EMAIL -b"team@servicestack.net"

</details>

## Deploy Application

After everything is setup, we can deploy our application by creating a new GitHub Release with its new version tag:

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/autoquery/chinook-release.png)

The tag is used as the image version and GitHub Actions then runs the `release.yml` workflow to deploy the application.

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/autoquery/chinook-release-action.png)


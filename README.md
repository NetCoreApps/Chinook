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

Then Navigate to the `/metadata` page to view all AutoQuery APIs for each table in the Chinook DB:

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/autoquery/chinook-autogen-metadata.png)

Drilling down to a single API will show details about each API, including its Routes and the schema for Request, Response and all other DTOs used:

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/autoquery/chinook-autogen-createtracks.png)


## Deployments

### Publish database

When using `dotnet publish`, we want our application to copy the Sqlite database to the output so it can read it from the file system when deployed. You'll need to add the following to the `Chinook.csproj`.


```xml
  <ItemGroup>
    <None Remove="chinook.sqlite" />
    <Content Include="chinook.sqlite">
      <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </Content>
  </ItemGroup>
```

### Deployment to Digital Ocean via SSH and GitHub Actions

Getting our application deployed, we can use GitHub Actions as our CI. There are `x mix` templates for GitHub Actions, we are going to use `release-ghr-vanilla` as it has minimal infrastructure without tying us to a specific cloud vendor. We'll use Digital Ocean in this case since they offer cheap $5/month Droplets that we can host multiple small applications on.

### Create your new droplet
The basic droplet we are going to create will have the following configuration.

- Distribution - Ubuntu 20.04 LTS
- Plan - Basic
- $5/month
- Datacenter region - Which ever suits your use case
- VPC - default
- Authentication - SSH keys, create a new one just for this server, follow the instructions on the right hand panel.

The rest of the options, leave as default.

### Enable floating IP
Once your Droplet is started, you'll want to `Enable Floating IP` so that we have a static public IP address to route to for a domain/subdomain.

This can be done via `Manage` -> `Droplets` -> `Select your droplet` -> click `Enable Floating IP` at the top right.

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/mix/digital-ocean-enable-floating-ip.png)

## Docker setup
Now that our Droplet is running and has a public static IP address, we'll want to setup Docker and docker-compose.

SSH into your Droplet using the appropriate SSH key and your preferred SSH client (straight `ssh`, Putty for Windows, etc).

Eg, with a Linux `ssh` client, the command would be `ssh root@<your_IP_or_domain>` as `root` is the default user setup when creating an Ubuntu droplet.
> Note the user may change depending on how your server is setup. See `man ssh` for more details/options.

#### Docker via convenience script

```bash
curl -fsSL https://get.docker.com -o get-docker.sh
sudo sh get-docker.sh
```

### Docker-compose install
```bash
sudo curl -L "https://github.com/docker/compose/releases/download/1.27.4/docker-compose-$(uname -s)-$(uname -m)" -o /usr/local/bin/docker-compose
sudo chmod +x /usr/local/bin/docker-compose
```
Run `docker-compose --version` to confirm.

### Get nginx-proxy and letsencrypt companion app running
Now we have Docker and docker-compose installed on our new Droplet, we want to setup a nginx reverse proxy running in Docker. This will handle mapping a domain/subdomain requests to specific docker applications as well as TLS registration via LetEncrypt. When a new docker container starts up and joins the bridge network, the nginx and letsencrypt companion detect the new application and look to see if routing and TLS certificate is needed.

In the `x mix release-ghr-vanilla` template, we include `deploy/nginx-proxy-compose.yml` file which can be copied to the droplet and run.

You can use `scp` or just creating a new file via server text editor to copy the short YML file over. For this example, we are going to copy it straight to the `~/` (home) directory.

```
scp -i <path to private ssh key> ./nginx-proxy-compose.yml root@<server_floating_ip>:~/nginx-proxy-compose.yml
```

Once copied, we can use `docker-compose` to bring up the nginx reverse proxy.

```bash
docker-compose -f ~/nginx-proxy-compose.yml up -d
```

To confirm these are running, you can run `docker ps` so have a look at what containers are running on your server.

## Domain setup
Now our droplet server is all setup to host our docker apps, we want to make referring to our server easier via setting up some DNS records.

Specifically, we want to create an `A` record pointing to our Floating IP of our droplet.
> You'll need to use whichever service you use to manage the DNS of your domains.

## GitHub Repository Setup
Once this is created, we can navigate to the root directory of the project and use `x mix` to get started with our GitHub Actions.

```
x mix build release-ghr-vanilla
```

The `build` mix provides a GitHub Action that builds and tests our dotnet project. The `release-ghr-vanilla` provides a GitHub Action that uses Docker to package the application, pushes the Docker image to GitHub Container Registry (ghcr.io) and deploys the application via SSH + `docker-compose` to our new Droplet.

Files provided by the `release-ghr-vanilla` are:

- **.github/workflows/release.yml** - Release GitHub Action Workflow
- **deploy/docker-compose-template.yml** - Templated docker-compose file used by the application
- **deploy/nginx-proxy-compose.yml** - File provided to get nginx reserve proxy setup as used by steps above.

### Make sure GitHub `Enable improved container support` is turned on
The account or organization of your repository at the time of writing needs to "Enable improved container support". 

Goto `Account` -> `Settings` -> `Packages` -> `Improved container support` -> select `Enable improved container support` and save.
> See [GitHub Docs](https://docs.github.com/en/packages/guides/enabling-improved-container-support) for details. 

### Create secrets
The `x mix` templates needs 6 pieces of information to perform the deployment.

- CR_PAT - GitHub Personal Token with read/write access to packages.
- DEPLOY_HOST - hostname used to SSH to, this should be a domain or subdomain with A record pointing to the server's IP adddress.
- DEPLOY_PORT - SSH port, usually 22
- DEPLOY_USERNAME - the username being logged into via SSH. Eg, `ubuntu`, `ec2-user`, `root` etc.
- DEPLOY_KEY - SSH private key used to remotely access deploy server/app host.
- LETSENCRYPT_EMAIL - Email address for your TLS certificate generation

Both the `CR_PAT` and `DEPLOY_KEY` are highly sensitive and should be handled with care, but for the rest, we used the following values.

- DEPLOY_HOST - chinook.netcore.io
- DEPLOY_PORT - 22
- DEPLOY_USERNAME - root
- LETSENCRYPT_EMAIL - team@servicestack.net

### Create a GitHub Release
Now that everything is setup, we can deploy our application by creating a GitHub Release and specifying a tag. The tag is used as the image version and GitHub Actions then runs the `release.yml` workflow to deploy the application.


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

Navigate to the `/metadata` page to view all AutoQuery APIs for each table in the Chinook DB:

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/autoquery/chinook-autogen-metadata.png)

Navigating to an API will drill down to show more details about each API, including schemas for Request, Response and all other DTOs used, its Routes & Auth Info:

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/autoquery/chinook-autogen-createtracks.png)


## Deployments

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


<details>
  <summary>Setup GitHub Repository</summary>

After our server is configured, lets setup GitHub Actions to perform the deployments of our App which we can easily enable 
on ServiceStack projects using [x mix](https://docs.servicestack.net/mix-tool) to download pre-configured GitHub Actions.

In our project's root directory, we want to mix in both `build` and `release-ghr-vanilla` actions:

    $ x mix build release-ghr-vanilla

`build` adds the `build.yml` GitHub Action that **builds** our project and runs its **tests**.

`release-ghr-vanilla` adds the GitHub Actions below to use Docker to package the application, pushes the resulting Docker image to GitHub Container Registry (ghcr.io) and deploys the application via SSH + `docker-compose` to our new Droplet:

- **.github/workflows/release.yml** - Release GitHub Action Workflow
- **deploy/docker-compose-template.yml** - Templated docker-compose file used by the application
- **deploy/nginx-proxy-compose.yml** - File provided to get nginx reserve proxy setup as used by steps above.

### Enable Enable improved container support

The account or organization of your repository at the time of writing needs to [Enable improved container support](https://docs.github.com/en/packages/guides/enabling-improved-container-support):

1. Goto `Account` > `Settings` > `Packages` > `Improved container support`
2. Select `Enable improved container support` and Save

### Create Deployment Secrets

The `x mix` templates needs 6 pieces of information to perform the deployment.

- `CR_PAT` - GitHub Personal Token with read/write access to packages
- `DEPLOY_HOST` - Hostname to SSH to, should be a domain or subdomain with `A` record pointing to server's IP
- `DEPLOY_PORT` - SSH port (default 22)
- `DEPLOY_USERNAME` - Login for SSH, E.g. `ubuntu`, `ec2-user`, `root`
- `DEPLOY_KEY` - SSH private key used to remotely access deploy server/app host
- `LETSENCRYPT_EMAIL` - Email address for LetsEncrypt TLS certificate generation

`CR_PAT` and `DEPLOY_KEY` should be treated as highly confidential, but for the rest, we used the following values.

- `DEPLOY_HOST`: chinook.netcore.io
- `DEPLOY_PORT`: 22
- `DEPLOY_USERNAME`: root
- `LETSENCRYPT_EMAIL`: team@servicestack.net

</details>

## Deploy Application

After everything is setup, we can deploy our application by creating a new GitHub Release with its new version tag:

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/autoquery/chinook-release.png)

The tag is used as the image version and GitHub Actions then runs the `release.yml` workflow to deploy the application.

![](https://raw.githubusercontent.com/ServiceStack/docs/master/docs/images/autoquery/chinook-release-action.png)


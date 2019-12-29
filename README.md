# OdeToFood
A repo for the ASP.NET Core Pluralsight Project.

The following are additional notes and FAQs about the course. 

### ASP.NET Core 3

The original version of the code as recorded in the Pluralsight course is with ASP.NET Core 2.1. I've placed this code
into a branch named [aspnet21](https://github.com/OdeToCode/OdeToFood/tree/aspnet21).

The master branch I am updating to use ASP.NET Core 3 and the latest versions of Bootstrap and jQuery. 

## Module 2 (Drilling into Data)

### Clip 2 (Creating the New Project)

To create, build, and run a project like we do in Visual Studio, you can use the command line:

```text
dotnet new razor
dotnet build
dotnet run
```

Some environments, like Visual Studio Code, can also detect .NET Core projects and automatically add support to build and run from the VS Code menus. 

### Clip 3 (Editing Razor Pages)

VS uses some magic to automatically restart the web server when you make changes to source code files. If you are using command line tools, you can do the same using:

`dotnet watch run`

... instead of ...

`dotnet run`

### Clip 7 - (Creating an Entity)

You can use `dotnet` to create the class library. Place this at the same folder level as the OdeToFood project. 

```
dotnet new classlib
```

## Module 3 (Working with Models and Model Binding)

### Clip 3 (Building a Search Form)

Bootstrap 4 changed some classes and no longer includes glyphicons. [Font Awesome](https://fontawesome.com/start) is a good replacement. Once you've included the Font Awesome stylesheet into your _Layout page with a link tag, the icons are just as easy to use. To show a search icon use this code:

```
<input type="search" class="form-control" value="" />
<div class="input-group-append">
    <button class="btn btn-secondary">
        <i class="fas fa-search"></i>
    </button>
</div>
```

## Module 4 (Editing Data with Razor Pages)

Note that Bootstrap version 4 no longer provides icons out of the box. See the [docs](https://getbootstrap.com/docs/4.0/extend/icons/) for more info. [Font Awesome](https://fontawesome.com/start) is a good replacement.

### Clip 5 (Adding Validation Checks)

You'll need to install the NuGet package [dotnet-aspnet-codegenerator](https://www.nuget.org/packages/dotnet-aspnet-codegenerator/). Install this package as a tool From the comamnd line, and also install the design package for the project:

```text
dotnet tool install --global dotnet-aspnet-codegenerator 
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
```

After installing, the following command should display a help screen and a list of available generators. Make sure you execute the command inside a directory where a project exists.

```text
dotnet aspnet-codegenerator -h
```

Now you should be able to follow along with the scaffolding in the video.

```text
dotnet aspnet-codegenerator razorpage List Empty -udl -outDir Pages\Restaurants\
```

For Visual Studio users, you might also want a reference to CodeGeneration tools you can use from the UI. Run the following command in the project directory:

```text
dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
dotnet restore
```

This will allow you to right-click the project and run scaffolding. s

## Module 5 (Working with SQL Server and the Entity Framework Core)

### Clip 2 (Installing the Entity Framework)

See [Install SQL Server on a Mac](https://www.quackit.com/sql_server/mac/install_sql_server_on_a_mac.cfm) if you are moving through the course using Visual Studio for the MAC. From user [db](https://disqus.com/home/discussion/pluralsight-1/aspnet_core_fundamentals/#comment-4637096653): 

> Once installed, take a note of your database user name (usually 'sa') and password.
>
> It is very smooth. I am using DBBeaver which is also explained in the article above and I find it great.
>
>Following Scott's class here, where he sets database connection string in `appsettings.json` to his local DB instance in Windows, you can just use this connection string:

``` json
"ConnectionStrings": {
    "OdeToFoodDb":"Server=localhost,1433;Database=OdeToFood;User Id=sa; Password=your-password"
}
```

>, then replace 'your-password' with your real password you choose when installing the SQL server image in docker container.
>
>It is very simple and smooth experience.

### Clip 4 (Using the Entity Framework Tools)

Starting in 3.0, the dotnet ef command-line tool is no longer included in the .NET Core SDK. Before you can execute EF Core migration or scaffolding commands, you’ll have to install this package as either a global or local tool. To install the latest version as a global tool, use the following command:

```
dotnet tool install --global dotnet-ef
```

## Module 7 (Integrating Client-side JavaScript and CSS)

### Implementing an API Controller

If you aren't using Visual Studio, the scaffolding shown in this clip is something you can also achieve with the `dotnet-aspnet-codegenerator` tool discussed in module 3. The command would look like:

```
dotnet aspnet-codegenerator controller -api -name RestaurantsController
    --model OdeToFood.Core.Restaurant --dataContext OdeToFood.Data.OdeToFoodDbContext 
```
Note the `-api` switch uses a single dash. 

### Changes to routing and services

In ASP.NET Core 3.0+, you can bring in fine grained services to support Razor pages and controllers. You don't need to bring in the entire MVC framework. To use Razor pages and API controllers, for example, you'd need to have the following two method calls inside the `ConfigureServices` method of `Startup.cs`. 

```
// for aspnetcore3.0+

services.AddRazorPages();
services.AddControllers();
```

Routing is also a bit different, and more granular in 3.0. You'll need to the following code at the bottom of the `Configure` method in `Startup.cs` for 3.x:

```
app.UseRouting();            
app.UseEndpoints(e =>
{
    e.MapRazorPages();
    e.MapControllers();
});
```

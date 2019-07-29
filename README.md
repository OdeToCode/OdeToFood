# OdeToFood
A repo for the ASP.NET Core Pluralsight Project.

The following are additional notes and FAQs about the course. 

## Module 1

### Clip 2 - Creating the Project

To create, build, and run a project like we do in Visual Studio, you can use the command line:

```text
dotnet new razor
dotnet build
dotnet run
```

Some environments, like Visual Studio Code, can also detect .NET Core projects and automatically add support to build and run from the VS Code menus. 

### Clip 3 - Saving changes and refreshing

VS uses some magic to automatically restart the web server when you make changes to source code files. If you are using command line tools, you can do the same using:

`dotnet watch run`

... instead of ...

`dotnet run`

### Clip 7 - Adding the OdeToFood.Core project

You can use `dotnet` to create the class library. Place this at the same folder level as the OdeToFood project. 

```
dotnet new classlib
```

## Module 2

### Clip 3 

Bootstrap 4 does not include glyphicons. [Font Awesome](https://fontawesome.com/start) is a good replacement. Once you've included the Font Awesome stylesheet into your _Layout page with a link tag, the icons are just as easy to use. To show a search icon, for example:

&lt;i class="fas fa-search"&gt;&lt;/i&gt;

## Module 3

Note that Bootstrap version 4 no longer provides icons out of the box. See the [docs](https://getbootstrap.com/docs/4.0/extend/icons/) for more info. 

### Clip 5

You'll need to install the NuGet package [dotnet-aspnet-codegenerator](https://www.nuget.org/packages/dotnet-aspnet-codegenerator/). From the comamnd line:

```text
dotnet tool install --global dotnet-aspnet-codegenerator 
```

After installing, the following command should display a help screen and a list of avaialble generators. Make sure you execute the command inside a directory where a project exists.

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

## Module 4

### Clip 2 

Alternatives to MSSQL 





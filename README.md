# Angular Form Builder

Create your form dynamically and share your form to people

[![Deploy to Azure](http://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/?repository=https://github.com/peacecwz/angular-form-builder)


## Getting Started

First of all, you need to clone the project to your local machine

```
git clone https://github.com/peacecwz/angular-form-builder.git
cd angular-form-builder
```

### Building

A step by step series of building that project

1. Restore the project :hammer:

```
dotnet restore
```

2. Change connection string of Database (Project: FormBuilder.API, File: appsettings.Development.json, Line: 3)

3. (Optinal) If you want to use change Database Provider to MS SQL, MySQL etc... You can change on FormBuilder.Repository/Extensions/DIExtensions.cs File (Line: 28)

```
    //For Microsoft SQL Server
    services.AddDbContext<FormBuilderDbContext>(options =>
            {
                options.UseNpgsql(connectionString,
                    builder => builder.MigrationsAssembly("FormBuilder.API"));
            });
```

3.1 Delete Migrations Folder

3.2 Create New Migrations for SQL Server or another DB Providers
```
dotnet ef migrations add InitDb
```

4. Run EF Core Migrations

```
dotnet ef database update
```

5. Change Client Url and API Url in Client App (Project: FormBuilder.Web, File: wwwroot/js/demo.js, Line 2-3)
```
var baseUrl = 'http://localhost:51468/';
var baseApiUrl = 'http://localhost:50730/api/v1';
```

6. Run the project and Enjoy! :bomb:

```
dotnet run
```
## Demo

You can try it on [Angular App](https://angular-form-builder.azurewebsites.net/#!/create) :gun:


## Built With

* [.NET Core 2.0](https://www.microsoft.com/net/) 
* [Entitiy Framework Core](https://docs.microsoft.com/en-us/ef/core/) - .NET ORM Tool
* [NpgSQL for EF Core](http://www.npgsql.org/efcore/) - PostgreSQL extension for EF 
* [Angular 1.6](https://angularjs.org/) - Web Client Javascript Library

## Contributing

* If you want to contribute to codes, create pull request
* If you find any bugs or error, create an issue


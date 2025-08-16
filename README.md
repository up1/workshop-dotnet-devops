# Workshop with .NET 9
* Frontend
* Backend
* Database


## 1. Create solution and projects
```
$dotnet new sln --name DemoSolution

# WebUI with MVC
$dotnet new mvc -n web
$dotnet sln add web

# WebAPI
$dotnet new webapi -n api
$dotnet sln add api
```

Build and Publish
```
$dotnet restore
$dotnet publish
```

# Workshop with .NET 9
* Frontend
* Backend
* Database
* NGINX as web server


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

Run web
```
$dotnet run --project web
```

Run API
```
$dotnet run --project api
```

## 2. Working with Docker

API
```
$docker compose build api
$docker compose up -d api
$docker compose ps
```

Web
```
$docker compose build web
$docker compose up -d web
$docker compose ps
```

## 3. Workshop
* Create a docker-compose.yml
* Working with NGINX as web server
* Manage [Cross-Origin Resource Sharing (CORS)](https://developer.mozilla.org/en-US/docs/Web/HTTP/Guides/CORS)

# dot-net-core-api

This repo will explore setting up a RESFful API using .NET core and Visual Studio Code. This might form a follow up to my previous article of writing C# using Visual Studio Code.

The 'Domain' for this project will be a climbing route database.

It is intended that this project will be kept up to date with the latest microsoft tooling.

This should be a reasonable go-by for using Entity Framework, and interacting with the database using an API. I am aiming for 'best practices' in all areas with this. Please feel free to get in touch where I inevitably deviate from this ideal!


Set Up

1. Install .net core (current version is 3.0.100-preview8-013656)
0. Install the CLI tools with `dotnet tool install --global dotnet-ef --version 3.0.0-*`
0. Create a solution and add a project, as per my previous article.
0. Install the design package with `dotnet add package Microsoft.EntityFrameworkCore.Design`
0. `dotnet add package Microsoft.EntityFrameworkCore.SqlServer`
0. `dotnet-ef migrations add CreateClimbingRoutesDB`
0. `dotnet-ef database update`






cd (mkdir dot-net-core-api.console-app);
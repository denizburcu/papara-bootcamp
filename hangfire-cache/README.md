### This is a demonstration of Hangfire Background Job running every 5 seconds and in memory Cache in ASP.Net.

You need .Net 6.0.x or higher SDK and docker.

Run Sql Server

```bash 
docker run -e "SA_PASSWORD=MyPassword" -e "MSSQL_PID=Express" -p 1433:1433 -d --name=sql mcr.microsoft.com/mssql/server:latest 

```

Run project

```bash
dotnet watch run 

```

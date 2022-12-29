 # Papara .Net Core Bootcamp
  .NET bootcamp assignments organized by Patika with the sponsorship of Papara.
  
You need .Net 6.0.x or higher SDK and docker.

Run Sql Server

```bash 
docker run -e "SA_PASSWORD=MyPassword" -e "MSSQL_PID=Express" -p 1433:1433 -d --name=sql mcr.microsoft.com/mssql/server:latest 

```

Run project

```bash
dotnet watch run 

```


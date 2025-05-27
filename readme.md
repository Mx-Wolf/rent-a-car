# Demo for Domain Design

Remember to upgrade EF tools

```terminal
dotnet tool update --global dotnet-ef
```

To run migrations:

```terminal
dotnet ef migrations add <<name>> --context MemoryDbContext --project ./src/Esx.Integration --startup-project ./src/Esx.Host --configuration Debug
```

Application on the run does not applies migrations. To apply migrations:

```terminal
dotnet ef database update --context MemoryDbContext --project ./src/Esx.Integration --startup-project ./src/Esx.Host --configuration Debug
```
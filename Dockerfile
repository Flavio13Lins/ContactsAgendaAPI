# Use a base image for your .NET 8 application (adjust as needed)
FROM mcr.microsoft.com/dotnet:8.0-aspnetcore-runtime AS base

WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/aspnetcore:8.0 AS runtime
WORKDIR /src
COPY . .
RUN dotnet restore "MyAgendaAPI.csproj"
RUN dotnet build "MyAgendaAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyAgendaAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyAgendaAPI.dll"]

ARG BUILD_CONFIGURATION=Release
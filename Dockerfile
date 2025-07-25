FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
WORKDIR "/src"
RUN dotnet restore Bank/Bank.sln
RUN dotnet build Bank/Bank.sln -o /app/build

FROM build AS publish
RUN dotnet publish Bank/Bank.WebApi/Bank.WebApi.csproj -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bank.WebApi.dll"]
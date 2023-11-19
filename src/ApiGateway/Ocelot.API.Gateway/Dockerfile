FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src

COPY Ocelot.API.Gateway.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app

COPY --from=build /app .

ENTRYPOINT ["dotnet", "Ocelot.API.Gateway.dll"]

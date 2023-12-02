FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src

COPY Payment.API.csproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app

COPY --from=build /app .

ENTRYPOINT ["dotnet", "Payment.API.dll"]

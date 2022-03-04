#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["GringottsBank.API/GringottsBank.API.csproj", "GringottsBank.API/"]
COPY ["GringottsBank.Services/GringottsBank.Services.csproj", "GringottsBank.Services/"]
COPY ["GringottsBank.Models/GringottsBank.Entities.csproj", "GringottsBank.Models/"]
COPY ["GringottsBank.Core.Entities/GringottsBank.Core.Entities.csproj", "GringottsBank.Core.Entities/"]
COPY ["GringottsBank.DataAccess/GringottsBank.DataAccess.csproj", "GringottsBank.DataAccess/"]
COPY ["GringottsBank.Extensions/GringottsBank.Extensions.csproj", "GringottsBank.Extensions/"]
RUN dotnet restore "GringottsBank.API/GringottsBank.API.csproj"
COPY . .
WORKDIR "/src/GringottsBank.API"
RUN dotnet build "GringottsBank.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GringottsBank.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GringottsBank.API.dll"]
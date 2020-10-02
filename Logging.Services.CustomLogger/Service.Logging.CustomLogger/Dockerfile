#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DCS.Service.Logging.csproj", "DCS.Service.Logging/"]
COPY ["nuget.config", "DCS.Service.Logging/"]
RUN dotnet restore "DCS.Service.Logging/DCS.Service.Logging.csproj" --configfile DCS.Service.Logging/nuget.config
COPY . .
WORKDIR "/src/DCS.Service.Logging"
RUN dotnet build "DCS.Service.Logging.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DCS.Service.Logging.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DCS.Service.Logging.dll"]
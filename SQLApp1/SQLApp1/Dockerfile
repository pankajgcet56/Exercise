﻿FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SQLApp1/SQLApp1.csproj", "SQLApp1/"]
RUN dotnet restore "SQLApp1/SQLApp1.csproj"
COPY . .
WORKDIR "/src/SQLApp1"
RUN dotnet build "SQLApp1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SQLApp1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SQLApp1.dll"]

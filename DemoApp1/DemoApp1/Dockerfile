FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DemoApp1/DemoApp1.csproj", "DemoApp1/"]
RUN dotnet restore "DemoApp1/DemoApp1.csproj"
COPY . .
WORKDIR "/src/DemoApp1"
RUN dotnet build "DemoApp1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DemoApp1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DemoApp1.dll"]

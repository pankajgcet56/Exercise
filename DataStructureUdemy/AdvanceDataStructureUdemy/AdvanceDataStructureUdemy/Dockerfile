FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AdvanceDataStructureUdemy/AdvanceDataStructureUdemy.csproj", "AdvanceDataStructureUdemy/"]
RUN dotnet restore "AdvanceDataStructureUdemy/AdvanceDataStructureUdemy.csproj"
COPY . .
WORKDIR "/src/AdvanceDataStructureUdemy"
RUN dotnet build "AdvanceDataStructureUdemy.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdvanceDataStructureUdemy.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdvanceDataStructureUdemy.dll"]

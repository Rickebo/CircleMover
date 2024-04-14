FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["CircleMover/CircleMover.csproj", "CircleMover/"]
RUN dotnet restore "CircleMover/CircleMover.csproj"
COPY . .
WORKDIR "/src/CircleMover"
RUN dotnet build "CircleMover.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CircleMover.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CircleMover.dll"]

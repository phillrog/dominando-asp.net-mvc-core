FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/UI.Site/UI.Site.csproj", "src/UI.Site/"]
RUN dotnet restore "src/UI.Site/UI.Site.csproj"
COPY . .
WORKDIR "/src/src/UI.Site"
RUN dotnet build "UI.Site.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UI.Site.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UI.Site.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ipmanager.api/ipmanager.api.csproj", "ipmanager.api/"]
RUN dotnet restore "ipmanager.api/ipmanager.api.csproj"
COPY . .
WORKDIR "/src/ipmanager.api"

# Run tests
RUN find . -name *.sln -print0 | xargs -r -n 1 -0 dotnet test

RUN dotnet build "ipmanager.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ipmanager.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ipmanager.api.dll"]

## to build and publish image on docker
##docker build -t ipmanager .
##docker run -d -p 8080:80 -e "RapidAPIKey=xxxxxxxxxxxxxxxxxxxxxxxxxxxxx" --name meli_app ipmanager
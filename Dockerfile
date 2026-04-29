FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["GithubActionsAula.slnx", "./"]
COPY ["src/GithubActionsAula.Api/GithubActionsAula.Api.csproj", "src/GithubActionsAula.Api/"]

RUN dotnet restore "src/GithubActionsAula.Api/GithubActionsAula.Api.csproj"

COPY . .

RUN dotnet publish "src/GithubActionsAula.Api/GithubActionsAula.Api.csproj" \
	--configuration Release \
	--output /app/publish

FROM base AS final
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "GithubActionsAula.Api.dll"]
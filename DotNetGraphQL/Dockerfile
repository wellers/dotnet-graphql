FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /source

# Copy csproj and restore as distinct layers
COPY DotNetGraphQL.csproj ./DotNetGraphQL/DotNetGraphQL.csproj
RUN cd DotNetGraphQL && dotnet restore

# Copy everything else and build app
COPY . ./DotNetGraphQL/
WORKDIR /source/DotNetGraphQL
RUN dotnet publish -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app ./
ENTRYPOINT ["dotnet", "DotNetGraphQL.dll"]
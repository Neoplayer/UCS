FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UCS.WebApi/UCS.WebApi.csproj", "UCS.WebApi/"]
COPY ["UCS.DbProvider/UCS.DbProvider.csproj", "UCS.DbProvider/"]
RUN dotnet restore "UCS.WebApi/UCS.WebApi.csproj"
COPY . .
WORKDIR "/src/UCS.WebApi"
RUN dotnet build "UCS.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UCS.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UCS.WebApi.dll"]

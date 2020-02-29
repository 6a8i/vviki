FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Cheetos.vviki.WebAPI/Cheetos.vviki.WebAPI.csproj", "Cheetos.vviki.WebAPI/"]
RUN dotnet restore "Cheetos.vviki.WebAPI/Cheetos.vviki.WebAPI.csproj"
COPY . .
WORKDIR "/src/Cheetos.vviki.WebAPI"
RUN dotnet build "Cheetos.vviki.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cheetos.vviki.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cheetos.vviki.WebAPI.dll"]

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["xxxx.vviki.WebAPI/xxxx.vviki.WebAPI.csproj", "xxxx.vviki.WebAPI/"]
RUN dotnet restore "xxxx.vviki.WebAPI/xxxx.vviki.WebAPI.csproj"
COPY . .
WORKDIR "/src/xxxx.vviki.WebAPI"
RUN dotnet build "xxxx.vviki.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "xxxx.vviki.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "xxxx.vviki.WebAPI.dll"]
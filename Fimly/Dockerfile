FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Fimly/Fimly.csproj", "Fimly/"]
RUN dotnet restore "Fimly/Fimly.csproj"
COPY . .
WORKDIR "/src/Fimly"
RUN dotnet build "Fimly.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Fimly.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Fimly.dll"]
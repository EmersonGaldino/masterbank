FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["master.bank.api/master.bank.api.csproj", "master.bank.api/"]
COPY ["master.bank.utils/master.bank.utils.csproj", "master.bank.utils/"]
COPY ["master.bank.domain.core/master.bank.domain.core.csproj", "master.bank.domain.core/"]
COPY ["master.bank.infraestructure.persistence/master.bank.infraestructure.persistence.csproj", "master.bank.infraestructure.persistence/"]
COPY ["master.bank.infraestructure.crosscutting/master.bank.infraestructure.crosscutting.csproj", "master.bank.infraestructure.crosscutting/"]
COPY ["master.bank.bootstrapper/master.bank.bootstrapper.csproj", "master.bank.bootstrapper/"]
RUN dotnet restore "master.bank.api/master.bank.api.csproj"
COPY . .
WORKDIR "/src/master.bank.api"
RUN dotnet build "master.bank.api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "master.bank.api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "master.bank.api.dll"]

#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5050

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RatıngService.Api/RatingService.Api.csproj", "RatıngService.Api/"]
COPY ["RatingService.Bll/RatingService.Bll.csproj", "RatingService.Bll/"]
COPY ["RatingService.Dal/RatingService.Dal.csproj", "RatingService.Dal/"]
COPY ["RatingService.Entities/RatingService.Entities.csproj", "RatingService.Entities/"]
COPY ["RatingService.Dtos/RatingService.Dtos.csproj", "RatingService.Dtos/"]
RUN dotnet restore "./RatıngService.Api/RatingService.Api.csproj"
COPY . .
WORKDIR "/src/RatıngService.Api"
RUN dotnet build "./RatingService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RatingService.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RatingService.Api.dll"]
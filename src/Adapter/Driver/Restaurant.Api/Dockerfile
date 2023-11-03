#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Adapter/Driver/Restaurant.Api/Restaurant.Api.csproj", "src/Adapter/Driver/Restaurant.Api/"]
COPY ["src/Adapter/Driven/Infra/Infra.csproj", "src/Adapter/Driven/Infra/"]
COPY ["src/Core/Application/Application.csproj", "src/Core/Application/"]
COPY ["src/Core/Domain/Domain.csproj", "src/Core/Domain/"]
RUN dotnet restore "src/Adapter/Driver/Restaurant.Api/Restaurant.Api.csproj"
COPY . .
WORKDIR "/src/src/Adapter/Driver/Restaurant.Api"
RUN dotnet build "Restaurant.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Restaurant.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Restaurant.Api.dll"]
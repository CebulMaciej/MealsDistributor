FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["MealsDistributor/MealsDistributor.csproj", "MealsDistributor/"]
RUN dotnet restore "MealsDistributor/MealsDistributor.csproj"
COPY . .
WORKDIR "/src/MealsDistributor"
RUN dotnet build "MealsDistributor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MealsDistributor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MealsDistributor.dll"]
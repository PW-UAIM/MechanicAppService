#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["majumi.CarService.MechanicsAppService.Rest/majumi.CarService.MechanicsAppService.Rest.csproj", "majumi.CarService.MechanicsAppService.Rest/"]
RUN dotnet restore "majumi.CarService.MechanicsAppService.Rest/majumi.CarService.MechanicsAppService.Rest.csproj"
COPY . .
WORKDIR "/src/majumi.CarService.MechanicsAppService.Rest"
RUN dotnet build "majumi.CarService.MechanicsAppService.Rest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "majumi.CarService.MechanicsAppService.Rest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "majumi.CarService.MechanicsAppService.Rest.dll"]
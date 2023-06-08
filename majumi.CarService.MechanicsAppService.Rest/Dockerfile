#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5011

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["majumi.CarService.MechanicsAppService.Model/majumi.CarService.MechanicsAppService.Model.csproj", "majumi.CarService.ClientsAppService.Model/"]
COPY ["majumi.CarService.MechanicsAppService.Rest/majumi.CarService.MechanicsAppService.Rest.csproj", "majumi.CarService.ClientsAppService.Rest/"]
COPY ["majumi.CarService.MechanicsAppService.Rest.Model/majumi.CarService.MechanicsAppService.Rest.Model.csproj", "majumi.CarService.ClientsAppService.Rest.Model/"]
COPY ["majumi.CarService.MechanicsAppService.Rest.Tests/majumi.CarService.MechanicsAppService.Rest.Tests.csproj", "majumi.CarService.ClientsAppService.Rest.Tests/"]
RUN dotnet restore "majumi.CarService.MechanicsAppService.Rest/majumi.CarService.MechanicsAppService.Rest.csproj"
COPY . .
WORKDIR "/src/majumi.CarService.MechanicsAppService.Rest"
RUN dotnet build "majumi.CarService.MechanicsAppService.Rest.csproj" -c Production -o /app/build

FROM build AS publish
RUN dotnet publish "majumi.CarService.ClientsAppService.Rest.csproj" -c Production -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "majumi.CarService.MechanicsAppService.Rest.dll"]
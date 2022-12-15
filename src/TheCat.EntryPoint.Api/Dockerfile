#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TheCat.EntryPoint.Api/TheCat.EntryPoint.Api.csproj", "src/TheCat.EntryPoint.Api/"]
COPY ["src/TheCat.Application/TheCat.Application.csproj", "src/TheCat.Application/"]
COPY ["src/TheCat.Domain/TheCat.Domain.csproj", "src/TheCat.Domain/"]
COPY ["src/TheCat.Infra.CrossCutting.Ioc/TheCat.Infra.CrossCutting.Ioc.csproj", "src/TheCat.Infra.CrossCutting.Ioc/"]
COPY ["src/TheCat.Infra.Data/TheCat.Infra.Data.csproj", "src/TheCat.Infra.Data/"]
RUN dotnet restore "src/TheCat.EntryPoint.Api/TheCat.EntryPoint.Api.csproj"
COPY . .
WORKDIR "/src/src/TheCat.EntryPoint.Api"
RUN dotnet build "TheCat.EntryPoint.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TheCat.EntryPoint.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TheCat.EntryPoint.Api.dll"]
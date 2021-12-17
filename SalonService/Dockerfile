#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["SalonService/SalonService.csproj", "SalonService/"]
COPY ["Models/Exceptions/Exceptions.csproj", "Models/Exceptions/"]
COPY ["Business/Services/Services.csproj", "Business/Services/"]
COPY ["Models/MySalonModels/MySalonModels.csproj", "Models/MySalonModels/"]
COPY ["DataAccess/DAL/DAL.csproj", "DataAccess/DAL/"]
RUN dotnet restore "SalonService/SalonService.csproj"
COPY . .
WORKDIR "/src/SalonService"
RUN dotnet build "SalonService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SalonService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SalonService.dll"]
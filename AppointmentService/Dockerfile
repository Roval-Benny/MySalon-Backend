#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["AppointmentService/AppointmentService.csproj", "AppointmentService/"]
RUN dotnet restore "AppointmentService/AppointmentService.csproj"
COPY . .
WORKDIR "/src/AppointmentService"
RUN dotnet build "AppointmentService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AppointmentService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AppointmentService.dll"]
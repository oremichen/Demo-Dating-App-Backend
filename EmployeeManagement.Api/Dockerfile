#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["EmployeeManagement.Api/EmployeeManagement.Api.csproj", "EmployeeManagement.Api/"]
COPY ["EmployeeManagement.Repository/EmployeeManagement.Repository.csproj", "EmployeeManagement.Repository/"]
COPY ["EmployeeManagement.Core/EmployeeManagement.Core.csproj", "EmployeeManagement.Core/"]
COPY ["EmployeeManagement.AppService/EmployeeManagement.AppService.csproj", "EmployeeManagement.AppService/"]
RUN dotnet restore "EmployeeManagement.Api/EmployeeManagement.Api.csproj"
COPY . .
WORKDIR "/src/EmployeeManagement.Api"
RUN dotnet build "EmployeeManagement.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmployeeManagement.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmployeeManagement.Api.dll"]
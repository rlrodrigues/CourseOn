#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CourseOn.API/CourseOn.API.csproj", "src/CourseOn.API/"]
COPY ["src/CourseOn.Domain/CourseOn.Domain.csproj", "src/CourseOn.Domain/"]
RUN dotnet restore "src/CourseOn.API/CourseOn.API.csproj"
COPY . .
WORKDIR "/src/src/CourseOn.API"
RUN dotnet build "CourseOn.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CourseOn.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CourseOn.API.dll"]
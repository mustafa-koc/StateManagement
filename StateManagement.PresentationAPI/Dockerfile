#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["StateManagement.PresentationAPI/StateManagement.PresentationAPI.csproj", "StateManagement.PresentationAPI/"]
RUN dotnet restore "StateManagement.PresentationAPI/StateManagement.PresentationAPI.csproj"
COPY . .
WORKDIR "/src/StateManagement.PresentationAPI"
RUN dotnet build "StateManagement.PresentationAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StateManagement.PresentationAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StateManagement.PresentationAPI.dll"]
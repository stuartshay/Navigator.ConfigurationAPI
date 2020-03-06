FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Navigator.ConfigurationAPI.csproj", ""]
RUN dotnet restore "./Navigator.ConfigurationAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "Navigator.ConfigurationAPI.csproj" -c Release -o /app/build



FROM build AS publish
RUN dotnet publish "Navigator.ConfigurationAPI.csproj" -c Release -o /app/publish


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .


ENTRYPOINT ["dotnet", "Navigator.ConfigurationAPI.dll"]
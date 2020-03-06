FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base

ARG BUILD_NUMBER=0
ENV BUILD_NUMBER ${BUILD_NUMBER}

COPY src /app/src
COPY Navigator.ConfigurationAPI.sln /app/Navigator.ConfigurationAPI.sln


FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /app/src/Navigator.ConfigurationAPI



#COPY ["Navigator.ConfigurationAPI.csproj", ""]
#RUN dotnet restore "./Navigator.ConfigurationAPI.csproj"
#COPY . .
#WORKDIR "/src/."
#RUN dotnet build "Navigator.ConfigurationAPI.csproj" -c Release -o /app/build





#FROM build AS publish
#RUN dotnet publish "Navigator.ConfigurationAPI.csproj" -c Release -o /app/publish


#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .


EXPOSE 80
EXPOSE 443

#ENTRYPOINT ["dotnet", "Navigator.ConfigurationAPI.dll"]
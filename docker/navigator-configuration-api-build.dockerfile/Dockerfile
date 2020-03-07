FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

ARG BUILD_NUMBER=0
ENV BUILD_NUMBER ${BUILD_NUMBER}

RUN apt-get update && apt-get install -y --no-install-recommends \
    tree \
 && rm -rf /var/lib/apt/lists/*

COPY /src  /src

WORKDIR /src/Navigator.ConfigurationAPI
RUN dotnet publish -c Release -o /publish 


# Relase 
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim 

WORKDIR /publish
COPY --from=build-env /publish .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "Navigator.ConfigurationAPI.dll"]
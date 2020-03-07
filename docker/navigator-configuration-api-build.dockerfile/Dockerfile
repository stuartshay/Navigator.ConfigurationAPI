FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build-env

ARG BUILD_NUMBER=0
ENV BUILD_NUMBER ${BUILD_NUMBER}

COPY src /app/src
COPY Navigator.ConfigurationAPI.sln /app/Navigator.ConfigurationAPI.sln

WORKDIR /app/src/Navigator.ConfigurationAPI
RUN dotnet publish -c Release -o /publish 


FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim 

WORKDIR /publish
COPY --from=build-env /publish .




#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS publish
#WORKDIR /app/src/Navigator.ConfigurationAPI
#RUN dotnet publish -c Release -o /publish 


#FROM base AS final
#WORKDIR /app
#COPY --from=build-env /publish .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "Navigator.ConfigurationAPI.dll"]
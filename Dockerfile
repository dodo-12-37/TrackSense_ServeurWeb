FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

#RUN apt-get update
#RUN apt-get install -y npm

# Copy everything
COPY ./TrackSense ./

RUN dotnet restore TrackSense.API/TrackSense.API.csproj
RUN dotnet build TrackSense.API/TrackSense.API.csproj -c Release

RUN mkdir -p App/Artefacts
RUN dotnet publish TrackSense.API/TrackSense.API.csproj -c Release -o /App/Artefacts

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App/Artefacts
COPY --from=build-env /App/Artefacts .
ENTRYPOINT ["dotnet", "TrackSense.API.dll"]
EXPOSE 80 443
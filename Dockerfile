FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

ENV PATH="${PATH}:/root/.dotnet/tools"
RUN dotnet tool install --global dotnet-ef

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore
COPY . ./
RUN dotnet publish -c Release -o out
RUN dotnet test
RUN dotnet ef database update

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 8010:80
COPY --from=build-env /app/out .

VOLUME data
COPY --from=build-env /app/contacts.db /data/

ENV ASPNETCORE_ENVIRONMENT Production
ENTRYPOINT ["dotnet", "ContactsBackendDotnet.dll"]
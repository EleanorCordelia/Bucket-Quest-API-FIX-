FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
EXPOSE 8080
COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .
ENV GOOGLE_APPLICATION_CREDENTIALS /app/key.json
ENTRYPOINT ["dotnet", "BucketQuestAPI.dll", "--environment=Development"]
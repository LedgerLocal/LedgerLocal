FROM microsoft/dotnet:2.0-sdk AS build-env
WORKDIR /app

# copy
COPY . ./

# copy everything else and build

WORKDIR /app/LedgerLocal.Scheduler.Console

RUN dotnet restore
RUN dotnet publish -c Release -o out -r linux-x64

# build runtime image
FROM microsoft/dotnet:2.0-runtime 
WORKDIR /app
COPY --from=build-env /app/LedgerLocal.Scheduler.Console/out ./
ENTRYPOINT ["dotnet", "LedgerLocal.Scheduler.Console.dll"]
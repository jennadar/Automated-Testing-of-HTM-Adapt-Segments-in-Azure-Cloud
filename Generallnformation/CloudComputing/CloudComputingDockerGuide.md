### Setup
https://docs.docker.com/docker-for-windows/


### How to create the docker file without VS?

Create the dockerfile in the root of your project:

~~~

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ConsoleApp1/ConsoleApp1.csproj", "ConsoleApp1/"]
RUN dotnet restore "ConsoleApp1/ConsoleApp1.csproj"
COPY . .
WORKDIR "/src/ConsoleApp1"
RUN dotnet build "ConsoleApp1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ConsoleApp1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ConsoleApp1.dll"]


~~~

### Architect Modern Apps in Azure with Docker
https://docs.microsoft.com/en-us/learn/paths/architect-modern-apps/

###Host Docker in Web App
1. Go to Azure Portal.
2. Click Create resource
3. Select "Web App"

4. 'Basic'-Tab
4.1 Select or create a resource group.
4.2 Enter an unique name for your Web App
4.3 Under 'publish' select 'docker'
4.4 Select given region
4.5 Click the button 'docker'

5. 'Docker'-Tab
5.1 Under Image Source select 'Docker Hub'
5.2 Enter this for 'Image and tag': mcr.microsoft.com/azuredocs/aci-helloworld'

6. Click 'Create' and wait for the Web App to be deployed.
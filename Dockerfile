FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
# устанавливаем нужную версию NodeJS 15
RUN curl -sL https://deb.nodesource.com/setup_15.x | bash - && \
  apt-get install -y nodejs
WORKDIR /src
COPY ["DbFirstProj.csproj", "./"]
RUN dotnet restore "DbFirstProj.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "DbFirstProj.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DbFirstProj.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DbFirstProj.dll"]
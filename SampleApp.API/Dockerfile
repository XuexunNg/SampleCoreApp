FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["SampleApp.csproj", ""]
RUN dotnet restore "./SampleApp.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SampleApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SampleApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SampleApp.dll"]
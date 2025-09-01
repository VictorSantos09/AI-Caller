# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "AI Caller.sln"
RUN dotnet publish "AiCaller.UI/AiCaller.UI.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 7044
ENV ASPNETCORE_URLS=http://+:7044
ENTRYPOINT ["dotnet", "AiCaller.UI.dll"]

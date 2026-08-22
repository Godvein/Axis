FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Axis.Web/Axis.Web.csproj"
RUN dotnet publish "Axis.Web/Axis.Web.csproj" -o /published /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /published .
ENTRYPOINT ["dotnet", "Axis.Web.dll"]
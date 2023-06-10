FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/MyEcommerce.Web.Host/MyEcommerce.Web.Host.csproj", "src/MyEcommerce.Web.Host/"]
COPY ["src/MyEcommerce.Web.Core/MyEcommerce.Web.Core.csproj", "src/MyEcommerce.Web.Core/"]
COPY ["src/MyEcommerce.Application/MyEcommerce.Application.csproj", "src/MyEcommerce.Application/"]
COPY ["src/MyEcommerce.Core/MyEcommerce.Core.csproj", "src/MyEcommerce.Core/"]
COPY ["src/MyEcommerce.EntityFrameworkCore/MyEcommerce.EntityFrameworkCore.csproj", "src/MyEcommerce.EntityFrameworkCore/"]
WORKDIR "/src/src/MyEcommerce.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/MyEcommerce.Web.Host", "src/MyEcommerce.Web.Host"]
COPY ["src/MyEcommerce.Web.Core", "src/MyEcommerce.Web.Core"]
COPY ["src/MyEcommerce.Application", "src/MyEcommerce.Application"]
COPY ["src/MyEcommerce.Core", "src/MyEcommerce.Core"]
COPY ["src/MyEcommerce.EntityFrameworkCore", "src/MyEcommerce.EntityFrameworkCore"]
WORKDIR "/src/src/MyEcommerce.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "MyEcommerce.Web.Host.dll"]

#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["Ecommerce-Angular/Ecommerce-Angular.csproj", "Ecommerce-Angular/"]
COPY ["Ecommerce.Services/Ecommerce.Services.csproj", "Ecommerce.Services/"]
COPY ["Ecommerce.BLL/Ecommerce.Models.csproj", "Ecommerce.BLL/"]
COPY ["Ecommerce.DAL/Ecommerce.DAL.csproj", "Ecommerce.DAL/"]
COPY ["Ecommerce.Services.Contracts/Ecommerce.Services.Interfaces.csproj", "Ecommerce.Services.Contracts/"]
COPY ["Ecommerce.Identity/Ecommerce.Identity.csproj", "Ecommerce.Identity/"]
RUN dotnet restore "Ecommerce-Angular/Ecommerce-Angular.csproj"
COPY . .
WORKDIR "/src/Ecommerce-Angular"
RUN dotnet build "Ecommerce-Angular.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ecommerce-Angular.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce-Angular.dll"]
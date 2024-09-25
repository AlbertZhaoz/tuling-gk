#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 9991

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["VOL.WebApi/VOL.WebApi.csproj", "VOL.WebApi/"]
COPY ["VOL.Albert.BasicData/VOL.Albert.BasicData.csproj", "VOL.Albert.BasicData/"]
COPY ["VOL.Core/VOL.Core.csproj", "VOL.Core/"]
COPY ["VOL.Entity/VOL.Entity.csproj", "VOL.Entity/"]
COPY ["VOL.Albert.DataQuery/VOL.Albert.DataQuery.csproj", "VOL.Albert.DataQuery/"]
COPY ["VOL.Albert.Device/VOL.Albert.Device.csproj", "VOL.Albert.Device/"]
COPY ["VOL.Albert.ProductionManager/VOL.Albert.ProductionManager.csproj", "VOL.Albert.ProductionManager/"]
COPY ["VOL.Albert.Inbound/VOL.Albert.Inbound.csproj", "VOL.Albert.Inbound/"]
COPY ["Vol.Albert.SystemTool/Vol.Albert.SystemTool.csproj", "Vol.Albert.SystemTool/"]
COPY ["VOL.Builder/VOL.Builder.csproj", "VOL.Builder/"]
COPY ["VOL.System/VOL.System.csproj", "VOL.System/"]
RUN dotnet restore "VOL.WebApi/VOL.WebApi.csproj"
COPY . .
WORKDIR "/src/VOL.WebApi"
RUN dotnet build "VOL.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VOL.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VOL.WebApi.dll"]
#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["InterestCalcApi/InterestCalcApi.csproj", "InterestCalcApi/"]
RUN dotnet restore "InterestCalcApi/InterestCalcApi.csproj"
COPY . .
WORKDIR "/src/InterestCalcApi"
RUN dotnet build "InterestCalcApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InterestCalcApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InterestCalcApi.dll"]

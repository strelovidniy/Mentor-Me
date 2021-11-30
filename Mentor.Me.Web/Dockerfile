#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Mentor.Me.Web/Mentor.Me.Web.csproj", "Mentor.Me.Web/"]
COPY ["Mentor.Me.Domain/Mentor.Me.Domain.csproj", "Mentor.Me.Domain/"]
COPY ["Mentor.Me.Data/Mentor.Me.Data.csproj", "Mentor.Me.Data/"]
RUN dotnet restore "Mentor.Me.Web/Mentor.Me.Web.csproj"
COPY . .
WORKDIR "/src/Mentor.Me.Web"
RUN dotnet build "Mentor.Me.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mentor.Me.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mentor.Me.Web.dll"]
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
EXPOSE 80

RUN curl -sL https://deb.nodesource.com/setup_17.x |  bash -
RUN apt-get install -y nodejs

COPY . ./
RUN dotnet restore ./Mentor.Me.Web
RUN dotnet build ./Mentor.Me.Web -c Release
RUN dotnet publish ./Mentor.Me.Web/Mentor.Me.Web.csproj -c Release -o MentorME --no-restore --no-build

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build-env /app/MentorME .

ENTRYPOINT ["dotnet", "Mentor.Me.dll"]
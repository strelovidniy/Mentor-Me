FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
EXPOSE 80

RUN curl -sL https://deb.nodesource.com/setup_17.x |  bash -
RUN apt-get install -y nodejs

ARG dotnet_cli_home_arg=/tmp/DOTNET_CLI_HOME
ENV DOTNET_CLI_HOME=$dotnet_cli_home_arg

COPY . ./
RUN dotnet publish -c Release -o MentorME

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

FROM build-env as final
COPY --from=build-env /app/MentorME /app/MentorME

ENTRYPOINT ["dotnet", "Mentor.Me.Web.dll"]

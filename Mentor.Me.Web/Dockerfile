FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app
EXPOSE 80

#RUN curl -sL https://deb.nodesource.com/setup_17.x |  bash -
#RUN apt-get install -y nodejs
#
COPY . ./
RUN ls -a
#RUN dotnet publish -c Release -o MentorME



#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
#WORKDIR /app
#COPY --from=build-env /app/MentorME .
#
ENTRYPOINT ["dotnet", "Mentor.Me.dll"]

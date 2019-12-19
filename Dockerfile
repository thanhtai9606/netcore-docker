FROM mcr.microsoft.com/dotnet/core/sdk:latest as debug

#install debugger for NET Core
RUN apt-get update
RUN apt-get install -y unzip
RUN curl -sSL https://aka.ms/getvsdbgsh | /bin/sh /dev/stdin -v latest -l ~/vsdbg

RUN mkdir /acb-app/
WORKDIR /acb-app/

COPY . .
RUN dotnet restore

COPY ./acb-app.csproj /acb-app/acb-app.csproj
RUN mkdir /out/
RUN dotnet publish --no-restore --output /out/ --configuration Release

ENTRYPOINT ["dotnet", "run"]

###########START NEW IMAGE###########################################

FROM mcr.microsoft.com/dotnet/core/aspnetcore as prod

RUN mkdir /app/
WORKDIR /app/
COPY --from=dev /out/ /app/
RUN chmod +x /app/ 
CMD dotnet acb-app.dll

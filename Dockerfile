FROM microsoft/dotnet:latest
WORKDIR /app
COPY . .
ENV ASPNETCORE_URLS http://*:8080
ENV datastore__connection mongodb://localhost:27017
ENV clientUrls__0 http://localhost:7080
ENV documentationPath "./bin/Release/netcoreapp1.1/SupplierCatalogue.API.xml"
EXPOSE 8080
RUN dotnet restore
WORKDIR /app/SupplierCatalogue.API
RUN dotnet build --configuration Release
CMD ["dotnet","run","--configuration","Release"]

# The configuration aboves copies all source to the container and performs the `dotnet restore` and `dotnet build` within that container.
# Ideally we would want to build the solution first and only copy the built solution to the container to run. However, this currently causes an unmet
# dependancy issue on an Application Insights dll and will not run.

# The configuration for this process for reference is below:

# FROM microsoft/aspnetcore:1.1.1
# WORKDIR /
# COPY out ./
# ENV ASPNETCORE_URLS http://*:8080
# EXPOSE 8080

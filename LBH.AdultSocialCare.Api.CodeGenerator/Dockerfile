FROM mcr.microsoft.com/dotnet/core/sdk:3.1

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
# Do not run GodeGenerator.exe on CI server
ENV SKIP_CODE_GENERATION = 1
RUN dotnet build -c Release -o out
RUN dotnet publish -c Release -o out

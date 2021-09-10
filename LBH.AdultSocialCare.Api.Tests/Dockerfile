FROM mcr.microsoft.com/dotnet/core/sdk:3.1

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

ENV DynamoDb_LocalMode='true'

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./LBH.AdultSocialCare.Api.sln ./
COPY ./LBH.AdultSocialCare.Api/LBH.AdultSocialCare.Api.csproj ./LBH.AdultSocialCare.Api/
COPY ./LBH.AdultSocialCare.Api.CodeGenerator/LBH.AdultSocialCare.Api.CodeGenerator.csproj ./LBH.AdultSocialCare.Api.CodeGenerator/
COPY ./LBH.AdultSocialCare.Api.Tests/LBH.AdultSocialCare.Api.Tests.csproj ./LBH.AdultSocialCare.Api.Tests/

RUN dotnet restore ./LBH.AdultSocialCare.Api.CodeGenerator/LBH.AdultSocialCare.Api.CodeGenerator.csproj
RUN dotnet restore ./LBH.AdultSocialCare.Api/LBH.AdultSocialCare.Api.csproj
RUN dotnet restore ./LBH.AdultSocialCare.Api.Tests/LBH.AdultSocialCare.Api.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -o out LBH.AdultSocialCare.Api.CodeGenerator/LBH.AdultSocialCare.Api.CodeGenerator.csproj
RUN dotnet build -c debug -o out LBH.AdultSocialCare.Api.Tests/LBH.AdultSocialCare.Api.Tests.csproj

CMD dotnet test

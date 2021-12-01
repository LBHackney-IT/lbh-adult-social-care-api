FROM mcr.microsoft.com/dotnet/core/sdk:3.1

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

ENV DynamoDb_LocalMode='true'

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./LBH.AdultSocialCare.Api.sln ./
COPY ./LBH.AdultSocialCare.Api/LBH.AdultSocialCare.Api.csproj ./LBH.AdultSocialCare.Api/
COPY ./Tests/LBH.AdultSocialCare.Functions.Payruns.Tests/LBH.AdultSocialCare.Functions.Payruns.Tests.csproj ./Tests/LBH.AdultSocialCare.Functions.Payruns.Tests/

RUN dotnet restore ./LBH.AdultSocialCare.Api/LBH.AdultSocialCare.Api.csproj
RUN dotnet restore ./Tests/LBH.AdultSocialCare.Functions.Payruns.Tests/LBH.AdultSocialCare.Functions.Payruns.Tests.csproj

# Copy everything else and build
COPY . .

ENV SKIP_CODE_GENERATION=1
RUN dotnet build -c debug -o out Tests/LBH.AdultSocialCare.Functions.Payruns.Tests/LBH.AdultSocialCare.Functions.Payruns.Tests.csproj

CMD dotnet test

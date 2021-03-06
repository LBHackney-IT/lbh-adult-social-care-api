[![LBHackney-IT](https://circleci.com/gh/LBHackney-IT/lbh-adult-social-care-api.svg?style=svg)](https://circleci.com/gh/LBHackney-IT/lbh-adult-social-care-api)

# Social Care Finance System API

The Social Care Service API provides [service API](http://playbook.hackney.gov.uk/API-Playbook/platform_api_vs_service_api#a-service-apis) capabilities for the [Social Care Finance Frontend](https://github.com/LBHackney-IT/lbh-adult-social-care-frontend) which is part of the Social Care system (see [Social Care System Architecture](https://github.com/LBHackney-IT/social-care-architecture/tree/main) for more details).

![C4 Component Diagram](docs/component-diagram.svg)


## Table of contents

  - [Getting started](#getting-started)
    - [Prerequisites](#prerequisites)
    - [Dockerised dependencies](#dockerised-dependencies)
    - [Installation](#installation)
  - [Usage](#usage)
    - [Running the application](#running-the-application)
      - [Using dotnet run](#using-dotnet-run)
      - [Using docker](#using-docker)
    - [Running the tests](#running-the-tests)
      - [Using the terminal](#using-the-terminal)
      - [Using an IDE](#using-an-ide)
  - [Documentation](#documentation)
    - [Architecture](#architecture)
    - [API design](#api-design)
    - [Databases](#databases)
      - [PostgreSQL (RDS PostgreSQL in AWS)](#postgresql-rds-postgresql-in-aws)
    - [Deployment](#deployment)
    - [Infrastructure](#infrastructure)
    - [Related repositories](#related-repositories)
  - [Active contributors](#active-contributors)
  - [License](#license)

## Getting started

### Prerequisites

- [Docker](https://www.docker.com/products/docker-desktop)
- [.NET Core 3.1](https://dotnet.microsoft.com/download)

### Dockerised dependencies

- PostgreSQL 12

### Installation

1. Clone this repository

```sh
$ git clone git@github.com:LBHackney-IT/social-care-case-viewer-api.git
```

## Usage

### Running the application

There are two ways of running the application: using dotnet or using docker.

#### Using dotnet run
Using the dotnet command will not automatically connect the API to any local database instances.

To serve the API locally with dotnet,
run `dotnet run` from within the [SocialCareFinanceSystemApi](./LBH.AdultSocialCare.Api) project directory, i.e:

```sh
$ cd SocialCareCaseViewerApi && dotnet run
```

**The application will be served at http://localhost:5000**.

#### Using docker

Run the API locally with connected local dev databases using this command:

```sh
$ make serve
```
**The application will be served at http://localhost:3000**.

N.B: This would only spin up the Application, Postgres locally in docker.
It doesn't include setup for spinning up other APIs that this service connects to in Staging or in Production.


### Running the tests

There are two ways of running the tests: using the terminal and using an IDE.

#### Using the terminal

To run all tests, use:

```sh
$ make test
```

To run some tests i.e. single or a group, run the test databases in the background:

```sh
$ make start-test-dbs
```

And then you can filter through tests, using the `--filter` argument of the
`dotnet test` command:

```sh
# E.g. for a specific test, use the test method name
$ dotnet test --filter ShouldReturnPackageSchedulingOptionsList
# E.g. for a file, use the test class name
$ dotnet test --filter CarePackagesControllerE2ETests
```

If your docker test postgres database is out of sync with the schema on your current branch run

```sh
$ make restart-test-pg-db
```

See [Microsoft's documentation on running selective unit tests](https://docs.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests?pivots=mstest) for more information.

#### Using an IDE

Run the test databases in the background, using:

```sh
$ make start-test-dbs
```

This will allow you to run the tests as normal in your IDE.

## Documentation

### Architecture

As this service API is a part of the Social Care System, higher level documentation lives in a separate repository called [Social Care System Architecture](https://github.com/LBHackney-IT/social-care-architecture/).

To find out more about the process and tooling for our diagrams, see [Process documentation in Social Care System Architecture](https://github.com/LBHackney-IT/social-care-architecture/blob/main/process.md).

### API design

We use [SwaggerHub](https://swagger.io/tools/swaggerhub/) to document the API design, of which we have one version:

- [Self-hosted](https://zqf7j796y5.execute-api.eu-west-2.amazonaws.com/staging/swagger/index.html) - for actual endpoint design which is auto-generated using comments

### Databases

The service API has one database (as seen in the [C4 component diagram](./docs/component-diagram.svg)):

#### [PostgreSQL](https://www.postgresql.org) (RDS PostgreSQL in AWS)

This database stores:

1. Care package information. E.g: Core package weekly price, service user's packages, reclaims, etc.
2. Invoice information. E.g: Invoice and billing for packages, payrun request, export for CEDAR, etc.

### Deployment

We have two environments:

- Staging (**Mosaic-Staging** AWS account)
- Production (**Mosaic-Production** AWS account)

and two deployment branches:

- `master` which deploys to Staging and Production
- `staging` which deploys to Staging
- `develop` which deploys to Development

This means pull request merges into `master` and `development` both trigger a deployment to Staging, but only `master` can trigger a deployment for Production.

To deploy to Production, we first ensure that changes are verified in Staging and then we merge `development` into `master`.

We use CircleCI to handle deployment, see [CircleCI config](./.circleci/config.yml).

### Infrastructure

For deploying the Lambdas and related resources, we used the [Serverless framework](https://www.serverless.com) (see [serverless.yml](./LBH.AdultSocialCare.Api/serverless.yml)).

For managing the database in Staging, we use [Terraform](https://www.terraform.io) that is defined within `/terraform/staging` in this repository.

For managing the database and other resources in Production, we use Terraform that is defined within the [Infrastructure repository](https://github.com/LBHackney-IT/infrastructure/blob/master/projects/mosaic).

### Related repositories

| Name | Purpose |
|-|-|
| [LBH Social Care Finance Frontend](https://github.com/LBHackney-IT/lbh-adult-social-care-frontend) | Provides the UI/UX of the Social Care Finance System. |
| [Residents Social Care Platform API](https://github.com/LBHackney-IT/residents-social-care-platform-api) | Provides [platform API](http://playbook.hackney.gov.uk/API-Playbook/platform_api_vs_service_api#b-platform-apis) capabilities by providing historic social care data from Mosaic to the Social Care System. |
| [Infrastructure](https://github.com/LBHackney-IT/infrastructure) | Provides a single place for AWS infrastructure defined using [Terraform](https://www.terraform.io) as [infrastructure as code](https://en.wikipedia.org/wiki/Infrastructure_as_code) as part of Hackney's new AWS account strategy. NB: Due to its recent introduction, the Social Care System has infrastructure across multiple places. |
| [API Playbook](http://playbook.hackney.gov.uk/API-Playbook/) | Provides guidance to the standards of APIs within Hackney. |

## Active contributors

- **Tuomo Karki**, Lead Developer at Hackney (tuomo.karki@hackney.gov.uk)
- **Neil Kidd**, Lead Software Engineer at Made Tech (neil.kidd@hackney.gov.uk)
- **Burak Ozkan**, Tech Lead at Nudge Digital (burak.ozkan@nudgedigitals.co.uk)
- **Duncan Okeno**, Software Developer at Nudge Digital (duncan.okeno@nudgedigital.co.uk)
- **Furkan Kayar**, Software Developer at Nudge (furkan.kayar@nudgedigital.co.uk)
- **Vladimir Kapenkin**, Senior Software Developer at Nudge (vladimir.kapenkin@nudgedigital.co.uk)

## License

[MIT License](LICENSE)

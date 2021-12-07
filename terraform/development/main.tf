  provider "aws" {
  region  = "eu-west-2"
  version = "~> 2.0"
}
data "aws_caller_identity" "current" {}
data "aws_region" "current" {}
locals {
   application_name = "adult social care api"
   parameter_store = "arn:aws:ssm:${data.aws_region.current.name}:${data.aws_caller_identity.current.account_id}:parameter"
}

terraform {
  backend "s3" {
    bucket  = "lbh-mosaic-terraform-state-development"
    encrypt = true
    region  = "eu-west-2"
    key     = "services/adult-social-care-api/state"
  }
}

/*    POSTGRES SET UP    */
data "aws_vpc" "development_vpc" {
  tags = {
    Name = "ASCFinance-dev"
  }
}
data "aws_subnet_ids" "development_private_subnets" {
  vpc_id = data.aws_vpc.development_vpc.id
  filter {
    name   = "tag:Name"
    values = ["ASCFinance-dev-private-eu-west-2b", "ASCFinance-dev-private-eu-west-2a"]
  }
}

data "aws_ssm_parameter" "adult_sc_postgres_db_name" {
   name = "/hasc-api/development/postgres-database"
 }

data "aws_ssm_parameter" "adult_sc_postgres_db_password" {
   name = "/hasc-api/development/postgres-password"
 }

 data "aws_ssm_parameter" "adult_sc_postgres_username" {
   name = "/hasc-api/development/postgres-username"
 }

module "postgres_db_development" {
    source = "github.com/LBHackney-IT/aws-hackney-common-terraform.git//modules/database/postgres"
    environment_name = "development"
    vpc_id = data.aws_vpc.development_vpc.id
    db_identifier = data.aws_ssm_parameter.adult_sc_postgres_db_name.value
    db_name = "adult_sc_db"
    db_port  = 5829
    subnet_ids = data.aws_subnet_ids.development_private_subnets.ids
    db_engine = "postgres"
    db_engine_version = "12.7"
    db_instance_class = "db.t3.small"
    db_allocated_storage = 20
    maintenance_window = "sun:10:00-sun:10:30"
    db_username = data.aws_ssm_parameter.adult_sc_postgres_username.value
    db_password = data.aws_ssm_parameter.adult_sc_postgres_db_password.value
    storage_encrypted = true
    multi_az = false //only true if production deployment
    publicly_accessible = false
    project_name = "adult social care"
}

resource "aws_sqs_queue" "payruns_queue" {
  name                            = "lbh-adult-social-care-payruns-development"
  visibility_timeout_seconds      = 60
  max_message_size                = 2048
}

resource "aws_sqs_queue_policy" "payruns_queue_to_lambda_policy" {
  queue_url = aws_sqs_queue.payruns_queue.id

  policy = jsonencode({
    "Version": "2012-10-17",
    "Statement": [
      {
        "Effect": "Allow",
        "Principal": {
          "Service": [
            "lambda.amazonaws.com"
          ]
        },
        "Action": [
          "sqs:SendMessage",
          "sqs:DeleteMessage",
          "sqs:GetQueueAttributes",
          "sqs:ReceiveMessage",
          "sqs:GetQueueUrl",
          "sqs:ChangeMessageVisibility"
        ],
        "Resource": aws_sqs_queue.payruns_queue.arn,
      }
    ]
  })
}

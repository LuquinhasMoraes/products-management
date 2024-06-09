provider "aws" {
  region     = "us-west-2"  # Substitua pela região desejada
  access_key = var.aws_access_key
  secret_key = var.aws_secret_key
}

terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "4.54.0"
    }
  }
}

provider "azurerm" {
  features {
  }
  subscription_id = "a807f40c-6671-4b6e-9c3e-411f84153bba"
}

resource "azurerm_resource_group" "arg" {
  name     = "TerraformDemoRG"
  location = "Poland Central"
}
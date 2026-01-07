terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "4.54.0"
    }
    random = {
      source  = "hashicorp/random"
      version = "3.7.2"
    }
  }
}

provider "azurerm" {
  features {
  }
  subscription_id = "a807f40c-6671-4b6e-9c3e-411f84153bba"
}

resource "random_integer" "ri" {
  min = 1
  max = 99999
}

resource "azurerm_resource_group" "arg" {
  name     = "TaskBoard${random_integer.ri.result}"
  location = "Spain Central"
}

resource "azurerm_service_plan" "asp" {
  name                = "TaskBoardServicePlan${random_integer.ri.result}"
  resource_group_name = azurerm_resource_group.arg.name
  location            = azurerm_resource_group.arg.location
  os_type             = "Linux"
  sku_name            = "F1"
}

resource "azurerm_linux_web_app" "alwa" {
  name                = "TaskBoardApp${random_integer.ri.result}"
  resource_group_name = azurerm_resource_group.arg.name
  location            = azurerm_service_plan.asp.location
  service_plan_id     = azurerm_service_plan.asp.id

  connection_string {
    name  = "DefaultConnection"
    type  = "SQLAzure"
    value = "Data Source=tcp:${azurerm_mssql_server.mssqlserver.fully_qualified_domain_name},1433;Initial Catalog=${azurerm_mssql_database.mssql_db.name};User ID=${azurerm_mssql_server.mssqlserver.administrator_login};Password=${azurerm_mssql_server.mssqlserver.administrator_login_password};Trusted_Connection=False; MultipleActiveResultSets=True;"
  }

  site_config {
    application_stack {
      dotnet_version = "6.0"
    }
    always_on = false
  }
}

resource "azurerm_mssql_server" "mssqlserver" {
  name                         = "mssqlserver${random_integer.ri.result}"
  resource_group_name          = azurerm_resource_group.arg.name
  location                     = azurerm_resource_group.arg.location
  version                      = "12.0"
  administrator_login          = "*admin-soll?"
  administrator_login_password = "*TaskBoard-pass78"
}

resource "azurerm_mssql_database" "mssql_db" {
  name                 = "mssql_db${random_integer.ri.result}"
  server_id            = azurerm_mssql_server.mssqlserver.id
  collation            = "SQL_Latin1_General_CP1_CI_AS"
  license_type         = "LicenseIncluded"
  max_size_gb          = 2
  sku_name             = "S0"
  zone_redundant       = false
  geo_backup_enabled   = false
  storage_account_type = "Local"

  lifecycle {
    prevent_destroy = false
  }
}

resource "azurerm_mssql_firewall_rule" "FirewallRule1" {
  name             = "FirewallRule1"
  server_id        = azurerm_mssql_server.mssqlserver.id
  start_ip_address = "0.0.0.0"
  end_ip_address   = "0.0.0.0"
}



resource "azurerm_app_service_source_control" "github" {
  app_id                 = azurerm_linux_web_app.alwa.id
  repo_url               = "https://github.com/Solenkoff/TaskBoardApp_DB_Terraform"
  branch                 = "main"
  use_manual_integration = true
}


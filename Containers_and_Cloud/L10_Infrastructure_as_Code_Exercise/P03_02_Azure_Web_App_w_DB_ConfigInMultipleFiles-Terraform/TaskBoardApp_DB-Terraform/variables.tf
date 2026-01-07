

variable "resource_group_name" { 
  description = "Resource group name in Azure"
  type        = string
}

variable "resource_group_location" {
  description = "The Azure region to deploy resource"
  type        = string
}

variable "app_service_plan_name" {
  description = "The name of the App Service Plan"
  type        = string
}

variable "web_app_name" {                       #  web_app_name
  description = "The name of the Web App / Service"
  type        = string
}

variable "sql_server_name" {
  description = "The name of the SQL server"
  type        = string
}

variable "sql_database_name" {
  description = "The name of the SQL Database"
  type        = string
}

variable "sql_admin_username" {
  description = "SQL administrator login username"
  type        = string
}

variable "sql_admin_password" {
  description = "SQL administrator login password"
  type        = string
  sensitive   = true
}

variable "firewall_rule_name" {
  description = "The name of the SQL server Firewall rule"
  type        = string
}

variable "github_repo_url" {
  description = "The URL of the GitHub repository for deployment"
  type        = string
}
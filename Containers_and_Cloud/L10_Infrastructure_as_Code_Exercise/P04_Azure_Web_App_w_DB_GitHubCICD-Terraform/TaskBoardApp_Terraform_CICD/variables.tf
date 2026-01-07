

variable "resource_group_name" {
  type        = string
  description = "Resource group name in Azure"
}

variable "resource_group_location" {
  type        = string
  description = "The Azure region to deploy resource"
}

variable "app_service_plan_name" {
  type        = string
  description = "The name of the App Service Plan"
}

variable "app_service_name" {
  type        = string
  description = "The name of the App Service"
}

variable "sql_server_name" {
  type        = string
  description = "The name of the SQL server"
}

variable "sql_database_name" {
  type        = string
  description = "SQL Database name in Azure"
}

variable "sql_admin_username" {
  type        = string
  description = "SQL administrator login username"
}

variable "sql_admin_password" {
  type        = string
  sensitive   = true
  description = "SQL administrator login password"
}

variable "firewall_rule_name" {
  type        = string
  description = "The name of the SQL server Firewall rule"
}

variable "github_repo_url" {
  type        = string
  description = "GitHub repo URL"
}
output "app_url" {
  description = "The fully qualified domain name of the Linux Web App"
  value       = azurerm_linux_web_app.alwa.default_hostname
}

output "IP_address" {
  description = "The IP address of the Web App"
  value       = azurerm_linux_web_app.alwa.outbound_ip_addresses
}   

terraform {
  required_providers {
    docker = {
      source  = "kreuzwerker/docker"
      version = "3.6.2"
    }
  }
}

provider "docker" {
  host = "npipe:////./pipe/docker_engine"
}

resource "docker_image" "nginxsoll" {
  name = "nginxdemos/hello"
}

resource "docker_container" "nginxsoll-container" {
  image = resource.docker_image.nginxsoll.name
  name = "nginx_hello"

  ports{
    internal = 80
    external = 5000
  }
} 

resource "docker_volume" "shared_volume" {
  name = "shared_volume"
}
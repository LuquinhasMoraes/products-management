variable "aws_access_key" {
  description = "AWS Access Key"
  type        = string
}

variable "aws_secret_key" {
  description = "AWS Secret Key"
  type        = string
}

variable "task_container_name" {
  description = "Nome do contêiner da tarefa"
  type        = string
  default     = "myapp-container"
}

variable "task_image" {
  description = "Imagem do contêiner da tarefa"
  type        = string
  default     = "your-ecr-repo-url:latest"  # Substitua pela URL do seu repositório de contêiner no ECR
}

variable "task_memory" {
  description = "Memória alocada para a tarefa em MB"
  type        = number
  default     = 512
}

variable "task_cpu" {
  description = "CPU alocada para a tarefa em unidades"
  type        = number
  default     = 256
}

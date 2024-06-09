resource "aws_ecs_cluster" "my_cluster" {
  name = "my-cluster"
}

resource "aws_ecs_task_definition" "my_task" {
  family                   = "my-task"
  container_definitions    = jsonencode([{
    name  = var.task_container_name
    image = var.task_image
    memory_reservation = var.task_memory
    cpu = var.task_cpu
    # Outras configurações do contêiner, como portas, variáveis de ambiente, etc.
  }])
  requires_compatibilities = ["FARGATE"]
  network_mode             = "awsvpc"
  cpu                      = var.task_cpu
  memory                   = var.task_memory
}

resource "aws_ecs_service" "my_service" {
  name            = "my-service"
  cluster         = aws_ecs_cluster.my_cluster.id
  task_definition = aws_ecs_task_definition.my_task.arn
  desired_count   = 1
  launch_type     = "FARGATE"

  network_configuration {
    subnets         = ["subnet-12345678", "subnet-87654321"]  # Substitua pelos IDs das subnets
    security_groups = ["sg-0123456789abcdef0"]                # Substitua pelo ID do security group
    assign_public_ip = true
  }
}

using Xunit;
using TeamTasker.API.Entities; 
using TeamTasker.API.Enums;    

namespace TeamTasker.Tests.Domain
{
    public class JobTaskTests
    {
        [Fact]
        public void Deve_Criar_JobTask_Com_Dados_Corretos()
        {
            // 1. Arrange
            var dataCriacao = DateTime.Now;
            
            // 2. Act
            var tarefa = new JobTask 
            { 
                Title = "Estudar xUnit", 
                Description = "Criar testes para a API",
                
                Status = TaskStatusEnum.Pendente, 
                CreatedAt = dataCriacao
            };

            // 3. Assert
            Assert.Equal("Estudar xUnit", tarefa.Title);
            
            
            Assert.Equal(TaskStatusEnum.Pendente, tarefa.Status); 
            
            Assert.Equal(dataCriacao, tarefa.CreatedAt);
        }
    }
}
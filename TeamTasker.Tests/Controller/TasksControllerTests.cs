using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc; 
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using TeamTasker.API.Controllers;
using TeamTasker.API.Entities;     
using TeamTasker.API.Repositories; 
using  TeamTasker.API.Enums;       

namespace TeamTasker.Tests.Controllers
{
    public class TasksControllerTests
    {
        
        private readonly Mock<ITaskRepository> _taskRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        
        
        private readonly TasksController _controller;

        public TasksControllerTests()
        {
            
            _taskRepositoryMock = new Mock<ITaskRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();

            
            _controller = new TasksController(_taskRepositoryMock.Object, _userRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAll_Deve_Retornar_Status200_Com_Lista_De_Tarefas()
        {
            //  ARRANGE 
            var listaFake = new List<JobTask>
            {
                new JobTask { 
                    Id = 1, 
                    Title = "Teste Controller 1", 
                    Status = TaskStatusEnum.Pendente 
                },
                new JobTask { 
                    Id = 2, 
                    Title = "Teste Controller 2", 
                    Status = TaskStatusEnum.Concluida 
                }
            };

            
            _taskRepositoryMock.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(listaFake);

            //  ACT 
            var resultado = await _controller.GetAll();

            // ASSERT 
            
            
            var okResult = Assert.IsType<OkObjectResult>(resultado);

            
            Assert.NotNull(okResult.Value);

           
            _taskRepositoryMock.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task Delete_Deve_Retornar_NotFound_Se_Id_Nao_Existir()
        {
            // --- ARRANGE ---
            int idInexistente = 99;

            
            _taskRepositoryMock.Setup(repo => repo.GetByIdAsync(idInexistente))
                .ReturnsAsync((JobTask?)null);

            // --- ACT ---
            var resultado = await _controller.Delete(idInexistente);

            // --- ASSERT ---
            
            Assert.IsType<NotFoundResult>(resultado);
        }
    }
}
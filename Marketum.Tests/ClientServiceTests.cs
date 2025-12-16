using Marketum.Domain;
using Marketum.Domain.Exceptions;
using Marketum.Persistence;
using Marketum.Services;
using Moq;
using Xunit;

namespace Marketum.Tests
{
    public class ClientServiceTests
    {
        private readonly Mock<IClientRepository> _mockRepository;
        private readonly ClientService _clientService;

        public ClientServiceTests()
        {
            _mockRepository = new Mock<IClientRepository>();
            _clientService = new ClientService(_mockRepository.Object);
        }

        [Fact]
        public void AddClient_WithValidData_ShouldCallRepository()
        {
            // Arrange
            var expectedClient = new Client
            {
                Id = 1,
                Name = "João Silva",
                TaxNr = "123456789",
                Email = "joao@email.com",
                Phone = "912345678",
                Address = "Rua A, 123"
            };

            _mockRepository.Setup(r => r.Add(It.IsAny<Client>()))
                          .Returns(expectedClient);

            // Act
            var result = _clientService.AddClient("João Silva", "123456789", "joao@email.com", "912345678", "Rua A, 123");

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedClient.Name, result.Name);
            _mockRepository.Verify(r => r.Add(It.IsAny<Client>()), Times.Once);
        }

        [Theory]
        [InlineData("", "123456789", "joao@email.com", "O nome do cliente é obrigatório.")]
        [InlineData(null, "123456789", "joao@email.com", "O nome do cliente é obrigatório.")]
        [InlineData("   ", "123456789", "joao@email.com", "O nome do cliente é obrigatório.")]
        [InlineData("João Silva", "", "joao@email.com", "O NIF é obrigatório.")]
        [InlineData("João Silva", null, "joao@email.com", "O NIF é obrigatório.")]
        [InlineData("João Silva", "   ", "joao@email.com", "O NIF é obrigatório.")]
        [InlineData("João Silva", "123456789", "", "O email é obrigatório.")]
        [InlineData("João Silva", "123456789", null, "O email é obrigatório.")]
        [InlineData("João Silva", "123456789", "   ", "O email é obrigatório.")]
        public void AddClient_WithInvalidData_ShouldThrowValidationException(string name, string taxNr, string email, string expectedMessage)
        {
            // Arrange & Act & Assert
            var exception = Assert.Throws<ValidationException>(() =>
                _clientService.AddClient(name, taxNr, email, "912345678", "Rua A, 123"));

            Assert.Equal(expectedMessage, exception.Message);
            _mockRepository.Verify(r => r.Add(It.IsAny<Client>()), Times.Never);
        }

        [Fact]
        public void GetById_WhenClientNotFound_ShouldThrowNotFoundException()
        {
            // Arrange
            int clientId = 999;
            _mockRepository.Setup(r => r.GetById(clientId))
                          .Returns((Client?)null);

            // Act & Assert
            var exception = Assert.Throws<NotFoundException>(() =>
                _clientService.GetById(clientId));

            Assert.Equal($"Cliente com o ID {clientId} não encontrado.", exception.Message);
            _mockRepository.Verify(r => r.GetById(clientId), Times.Once);
        }

        [Fact]
        public void GetById_WhenClientExists_ShouldReturnClient()
        {
            // Arrange
            int clientId = 1;
            var expectedClient = new Client
            {
                Id = clientId,
                Name = "João Silva",
                TaxNr = "123456789",
                Email = "joao@email.com"
            };

            _mockRepository.Setup(r => r.GetById(clientId))
                          .Returns(expectedClient);

            // Act
            var result = _clientService.GetById(clientId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedClient.Id, result.Id);
            Assert.Equal(expectedClient.Name, result.Name);
            _mockRepository.Verify(r => r.GetById(clientId), Times.Once);
        }
    }
}
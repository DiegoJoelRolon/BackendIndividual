using Application.Interfaces;
using Application.Interfaces.IMappers;
using Application.Interfaces.Validations;
using Application.Request;
using Application.Response;
using Application.UseCases;
using Application.Validations;
using Domain.Entities;
using Moq;

namespace TestProject1
{
    public class UnitTest1
    {

        [Fact]
        public async Task Test1()
        {
            // Arrange
            var mockClientQuery = new Mock<IClientQuery>();
            var mockClientMapper = new Mock<IClientMapper>();
            var mockClientCommand = new Mock<IClientCommand>();
            var clientValidation = new ClientValidations();

            var clientService = new ClientService(
                mockClientCommand.Object,
                mockClientQuery.Object,
                mockClientMapper.Object,
                clientValidation
            );

            var request = new ClientRequest
            {
                Address = "UnitTest123",
                Company = "unit",
                Email = "email@.com",
                Name = "name",
                Phone = "61236578"
            };

            var clientEntity = new Clients
            {
                Address = request.Address,
                Company = request.Company,
                Email = request.Email,
                Name = request.Name,
                Phone = request.Phone,
                CreateDate = DateTime.Now
            };

            var clientResponse = new ClientResponse
            {
                Address = request.Address,
                Company = request.Company,
                Email = request.Email,
                Name = request.Name,
                Phone = request.Phone
            };

            // Configurar mocks


            mockClientCommand
                .Setup(c => c.CreateClient(It.IsAny<Clients>()))
                .ReturnsAsync(clientEntity); // Devuelve la entidad creada

            mockClientQuery
                .Setup(q => q.GetClientById(clientEntity.ClientID))
                .ReturnsAsync(clientEntity); // Devuelve la entidad por ID

            mockClientMapper
                .Setup(m => m.CreateClientResponse(It.IsAny<Clients>()))
                .ReturnsAsync(clientResponse); // Mapea la entidad a la respuesta

            // Act
            var result = await clientService.CreateClient(request);

            // Assert
            Assert.Equal(result.Name, request.Name);

        }
    }
}
using master.bank.domain.core.Entity.route;
using master.bank.domain.core.repository.Interface.route;
using master.bank.domain.core.service.route;
using Moq;

namespace master.bank.test.service;

public class RouteServiceTests
{
    private readonly Mock<IRouteRepository> _repositoryMock;
    private readonly RouteService _routeService;

    public RouteServiceTests()
    {
        _repositoryMock = new Mock<IRouteRepository>();
        _routeService = new RouteService(_repositoryMock.Object);
    }

    [Fact]
    public async Task AddAsync_ShouldAddRouteSuccessfully()
    {
        // Arrange
        var route = new RouteEntity { Id = 1, Origin = "GRU", Destiny = "BRC", Value = 10.0m };
        _repositoryMock.Setup(r => r.AddAsync(It.IsAny<RouteEntity>()))
            .ReturnsAsync(route);

        // Act
        var result = await _routeService.AddAsync(route);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(route.Id, result.Id);
        _repositoryMock.Verify(r => r.AddAsync(It.IsAny<RouteEntity>()), Times.Once);
    }

    [Fact]
    public async Task GetAll_ShouldReturnAllRoutes()
    {
        // Arrange
        var routes = new List<RouteEntity>
        {
            new() { Id = 1, Origin = "GRU", Destiny = "BRC", Value = 10.0m },
            new() { Id = 2, Origin = "BRC", Destiny = "SCL", Value = 5.0m }
        };

        _repositoryMock.Setup(r => r.GetAll())
            .ReturnsAsync(routes);

        // Act
        var result = await _routeService.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        _repositoryMock.Verify(r => r.GetAll(), Times.Once);
    }

    [Fact]
    public async Task GetRote_ShouldReturnCheapestRoute()
    {
        // Arrange
        var routes = new List<RouteEntity>
        {
            new()  { Id = 1, Origin = "GRU", Destiny = "BRC", Value = 10.0m },
            new() { Id = 2, Origin = "BRC", Destiny = "SCL", Value = 5.0m },
            new() { Id = 3, Origin = "GRU", Destiny = "CDG", Value = 75.0m },
            new() { Id = 4, Origin = "GRU", Destiny = "SCL", Value = 20.0m },
            new() { Id = 5, Origin = "GRU", Destiny = "ORL", Value = 56.0m },
            new() { Id = 6, Origin = "ORL", Destiny = "CDG", Value = 5.0m },
            new() { Id = 7, Origin = "SCL", Destiny = "ORL", Value = 20.0m }
        };

        _repositoryMock.Setup(r => r.GetAll())
            .ReturnsAsync(routes);

        // Act
        var result = await _routeService.GetRote("GRU", "CDG");

        
        // Assert
        Assert.NotNull(result);
        Assert.Equal("Melhor rota: GRU - BRC - SCL - ORL - CDG ao custo de $40,00", result);
        _repositoryMock.Verify(r => r.GetAll(), Times.Once);
    }

    [Fact]
    public async Task GetRote_ShouldReturnNoRouteMessage_WhenNoRouteAvailable()
    {
        // Arrange
        var routes = new List<RouteEntity>(); 
        _repositoryMock.Setup(r => r.GetAll())
            .ReturnsAsync(routes);

        // Act
        var result = await _routeService.GetRote("GRU", "CDG");

        // Assert
        Assert.Equal("Nenhuma rota disponível.", result);
        _repositoryMock.Verify(r => r.GetAll(), Times.Once);
    }
}
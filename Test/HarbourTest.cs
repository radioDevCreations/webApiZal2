using Application.Abstractions.Repositories;
using Application.Mappers;
using Application.Models.Harbour;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Services;
using Moq;

public class HarbourServiceTests
{
    private readonly Mock<IHarboursRepository> _mockHarbourRepository;
    private readonly HarbourService _HarbourService;

    public HarbourServiceTests()
    {
        _mockHarbourRepository = new Mock<IHarboursRepository>();

        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new HarbourMapper());
        });
        var mapper = mockMapper.CreateMapper();

        _HarbourService = new HarbourService(_mockHarbourRepository.Object, mapper);
    }

    [Fact]
    public async Task GetAll_ShouldReturnAllHarbours()
    {
        // Arrange
        var harbours = new List<Harbour> { new Harbour { Id = Guid.NewGuid(), Name = "Test", Type = "See Harbour", Street = "Mieszka I", StreetNumber = "6A", City = "Gdañsk", ZipCode = "32444", Country = "Poland" } };
        _mockHarbourRepository.Setup(repo => repo.GetAll(It.IsAny<CancellationToken>())).ReturnsAsync(harbours);

        // Act
        var result = await _HarbourService.GetAll(CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
    }

    [Fact]
    public async Task GetHarbourById_ShouldReturnHarbour()
    {
        // Arrange
        var harbourId = Guid.NewGuid();
        var harbour = new Harbour { Id = harbourId, Name = "Test", Type = "See Harbour", Street = "Mieszka I", StreetNumber = "6A", City = "Gdañsk", ZipCode = "32444", Country = "Poland" };
        _mockHarbourRepository.Setup(repo => repo.GetById(harbourId, It.IsAny<CancellationToken>())).ReturnsAsync(harbour);

        // Act
        var result = await _HarbourService.GetHarbourById(harbourId, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(harbourId, result.Id);
    }

    [Fact]
    public async Task AddHarbour_ShouldAddHarbourAndReturnId()
    {
        // Arrange
        var createHarbour = new CreateHarbour { Name = "Test", City = "TestCity" };
        var harbourEntity = new Harbour { Name = createHarbour.Name, Type = createHarbour.Type, Street = createHarbour.Street, StreetNumber = createHarbour.StreetNumber, City = createHarbour.City, ZipCode = createHarbour.ZipCode, Country = createHarbour.Country };
        _mockHarbourRepository.Setup(repo => repo.AddHarbour(harbourEntity, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        // Act
        var result = await _HarbourService.AddHarbour(createHarbour, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task UpdateHarbour_ShouldUpdateHarbour()
    {
        // Arrange
        var updateHarbour = new UpdateHarbour { Id = Guid.NewGuid(), Name = "Test", Type = "See Harbour", Street = "Mieszka I", StreetNumber = "6A", City = "Gdañsk", ZipCode = "32444", Country = "Poland" };
        var harbourEntity = new Harbour { Id = updateHarbour.Id, Name = "Test1", Type = "See Harbour1", Street = "Mieszka I1", StreetNumber = "6A1", City = "Gdañsk1", ZipCode = "32441", Country = "Poland1" };
        _mockHarbourRepository.Setup(repo => repo.GetById(updateHarbour.Id, It.IsAny<CancellationToken>())).ReturnsAsync(harbourEntity);
        _mockHarbourRepository.Setup(repo => repo.UpdateHarbour(harbourEntity, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        // Act
        var result = await _HarbourService.UpdateHarbour(updateHarbour, CancellationToken.None);

        // Assert
        Assert.Equal(updateHarbour.Id, result);
        Assert.Equal(updateHarbour.Name, harbourEntity.Name);
        Assert.Equal(updateHarbour.Type, harbourEntity.Type);
        Assert.Equal(updateHarbour.Street, harbourEntity.Street);
        Assert.Equal(updateHarbour.StreetNumber, harbourEntity.StreetNumber);
        Assert.Equal(updateHarbour.City, harbourEntity.City);
        Assert.Equal(updateHarbour.ZipCode, harbourEntity.ZipCode);
        Assert.Equal(updateHarbour.Country, harbourEntity.Country);

    }

    [Fact]
    public async Task RemoveHarbour_ShouldRemoveHarbour()
    {
        // Arrange
        var harbourId = Guid.NewGuid();
        var harbourEntity = new Harbour { Id = harbourId, Name = "Test", Type = "See Harbour", Street = "Mieszka I", StreetNumber = "6A", City = "Gdañsk", ZipCode = "32444", Country = "Poland" };
        _mockHarbourRepository.Setup(repo => repo.GetById(harbourId, It.IsAny<CancellationToken>())).ReturnsAsync(harbourEntity);
        _mockHarbourRepository.Setup(repo => repo.RemoveHarbour(harbourEntity, It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        // Act
        var result = await _HarbourService.RemoveHarbour(harbourId, CancellationToken.None);

        // Assert
        Assert.Equal(harbourId, result);
    }
}

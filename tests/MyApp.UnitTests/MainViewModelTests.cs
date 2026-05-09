using Moq;
using MyApp.Application.Interfaces;
using MyApp.Domain;
using Microsoft.Extensions.Logging.Abstractions;
using MyApp.Application.ViewModels;

public class MainViewModelTests
{
    [Fact]
    public async Task Load_ShouldSetUserName()
    {
        var mock = new Mock<IDataService>();
        mock.Setup(x => x.GetUserAsync())
            .ReturnsAsync(new User { Name = "TestUser" });

        var vm = new MainViewModel(mock.Object, NullLogger<MainViewModel>.Instance);

        await vm.Load();

        Assert.Equal("TestUser", vm.UserName);
    }
}
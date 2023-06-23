using WMS.Models;
using WMS.Services.Interfaces;
using WMS.ViewModels.Products;
using Moq;
using Location = WMS.Models.Location;

namespace WMS.Tests;

public class TransferStockViewModelTests
{
    [Fact]
    public async Task TestTransferStockInvalidSubmission()
    {
        var notificationServiceMock = new Mock<INotificationService>();
        var productServiceMock = new Mock<IProductService>();
        var transferStockViewModel = new TransferStockViewModel(
            productServiceMock.Object,
            notificationServiceMock.Object
        );

        transferStockViewModel.MoveStock();

        productServiceMock.VerifyNoOtherCalls();
        notificationServiceMock.Verify(
            n => n.DisplayAlert(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())
        );
    }

    [Fact]
    public async Task TestTransferStockNoQuantitySubmission()
    {
        var notificationServiceMock = new Mock<INotificationService>();
        var productServiceMock = new Mock<IProductService>();
        var transferStockViewModel = new TransferStockViewModel(
            productServiceMock.Object,
            notificationServiceMock.Object
        );

        transferStockViewModel.Product = new Product()
        {
            Name = "Foo",
            ProductLocations = new List<ProductLocation>()
            {
                new()
                {
                    Id = 1,
                    Location = new Location() { Name = "New Location" }
                }
            }
        };

        transferStockViewModel.OldProductLocation = transferStockViewModel.Product.ProductLocations[
            0
        ];
        transferStockViewModel.MoveStock();

        productServiceMock.VerifyNoOtherCalls();
        notificationServiceMock.Verify(
            n =>
                n.DisplayAlert(
                    It.IsAny<string>(),
                    "Er moet een te verplaatsen hoeveelheid ingevuld zijn! Deze kan niet 0 zijn.",
                    It.IsAny<string>()
                )
        );
    }

    [Fact]
    public async Task TestTransferStockValidSubmission()
    {
        var notificationServiceMock = new Mock<INotificationService>();
        var productServiceMock = new Mock<IProductService>();
        var transferStockViewModel = new TransferStockViewModel(
            productServiceMock.Object,
            notificationServiceMock.Object
        );

        productServiceMock
            .Setup(
                p =>
                    p.MoveStock(
                        It.IsAny<Product>(),
                        It.IsAny<int>(),
                        It.IsAny<Location>(),
                        It.IsAny<ProductLocation>()
                    )
            )
            .ReturnsAsync(true);

        transferStockViewModel.Product = new Product()
        {
            Name = "Foo",
            ProductLocations = new List<ProductLocation>()
            {
                new()
                {
                    Id = 1,
                    Stock = 100,
                    Location = new Location() { Name = "New Location" }
                }
            }
        };
        transferStockViewModel.QuantityToMove = 1;
        transferStockViewModel.NewLocation = new Location() { Id = 1, Name = "foo" };
        transferStockViewModel.SelectedWarehouse = new Warehouse() { Name = "The Destined" };
        transferStockViewModel.OldProductLocation = transferStockViewModel.Product.ProductLocations[
            0
        ];
        transferStockViewModel.MoveStock();

        productServiceMock.Verify(
            p =>
                p.MoveStock(
                    transferStockViewModel.Product,
                    transferStockViewModel.QuantityToMove,
                    transferStockViewModel.NewLocation,
                    transferStockViewModel.OldProductLocation
                )
        );
    }
}

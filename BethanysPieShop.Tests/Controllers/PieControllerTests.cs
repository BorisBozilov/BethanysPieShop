using BethanysPieShop.Controllers;
using BethanysPieShop.Tests.Mocks;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Xunit;

namespace BethanysPieShop.Tests.Controllers;
public class PieControllerTests
{
    [Fact]
    public void List_EmptyCategory_ReturnsAllPies()
    {
        //arrange
        var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
        var mockPieRepository = RepositoryMocks.GetPieRepository();

        var pieController = new PieController(mockPieRepository.Object, mockCategoryRepository.Object);

        //act
        var result = pieController.List("");

        //assert
        var viewResult = Assert.IsType<ViewResult>(result);
        var pieListViewModel = Assert.IsAssignableFrom<PieListViewModel>(viewResult.ViewData.Model);
        Assert.Equal(10, pieListViewModel.Pies.Count());
    }
}
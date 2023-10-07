using Microsoft.AspNetCore.Mvc;
using Moq;
using ShoppingWebApp.Controllers;
using ShoppingWebApp.ViewModels;
using ShoppingWebAppTest.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingWebAppTest.PieControllers
{
    public class PieControllerTest
    {
        [Fact]
        public void List_EmptyCategory_ReturnAllPies()
        {
            //Arrange
            var mockPieRepository = RepositoryMock.GetRepository();
            var mockCategoryRepository = RepositoryMock.GetCategoryRepository();

            var pieController = new PieController(mockPieRepository.Object, mockCategoryRepository.Object);

            //Act
            var result = pieController.List("");

            //Assert

            var viewResult = Assert.IsType<ViewResult>(result);
            var pieListViewModel = Assert.IsAssignableFrom<PieListViewModel>(viewResult.ViewData.Model);
            Assert.Equal(10, pieListViewModel.Pies.Count());
        }
    }
}

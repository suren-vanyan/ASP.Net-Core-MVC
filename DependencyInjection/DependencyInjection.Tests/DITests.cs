using DependencyInjection.Controllers;
using DependencyInjection.Infrastructure;
using DependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using Xunit;

namespace DependencyInjection.Tests
{
    public class DITests
    {
        [Fact]
        public void ControllerTest()
        {
            var data = new[] { new Product { Name = "Test", Price = 100 } };
            var mock = new Mock<IRepository>();
                mock.SetupGet(m => m.Products).Returns(data);
            TypeBroker.SetTestObject(mock.Object);
            HomeController homeController = new HomeController();
            homeController.Repository = mock.Object;
            ViewResult result = homeController.Index();
            Assert.Equal(data, result.ViewData.Model);
        }
    }
}

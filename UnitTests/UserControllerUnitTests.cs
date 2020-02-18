using BusinessLayer.Services;
using ExpensesTracker.Controllers;
using ExpensesTracker.ExceptionHandler;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Moq;
using SharedDTO.Models;

namespace UnitTests
{
    public class UserControllerUnitTests
    {
        
        //[Fact]
        //public void AuthenticateUser()
        //{
        //  var user=  new UserModel { UserName="mock user",Password="12345"};
        //    //Arrange
        //    string userName = "tanvi";
        //    string password = "123456789";
        //    var mockRepo = new Mock<IUserRepository>();
        //    mockRepo.Setup(repo => repo.AuthenticateUserAsync(userName, password))
        //        .ReturnsAsync(userName);
           
        //    var mockExceptionREpo = new Mock<IExceptionHandler>();
        //    var controller = new UserController(mockRepo.Object, mockExceptionREpo.Object);

        //    // Act
        //    var okResult = controller.AuthenticateUser(userName, password).Result;

        //    // Assert

        //    Assert.IsType<OkObjectResult>(okResult);
        //}

        //[Fact]
        //public void CreateUser()
        //{
        //    //Arrange
        //    var user = new UserModel { UserName = "mock user", Password = "12345" };
            
        //    var mockRepo = new Mock<IUserRepository>();
        //    mockRepo.Setup(repo => repo.CreatedUserAsync(user))
        //        .ReturnsAsync(user);
        //    var mockExceptionREpo = new Mock<IExceptionHandler>();
        //    var controller = new UserController(mockRepo.Object, mockExceptionREpo.Object);

        //    // Act
        //    var okResult = controller.CreateUser(user).Result;

        //    // Assert

        //    Assert.IsType<CreatedResult>(okResult); 
        //}

        //[Fact]
        //public void DeleteUser()
        //{
        //    Guid userId = Guid.Parse("9245fe4a-d402-451c-b9ed-9c1a04247482");

        //    var mockRepo = new Mock<IUserRepository>();
            
        //    mockRepo.Setup(repo => repo.DeleteUserAsync(userId))
        //       .ReturnsAsync(true);
        //    var mockExceptionREpo = new Mock<IExceptionHandler>();
        //    var controller = new UserController(mockRepo.Object, mockExceptionREpo.Object);
           

        //    // Act
        //    var okResult = controller.DeleteUser(userId).Result;

        //    // Assert

        //    Assert.IsType<OkObjectResult>(okResult);
        //}
    }
}

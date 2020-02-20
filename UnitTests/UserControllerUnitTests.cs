using ExpensesTracker.Controllers;
using ExpensesTracker.ExceptionHandler;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;
using Moq;
using System.Net.Http;
using ExpensesTracker.ViewModels;
using BusinessLayer.Services;
using AutoMapper;
using SharedDTOs.DTOs;
using System.Net.Http.Headers;

namespace UnitTests
{
    public class UserControllerUnitTests
    {

        [Fact]
        public void AuthenticateUser()
        {
            UserViewModel user = new UserViewModel { UserName = "mock user", Password = "12345" };
            UserDTO userDTO = new UserDTO { UserName = "mock user", Password = "12345" };
            string userName = "tanvi";
            string password = "123456789";
            var mockRepo = new Mock<IUserService>();
            mockRepo.Setup(repo => repo.AuthenticateUserAsync(userName, password))
                .ReturnsAsync(userDTO);
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(repo => repo.Map(user, userDTO))
                .Returns(userDTO);


            var mockExceptionREpo = new Mock<IExceptionHandler>();
            var controller = new UserController(mockRepo.Object, mockExceptionREpo.Object, mockMapper.Object);

            // Act
            var okResult = controller.AuthenticateUser(userName, password).Result;

            // Assert

            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void CreateUser()
        {
           
            var user = new UserViewModel { UserName = "mock user", Password = "12345" };
            UserDTO userDTO = new UserDTO { UserName = "mock user", Password = "12345" };
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(repo => repo.Map(user, userDTO))
                .Returns(userDTO);
            mockMapper.Setup(repo => repo.Map(userDTO, user))
               .Returns(user);

            var mockRepo = new Mock<IUserService>();
            mockRepo.Setup(repo => repo.CreatedUserAsync(userDTO))
                .ReturnsAsync(userDTO);
            var mockExceptionREpo = new Mock<IExceptionHandler>();
            var controller = new UserController(mockRepo.Object, mockExceptionREpo.Object, mockMapper.Object);

           // Act
           var okResult = controller.CreateUser(user).Result;

            //Assert

            Assert.IsType<CreatedResult>(okResult);
        }

        [Fact]
        public void DeleteUser()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjQ4MDZhYWVmLTJmNjctNGY3Yy0yYjdiLTA4ZDdiNTE3MGEzMyIsIm5iZiI6MTU4MjEwMTQ4NywiZXhwIjoxNTgyMTA0MTg3LCJpYXQiOjE1ODIxMDE0ODd9.m-zrNriR1RqSF6pchSBbQ_noiIaNeVSfmixUgyrFqik");

            int userId = 1;

            var mockRepo = new Mock<IUserService>();

            mockRepo.Setup(repo => repo.DeleteUserAsync(userId))
               .ReturnsAsync(true);
            var mockMapper = new Mock<IMapper>();

            var mockExceptionREpo = new Mock<IExceptionHandler>();
            var controller = new UserController(mockRepo.Object, mockExceptionREpo.Object, mockMapper.Object);

            // Act
            var okResult = controller.DeleteUser(userId).Result;

            // Assert

            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}

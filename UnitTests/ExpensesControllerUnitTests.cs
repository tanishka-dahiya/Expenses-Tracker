using AutoMapper;
using BusinessLayer.Services;
using ExpensesTracker.Controllers;
using ExpensesTracker.ExceptionHandler;
using ExpensesTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SharedDTO.DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Xunit;

namespace UnitTests
{
    public class ExpensesControllerUnitTests
    {
        [Fact]
        public void GetExpenses()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjQ4MDZhYWVmLTJmNjctNGY3Yy0yYjdiLTA4ZDdiNTE3MGEzMyIsIm5iZiI6MTU4MjEwMTQ4NywiZXhwIjoxNTgyMTA0MTg3LCJpYXQiOjE1ODIxMDE0ODd9.m-zrNriR1RqSF6pchSBbQ_noiIaNeVSfmixUgyrFqik");
            var expense = new ExpensesViewModel { Title = "mock Expenses", Price = 20 };
            var expenseDTO = new ExpensesDTO { Title = "mock Expenses", Price = 20 };
            int userId = 1;
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(repo => repo.Map(expense, expenseDTO))
                .Returns(expenseDTO);
            mockMapper.Setup(repo => repo.Map(expenseDTO, expense))
               .Returns(expense);

            List<ExpensesDTO> expensesList = new List<ExpensesDTO>();
            var mockRepo = new Mock<IExpensesService>();
            mockRepo.Setup(repo => repo.GetExpensesAsync(userId))
                .ReturnsAsync(expensesList);

            var mockExceptionREpo = new Mock<IExceptionHandler>();
            var controller = new ExpensesController(mockRepo.Object, mockExceptionREpo.Object, mockMapper.Object);

            // Act
            var okResult = controller.GetExpenses(userId).Result;

            // Assert

            Assert.IsType<OkObjectResult>(okResult);
        }


        [Fact]
        public void GetExpenseById()
        {
            int userId = 1;
            int expenseId = 2;

            var expense = new ExpensesViewModel { Title = "mock Expenses", Price = 20 };
            var expenseDTO = new ExpensesDTO { Title = "mock Expenses", Price = 20 };
            var mockRepo = new Mock<IExpensesService>();
            mockRepo.Setup(repo => repo.GetExpenseByIdAsync(expenseId, userId))
                .ReturnsAsync(expenseDTO);

            var mockExceptionREpo = new Mock<IExceptionHandler>();
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(repo => repo.Map(expense, expenseDTO))
                .Returns(expenseDTO);
            mockMapper.Setup(repo => repo.Map(expenseDTO, expense))
               .Returns(expense);
            var controller = new ExpensesController(mockRepo.Object, mockExceptionREpo.Object, mockMapper.Object);

            // Act
            var okResult = controller.GetExpenseById(expenseId, userId).Result;

            // Assert

            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void DeleteExpenseById()
        {
            int userId = 1;
            int expenseId = 2;

            var expense = new ExpensesViewModel { Title = "mock Expenses", Price = 20 };
            var expenseDTO = new ExpensesDTO { Title = "mock Expenses", Price = 20 };
            var mockRepo = new Mock<IExpensesService>();
            mockRepo.Setup(repo => repo.DeleteExpenseByIdAsync(expenseId, userId))
                .ReturnsAsync(true);
            var mockMapper = new Mock<IMapper>();

            var mockExceptionREpo = new Mock<IExceptionHandler>();
            var controller = new ExpensesController(mockRepo.Object, mockExceptionREpo.Object, mockMapper.Object);

            // Act
            var okResult = controller.DeleteExpenseById(expenseId, userId).Result;

            // Assert

            Assert.IsType<OkObjectResult>(okResult);

        }
        [Fact]
        public void EditExpenseById()
        {
            int userId = 1;
            var expense = new ExpensesViewModel { Title = "mock Expenses", Price = 20 };
            var expenseDTO = new ExpensesDTO { Title = "mock Expenses", Price = 20 };
            var mockRepo = new Mock<IExpensesService>();
            mockRepo.Setup(repo => repo.EditExpenseByIdAsync(expenseDTO))
                .ReturnsAsync(expenseDTO);
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(repo => repo.Map(expense, expenseDTO))
                .Returns(expenseDTO);
            mockMapper.Setup(repo => repo.Map(expenseDTO, expense))
               .Returns(expense);
            var mockExceptionREpo = new Mock<IExceptionHandler>();
            var controller = new ExpensesController(mockRepo.Object, mockExceptionREpo.Object, mockMapper.Object);

            // Act
            var okResult = controller.EditExpenseById(userId, expense).Result;

            // Assert

            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void GetExpensesAmount()
        {

            int userId = 1;
            float amount = 30;
            var mockRepo = new Mock<IExpensesService>();
            mockRepo.Setup(repo => repo.GetExpensesAmountAsync(userId))
                .ReturnsAsync(amount);

            var mockExceptionREpo = new Mock<IExceptionHandler>();
            var mockMapper = new Mock<IMapper>();
            var controller = new ExpensesController(mockRepo.Object, mockExceptionREpo.Object, mockMapper.Object);

            // Act
            var okResult = controller.GetExpensesAmount(userId).Result;

            // Assert

            Assert.IsType<OkObjectResult>(okResult);
        }
    }
}

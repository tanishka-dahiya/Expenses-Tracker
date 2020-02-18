using BusinessLayer.Services;
using ExpensesTracker.Controllers;
using ExpensesTracker.ExceptionHandler;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SharedDTO.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class ExpensesControllerUnitTests
    {
        //[Fact]
        //public void GetExpenses()
        //{
        //    Guid userId = Guid.Parse("9245fe4a-d402-451c-b9ed-9c1a04247482");
          
        //    List<ExpensesModel> expensesList = new List<ExpensesModel>();
        //    var mockRepo = new Mock<IExpensesRepository>();
        //    mockRepo.Setup(repo => repo.GetExpensesAsync(userId))
        //        .ReturnsAsync(expensesList);

        //    var mockExceptionREpo = new Mock<IExceptionHandler>();
        //    var controller = new ExpensesController(mockRepo.Object, mockExceptionREpo.Object);

        //    // Act
        //    var okResult = controller.GetExpenses(userId).Result;

        //    // Assert

        //    Assert.IsType<OkObjectResult>(okResult);
        //}
        //[Fact]
        //public void CreateExpense()
        //{
        //    Guid userId = Guid.Parse("9245fe4a-d402-451c-b9ed-9c1a04247482");

        //    var expense = new ExpensesModel { Title = "mock Expenses" , Price =20};
        //    var mockRepo = new Mock<IExpensesRepository>();
        //    mockRepo.Setup(repo => repo.CreateExpenseAsync(expense))
        //        .ReturnsAsync(expense);

        //    var mockExceptionREpo = new Mock<IExceptionHandler>();
        //    var controller = new ExpensesController(mockRepo.Object, mockExceptionREpo.Object);

        //    // Act
        //    var okResult = controller.CreateExpense(expense,userId).Result;

        //    // Assert

        //    Assert.IsType<CreatedAtActionResult>(okResult);
        //}

        //[Fact]
        //public void GetExpenseById()
        //{
        //    Guid userId = Guid.Parse("9245fe4a-d402-451c-b9ed-9c1a04247482");
        //    Guid expenseId = Guid.Parse("9245fe4a-d402-451c-b9ed-9c1a04247482");


        //    var expense = new ExpensesModel { Title = "mock Expenses", Price = 20 };
        //    var mockRepo = new Mock<IExpensesRepository>();
        //    mockRepo.Setup(repo => repo.GetExpenseByIdAsync(expenseId,userId))
        //        .ReturnsAsync(expense);

        //    var mockExceptionREpo = new Mock<IExceptionHandler>();
        //    var controller = new ExpensesController(mockRepo.Object, mockExceptionREpo.Object);

        //    // Act
        //    var okResult = controller.GetExpenseById(expenseId, userId).Result;

        //    // Assert

        //    Assert.IsType<OkObjectResult>(okResult);
        //}

        //[Fact]
        //public void DeleteExpenseById()
        //{
        //    Guid userId = Guid.Parse("9245fe4a-d402-451c-b9ed-9c1a04247482");
        //    Guid expenseId = Guid.Parse("9245fe4a-d402-451c-b9ed-9c1a04247482");
        //    var mockRepo = new Mock<IExpensesRepository>();
        //    mockRepo.Setup(repo => repo.DeleteExpenseByIdAsync(expenseId, userId))
        //        .ReturnsAsync(true);

        //    var mockExceptionREpo = new Mock<IExceptionHandler>();
        //    var controller = new ExpensesController(mockRepo.Object, mockExceptionREpo.Object);

        //    // Act
        //    var okResult = controller.DeleteExpenseById(expenseId, userId).Result;

        //    // Assert

        //    Assert.IsType<OkObjectResult>(okResult);
        //}
        //[Fact]
        //public void EditExpenseById()
        //{
        //    Guid userId = Guid.Parse("9245fe4a-d402-451c-b9ed-9c1a04247482");
        //    Guid expenseId = Guid.Parse("9245fe4a-d402-451c-b9ed-9c1a04247482");
        //    var expense = new ExpensesModel { Title = "mock Expenses", Price = 20 };
        //    var mockRepo = new Mock<IExpensesRepository>();
        //    mockRepo.Setup(repo => repo.EditExpenseByIdAsync(expense))
        //        .ReturnsAsync(expense);

        //    var mockExceptionREpo = new Mock<IExceptionHandler>();
        //    var controller = new ExpensesController(mockRepo.Object, mockExceptionREpo.Object);

        //    // Act
        //    var okResult = controller.EditExpenseById(expense, userId).Result;

        //    // Assert

        //    Assert.IsType<OkObjectResult>(okResult);
        //}

        //[Fact]
        //public void GetExpensesAmount()
        //{
        //    Guid userId = Guid.Parse("9245fe4a-d402-451c-b9ed-9c1a04247482");
        //    float amount = 30;
        //    var mockRepo = new Mock<IExpensesRepository>();
        //    mockRepo.Setup(repo => repo.GetExpensesAmountAsync(userId))
        //        .ReturnsAsync(amount);

        //    var mockExceptionREpo = new Mock<IExceptionHandler>();
        //    var controller = new ExpensesController(mockRepo.Object, mockExceptionREpo.Object);

        //    // Act
        //    var okResult = controller.GetExpensesAmount( userId).Result;

        //    // Assert

        //    Assert.IsType<OkObjectResult>(okResult);
        //}
    }
}

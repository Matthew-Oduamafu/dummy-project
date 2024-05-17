
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;
// using Moq;
// using ShopkeeperProject.Data;
// using ShopkeeperProject.Domain.Entities;
// using ShopkeeperProject.Interfaces;
// using ShopkeeperProject.Repository;
// using Xunit;

// namespace ShopkeeperProject.UnitTests.Repository
// {
//     public class CustomerRepositoryTests
//     {
//         public object MockDbSet { get; private set; }

//         [Fact]
//         public async Task GetCustomers_ReturnsAllCustomers()
//         {
//             // Arrange
//             var testData = new List<Customer>
//             {
//                 new Customer { Id = Guid.NewGuid(), Name = "Customer 1" },
//                 new Customer { Id = Guid.NewGuid(), Name = "Customer 2" }
//             }.AsQueryable();

//             var mockDbContext = new Mock<ApplicationDbContext>();
//             var mockDbSet = new Mock<DbSet<Customer>>(MockBehavior.Strict);
//             mockDbSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(testData.Provider);
//             mockDbSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(testData.Expression);
//             mockDbSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(testData.ElementType);
//             mockDbSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(testData.GetEnumerator());

//             mockDbContext.Setup(c => c.Customers).Returns(mockDbSet.Object);
//         }

//         [Fact]
//         public async Task GetCustomerById_ReturnsCustomer()
//         {
//             // Arrange
//             var testCustomerId = Guid.NewGuid();
//             var testData = new Customer { Id = testCustomerId, Name = "Test Customer" };

//             var mockDbSet = new Mock<DbSet<Customer>>();
//             mockDbSet.Setup(c => c.FindAsync(testCustomerId)).ReturnsAsync(testData);

//             var mockDbContext = new Mock<ApplicationDbContext>();
//             mockDbContext.Setup(c => c.Customers).Returns(mockDbSet.Object);

//             var repository = new CustomerRepository(mockDbContext.Object);

//             // Act
//             var result = await repository.GetCustomerById(testCustomerId);

//             // Assert
//             Assert.NotNull(result);
//             Assert.Equal(testData, result);
//         }

//         [Fact]
//         public async Task CreateCustomer_AddsCustomerToDatabase()
//         {
//             // Arrange
//             var mockDbContext = new Mock<ApplicationDbContext>();
//             var repository = new CustomerRepository(mockDbContext.Object);

//             var newCustomer = new Customer { Id = Guid.NewGuid(), Name = "New Customer" };

//             // Act
//             await repository.CreateCustomer(newCustomer);

//             // Assert
//             mockDbContext.Verify(c => c.Customers.AddAsync(newCustomer, It.IsAny<CancellationToken>()), Times.Once);
//             mockDbContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
//         }

//         [Fact]
//         public async Task UpdateCustomer_UpdatesCustomerInDatabase()
//         {
//             // Arrange
//             var mockDbContext = new Mock<ApplicationDbContext>();
//             var repository = new CustomerRepository(mockDbContext.Object);

//             var existingCustomer = new Customer { Id = Guid.NewGuid(), Name = "Existing Customer" };

//             // Act
//             await repository.UpdateCustomer(existingCustomer);

//             // Assert
//             mockDbContext.Verify(c => c.Customers.Update(existingCustomer), Times.Once);
//             mockDbContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
//         }

//         [Fact]
//         public async Task DeleteCustomer_RemovesCustomerFromDatabase()
//         {
//             // Arrange
//             var testCustomerId = Guid.NewGuid();
//             var existingCustomer = new Customer { Id = testCustomerId, Name = "Existing Customer" };

//             var mockDbSet = new Mock<DbSet<Customer>>();
//             mockDbSet.Setup(c => c.FindAsync(testCustomerId)).ReturnsAsync(existingCustomer);

//             var mockDbContext = new Mock<ApplicationDbContext>();
//             mockDbContext.Setup(c => c.Customers).Returns(mockDbSet.Object);

//             var repository = new CustomerRepository(mockDbContext.Object);

//             // Act
//             await repository.DeleteCustomer(testCustomerId);

//             // Assert
//             mockDbContext.Verify(c => c.Customers.Remove(existingCustomer), Times.Once);
//             mockDbContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);

//         }
//     }
// }

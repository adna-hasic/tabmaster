using Market.Application.Modules.Cafe.Tables.Commands.Create;
using Market.Application.Common.Exceptions;
using Market.Domain.Entities.Cafe;
using System;
using System.Collections.Generic;
using System.Text;

namespace Market.Tests.TableTests.UnitTests
{
    public class TableUnitTests
    {
        private DatabaseContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())// Each test gets a new database
                .Options;

            var fakeClock = new Microsoft.Extensions.Time.Testing.FakeTimeProvider();

            return new DatabaseContext(options, fakeClock);
        }

        [Fact]
        public async Task Handle_DuplicateTableNumber_ShouldThrowConflict()
        {
            // Arrange
            using var context = GetInMemoryDbContext();

            context.CafeTables.Add(new CafeTableEntity
            {
                TableNumber = 5,
                IsEnabled = true
            });
            await context.SaveChangesAsync(CancellationToken.None);

            var handler = new CreateTableCommandHandler(context);
            var command = new CreateTableCommand { TableNumber = 5 };

            // Act and Assert
            await Assert.ThrowsAsync<MarketConflictException>(
                () => handler.Handle(command, CancellationToken.None));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Validate_InvalidTableNumber_ShouldFail(int tableNumber)
        {
            // Arrange
            var validator = new CreateTableCommandValidator();
            var command = new CreateTableCommand
            {
                TableNumber = tableNumber
            };

            // Act
            var result = validator.Validate(command);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors,
                error => error.PropertyName == nameof(CreateTableCommand.TableNumber));
        }
    }
}

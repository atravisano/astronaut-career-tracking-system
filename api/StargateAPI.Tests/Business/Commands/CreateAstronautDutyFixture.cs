using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using StargateAPI.Business.Commands;
using StargateAPI.Business.Data;
using System.Data.Common;

namespace StargateAPI.Tests.Business.Commands
{
    public class CreateAstronautDutyFixture : IDisposable
    {
        private readonly DbConnection _connection;
        private readonly DbContextOptions<StargateContext> _contextOptions;

        public CreateAstronautDutyFixture()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _contextOptions = new DbContextOptionsBuilder<StargateContext>()
                .UseSqlite(_connection)
                .Options;

            using var context = CreateContext();
            context.Database.EnsureCreated();
        }

        [Fact]
        public async void Process_NoPeople_ShouldThrowException()
        {
            // Arrange
            using var context = CreateContext();
            var preprocessor = CreatePreProcessor(context);
            var request = new CreateAstronautDuty
            {
                Name = "unit test name",
                DutyTitle = "unit test duty title",
                Rank = "unit test rank"
            };

            // Act
            var action = () => preprocessor.Process(request, new CancellationToken());

            // Assert
            var result = await Assert.ThrowsAsync<BadHttpRequestException>(action);
            Assert.Equal("Bad Request", result.Message);
        }

        public void Dispose()
        {
            _connection.Dispose();
            GC.SuppressFinalize(this);
        }

        private StargateContext CreateContext()
        {
            return new(_contextOptions);
        }

        private CreateAstronautDutyPreProcessor CreatePreProcessor(StargateContext context)
        {
            return new CreateAstronautDutyPreProcessor(context);
        }
    }

}

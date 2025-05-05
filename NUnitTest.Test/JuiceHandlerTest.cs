using Moq; // For mocking
using NUnitTest.Handlers;
using NUnitTest.Interfaces;
using NUnitTest.Models;

namespace NUnitTest.Test
{
    [TestFixture]
    internal class JuiceHandlerTest
    {
        private IJuiceHandler _juiceHandler;

        [SetUp]
        public void Setup()
        {
            _juiceHandler = new JuiceHandler();
        }

        [Test]
        public void GetNoOfPeople_TotalPeopleGreaterThanNotInterested_Positive()
        {
            // Arrange
            Order order = new() { NoOfPeople = 100, NoOfPeopleNotInterested = 50 };

            // Act
            _juiceHandler.CreateNewJuice(order);
            var original = _juiceHandler.GetJuice();

            // Assert
            Assert.That(original.NoOfFruits, Is.EqualTo(100));
        }

        [Test]
        public void CreateNewJuice_UsingMock_VerifyMethodCall()
        {
            // Arrange
            var mockHandler = new Mock<IJuiceHandler>();
            Order order = new() { NoOfPeople = 100, NoOfPeopleNotInterested = 50 };

            // Act
            mockHandler.Object.CreateNewJuice(order);

            // Assert
            mockHandler.Verify(j => j.CreateNewJuice(order), Times.Once, "CreateNewJuice was not called exactly once.");
        }

        [Test]
        public void GetJuice_UsingStub_ReturnsPredefinedJuice()
        {
            // Arrange
            var stubHandler = new StubJuiceHandler();
            Order order = new() { NoOfPeople = 100, NoOfPeopleNotInterested = 50 };

            // Act
            stubHandler.CreateNewJuice(order);
            var result = stubHandler.GetJuice();

            // Assert
            Assert.That(result.NoOfFruits, Is.EqualTo(100));
        }

        [Test]
        public void CreateNewJuice_UsingFake_ValidatesJuiceCreation()
        {
            // Arrange
            var fakeHandler = new FakeJuiceHandler();
            Order order = new() { NoOfPeople = 100, NoOfPeopleNotInterested = 50 };

            // Act
            fakeHandler.CreateNewJuice(order);
            var result = fakeHandler.GetJuice();

            // Assert
            Assert.That(result.NoOfFruits, Is.EqualTo(100));
        }
    }

    // Stub implementation
    internal class StubJuiceHandler : IJuiceHandler
    {
        private Juice _juice = new Juice();

        public void CreateNewJuice(Order order)
        {
            _juice.NoOfFruits = 100; // Predefined response
        }

        public Juice GetJuice()
        {
            return _juice;
        }
    }

    // Fake implementation
    internal class FakeJuiceHandler : IJuiceHandler
    {
        private Juice _juice;

        public void CreateNewJuice(Order order)
        {
            _juice = new Juice
            {
                NoOfFruits = order.NoOfPeople - order.NoOfPeopleNotInterested
            };
        }

        public Juice GetJuice()
        {
            return _juice;
        }
    }
}

using NUnitTest.Handlers;
using NUnitTest.Interfaces;
using NUnitTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTest.Test
{
    [TestFixture]
    internal class JuiceHandlerTest
    {
        private IJuiceHandler _juiceHandler;

        [SetUp]
        public void Setup()
        {
            _juiceHandler=new JuiceHandler();
        }

        [Test]
        public void GetNoOfPeople_TotalPeopleGreaterThanNotInterested_Positive()
        {
            // Arrange
            Order order = new Order { NoOfPeople = 100, NoOfPeopleNotInterested = 50 };

            // Act
            _juiceHandler.CreateNewJuice(order);
            var original = _juiceHandler.GetJuice();

            // Assert
            Assert.That(original.NoOfFruits, Is.EqualTo(100));
        }
    }
}

using System;
using Future3.Models;
using Future3.Services;
using NUnit.Framework;

namespace Future3.Tests
{
    [TestFixture]
    public class TimeMachineServiceTests
    {
        private TimeMachineService _service;

        [SetUp]
        public void Before()
        {
            _service = new TimeMachineService();
        }

        [Test]
        public void ShouldSendOneEmail()
        {
            TimeMachineService.Requests.Add(new EmailSendModel
                {
                    Email = "pawel.olesiejuk@goyello.com",
                    Content = "Hello Pawel!",
                    Date = DateTime.Now.Subtract(TimeSpan.FromMinutes(1))
                });

            _service.SingleRun();
        }
    }
}
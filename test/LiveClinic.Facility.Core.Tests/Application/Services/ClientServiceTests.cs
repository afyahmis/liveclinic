using System;
using System.Collections.Generic;
using System.Linq;
using LiveClinic.ClinicManager.Core.Application.Services;
using LiveClinic.ClinicManager.Core.Domain.Clients;
using LiveClinic.ClinicManager.Core.Tests.TestArtifacts;
using LiveClinic.SharedKernel.Common;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Serilog;

namespace LiveClinic.ClinicManager.Core.Tests.Application.Services
{
    [TestFixture]
    public class ClientServiceTests
    {
        private IClientService _clientService;
        private List<Client> _clients;

        [OneTimeSetUp]
        public void Init()
        {
            _clients = TestData.GetTestClients();
            TestInitializer.ClearDb();
            TestInitializer.SeedData(_clients);
        }

        [SetUp]
        public void SetUp()
        {
            _clientService = TestInitializer.ServiceProvider.GetService<IClientService>();
        }

        [Test]
        public void should_Load_Client()
        {
            var result = _clientService.LoadClient(_clients.First().Id).Result;
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);

            Log.Debug(result.Value.ToString());
        }

        [Test]
        public void should_Load_Clients()
        {
            var result = _clientService.LoadClients().Result;
            Assert.True(result.IsSuccess);
            Assert.True(result.Value.Any());

            foreach (var client in result.Value)
                Log.Debug(client.ToString());
        }

        [Test]
        public void should_Enroll_Client()
        {
            var client = new Client(DateTime.Now, "H101-30",
                "Charlie", "", "Shark", "77 Street X", "NM City",
                DateTime.Now.AddYears(-34), "M");

            var result = _clientService.EnrollClient(client).Result;
            Assert.True(result.IsSuccess);
        }

        [Test]
        public void should_Remove_Client()
        {
            var clientId = _clients.Last().Id;
            var result = _clientService.RemoveClient(clientId).Result;
            Assert.True(result.IsSuccess);

            var voidClient = _clientService.LoadClient(clientId).Result;
            Assert.True(voidClient.IsSuccess);
            Assert.True(voidClient.Value.Voided);
        }

        [Test]
        public void should_Change_Client_Details()
        {
            var clientId = _clients.First().Id;
            var result = _clientService.ChangeClientDetails(clientId,DateTime.Now,"Jane", "A", "Doe", "555 Street X", "J City",DateTime.Now.AddYears(-44), "F").Result;
            Assert.True(result.IsSuccess);

            var updateClient = _clientService.LoadClient(clientId).Result;
            Assert.True(updateClient.IsSuccess);
            Assert.AreEqual(new PersonName("Jane", "A", "Doe"),updateClient.Value.Name);
            Assert.AreEqual(new Address("555 Street X", "J City"),updateClient.Value.Address);
        }
    }
}

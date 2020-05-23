using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Tectoro_Task;
using Newtonsoft.Json;
using System.Net.Http;
using Tectoro_Task.Models;
using System.Text;

namespace TectoroUnitTests
{
    public class TaskTest: IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public TaskTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/users/user")]
        [InlineData("/api/users/ManagerClientDetails")]
        [InlineData("/api/users/ClientManagerDetails")]
        [InlineData("/api/users/GetManagerAllClients?userName=Amol_123")]
        public async Task GetHttpRequest(string url)
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.GetAsync(url);

            //Assert
            response.EnsureSuccessStatusCode();
           // Assert.Equal("text/html; charset=utf-8",
             //   response.Content.Headers.ContentType.ToString());

        }

        [Theory]
        [InlineData("/api/users/AddUser")]
        public async Task PostHttpRequest(string url)
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.PostAsync("/api/users/AddUser"
               , new StringContent(
               JsonConvert.SerializeObject(new Users()
               {
                   UserName = "Test123",
                   FirstName = "John",
                   LastName = "Mak",
                   EmailId = "test@yahoo.com",
                   Alias = "222-333-4444",
                   Type="Client",
                   ManagerId=1
               }),
           Encoding.UTF8,
           "application/json"));

            //Assert
            response.EnsureSuccessStatusCode();

        }

        [Theory]
        [InlineData("/api/users/UpdateUsers")]
        public async Task UpdateHttpRequest(string url)
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            //var response = await client.GetAsync(url);
            var response = await client.PostAsync("/api/users/UpdateUsers"
               , new StringContent(
               JsonConvert.SerializeObject(new Users()
               {
                   UserId=7,
                   UserName = "Test123",
                   FirstName = "John",
                   LastName = "Mak",
                   EmailId = "test@yahoo.com",
                   Alias = "TestUpdate",
                   Type = "ClientTest",
                   ManagerId = 1
               }),
           Encoding.UTF8,
           "application/json"));

            //Assert
            response.EnsureSuccessStatusCode();

        }
        [Theory]
        [InlineData("/api/users/DeleteUsers?id=8")]
        public async Task DeleteHttpRequest(string url)
        {
            //Arrange
            var client = _factory.CreateClient();

            //Act
            var response = await client.DeleteAsync(url);

            //Assert
            response.EnsureSuccessStatusCode();

        }
    }
}

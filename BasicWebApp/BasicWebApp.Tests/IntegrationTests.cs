using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BasicWebApp.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace BasicWebApp.Tests
{
    public class IntegrationTests
    {

        private HttpClient CreateClient()
        {
            return new WebApplicationFactory<Startup>().CreateClient();
        }

        private StringContent SerializeUser(User user)
        {
            return new StringContent(JsonConvert.SerializeObject( 
                    user), Encoding.UTF8,
                "application/json"
            );
        }

        [Fact]
        public async Task ReturnsStatusCode200ForGetAllUsers()
        {
            var client = CreateClient();
            var response = await client.GetAsync("users");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        
        [Fact]
        public async Task ReturnsStatusCode201ForPostUser()
        {
            var client = CreateClient();
            var newUser = new User {Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe"};
            var newUserAsJson = SerializeUser(newUser);
            var response = await client.PostAsync("users", newUserAsJson);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        
        [Fact]
        public async Task PutsUserWithStatusCode200()
        {
            var client = CreateClient();
            var idToUpdate = new Guid("504984A1-B367-405D-9822-2F1D34FF9A4F");
            var updatedUser = new User {
                Id = new Guid("504984A1-B367-405D-9822-2F1D34FF9A4F"), 
                FirstName = "Loren", LastName = "Grbic"
            };
            var updatedUserAsJson = SerializeUser(updatedUser);
            var response = await client.PutAsync("users/" + idToUpdate, updatedUserAsJson);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode); 
        }
        
        [Fact]
        public async Task ReturnsStatusCode200ForGetUser()
        {
            var client = CreateClient();
            var idToGet = new Guid("6E6E7C46-EF1F-48FB-BC77-8D2637638630");
            var response = await client.GetAsync("users/" + idToGet);
        
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        
        [Fact]
        public async Task ReturnsStatusCode404ForGetUserIfUserDoesntExist()
        {
            var client = CreateClient();
            var nonExistentId = Guid.NewGuid();
            var response = await client.GetAsync("users/" + nonExistentId);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        
        [Fact]
        public async Task DeletesUserWithStatusCode200()
        {
            var client = CreateClient();
            var deleted = new User {
                Id = new Guid("77E21A11-BE8B-46BA-A6ED-0D70ACBBAB4A"), 
                FirstName = "Leah", 
                LastName = "Filkin"
            };
            var response = await client.DeleteAsync("users/77E21A11-BE8B-46BA-A6ED-0D70ACBBAB4A");
            var content = JsonConvert.DeserializeObject<User>
                (await response.Content.ReadAsStringAsync());
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(deleted, content);
        }
    }
}
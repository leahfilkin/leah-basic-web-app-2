using System;
using BasicWebApp.Models;
using Xunit;

namespace BasicWebApp.Tests
{
    public class UserTests
    {
        [Fact]
        public void HasId()
        {
            var user = new User {Id = new Guid("77E21A11-BE8B-46BA-A6ED-0D70ACBBAB4A")};
            
            Assert.Equal(new Guid("77E21A11-BE8B-46BA-A6ED-0D70ACBBAB4A"), user.Id);
        }
    }
}

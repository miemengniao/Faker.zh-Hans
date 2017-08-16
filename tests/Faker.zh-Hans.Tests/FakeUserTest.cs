using FluentAssertions;
using MieMengNiao.Faker.zh.Hans;
using Xunit;

namespace Faker.zh_Hans.Tests
{
    public class FakeUserTest
    {
        [Fact]
        public void FakeUser_Can_Create()
        {
            //arrange
            var fakeUser = new FakeUser();
            //act

            //assert
            fakeUser.FamilyName.Should().NotBeNullOrEmpty();
            fakeUser.FirstName.Should().NotBeNullOrEmpty();
            fakeUser.FullName.Should().Be(fakeUser.FamilyName + fakeUser.FirstName);
            fakeUser.Age.Should().BeGreaterOrEqualTo(0);
        }

    }
}

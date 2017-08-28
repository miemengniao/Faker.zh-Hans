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

        [Theory()]
        [InlineData("429006198501085470")]
        [InlineData("450323198608253921")]
        [InlineData("420324198309245412")]
        [InlineData("421087198702054233")]
        [InlineData("421083198602101914")]
        [InlineData("420322198504062715")]
        [InlineData("420802198704211916")]
        [InlineData("421022198510186057")]
        [InlineData("421087198602123238")]
        [InlineData("420923198404040059")]
        [InlineData("42038119850326151X")]
        public void FakeUser_IDNum_ShouldCorrect(string idNum)
        {
            //arrange
            var pre = idNum.Substring(0, 17);
            var expect = idNum.Substring(17, 1);
            var actual = FakeUser.IdVerificationNum(pre);
            //act

            //assert
            actual.Should().BeEquivalentTo(expect);
        }

    }
}

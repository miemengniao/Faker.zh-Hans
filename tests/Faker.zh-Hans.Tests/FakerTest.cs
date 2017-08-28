using FluentAssertions;
using MieMengNiao.Faker.zh.Hans;
using Xunit;

namespace Faker.zh_Hans.Tests
{
    public class FakerTest
    {

        #region class for test
        public class TestObject
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public class TestObjectWP
        {
            public TestObjectWP(int val)
            {
                Val = val;
            }

            public int Val { get; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        #endregion

        [Fact]
        public void Faker_Generate_WithParameterConstruct_Object()
        {
            //arrange

            //act
            var tos = FakeFactory.Fake(()=>new TestObjectWP(21))
                        .Map<FakeUser>((target, user) => { target.Name = user.FullName; target.Age = user.Age; })
                        .Range(20);
            //assert
            tos.Should().HaveCount(20);
        }

        [Fact]
        public void Faker_Generate_100_Object()
        {
            //arrange
            
            //act
            var tos = FakeFactory.Fake<TestObject>()
                        .Map<FakeUser>((target, fakeUser) => { target.Name = fakeUser.FullName; target.Age = fakeUser.Age; })
                        .Range(100);
            //assert
            tos.Should().HaveCount(100);
        }

        [Fact]
        public void Faker_Generate_1_Object()
        {
            //arrange

            //act
            var tos = FakeFactory.Fake<TestObject>()
                        .Map<FakeUser>((target, fakeUser) => { target.Name = fakeUser.FullName; target.Age = fakeUser.Age; })
                        .Range();
            //assert
            tos.Should().HaveCount(1);
        }
    }
}

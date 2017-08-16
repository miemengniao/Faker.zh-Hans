using FluentAssertions;
using MieMengNiao.Faker.zh.Hans;
using Xunit;

namespace Faker.zh_Hans.Tests
{
    public class RandomNumberTests
    {
        [Fact]
        public void RandomWithSameSeed_Should_ReturnSameResult()
        {
            RandomNumber.ResetSeed(1972);
            var first = new int[]{
                RandomNumber.Next(),
                RandomNumber.Next(20),
                RandomNumber.Next(0,100)
            };
            RandomNumber.ResetSeed(1972);
            var second = new int[]{
                RandomNumber.Next(),
                RandomNumber.Next(20),
                RandomNumber.Next(0,100)
            };
            first.ShouldAllBeEquivalentTo(second);
        }
    }
}

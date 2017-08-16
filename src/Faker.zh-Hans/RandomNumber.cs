using System;
using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("MieMengNiao.Faker.zh-Hans.Tests")]

namespace MieMengNiao.Faker.zh.Hans
{
    /// <summary>
    /// 一个生成随机数的辅助方法
    /// </summary>
    internal static class RandomNumber
    {
        //todo: Random线程不安全,需要保护
        private static Random _rnd = new Random();


        public static void ResetSeed(int seed)
        {
            _rnd = new Random(seed);
        }

        public static int Next()
        {
            return _rnd.Next();
        }

        public static int Next(int max)
        {
            return _rnd.Next(max);
        }

        public static int Next(int min, int max)
        {
            return _rnd.Next(min, max);
        }
    }
}

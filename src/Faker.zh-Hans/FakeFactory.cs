using System;

namespace MieMengNiao.Faker.zh.Hans
{
    /// <summary>
    /// 模拟数据的生成工厂，用于生成一个Faker
    /// 以便支持Fluent API
    /// </summary>
    public static class FakeFactory
    {
        /// <summary>
        /// 如果目标类型支持无参构造函数，那么可以使用这个函数来创建一个Faker
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <returns>返回Faker</returns>
        public static Faker<T> Fake<T>()
            where T: class,new()
        {
            return new Faker<T>(() => new T());
            
        }

        /// <summary>
        /// 如果目标类型不支持无参构造函数，那么需要传入一个生成目标对象的工厂
        /// </summary>
        /// <typeparam name="T">目标类型</typeparam>
        /// <param name="TFactory">目标对象的构造工厂</param>
        /// <returns>返回Faker</returns>
        public static Faker<T> Fake<T> (Func<T> TFactory)
            where T : class
        {
            return new Faker<T>(TFactory);
        }

        
    }
}

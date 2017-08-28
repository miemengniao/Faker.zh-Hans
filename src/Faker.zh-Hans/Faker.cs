using System;
using System.Collections.Generic;

namespace MieMengNiao.Faker.zh.Hans
{
    /// <summary>
    /// 用于构建模拟数据的类
    /// </summary>
    /// <typeparam name="T">目标类型</typeparam>
    public class Faker<T>
        where T : class

    {

        /// <summary>
        /// 保存用户所存的类型
        /// </summary>
        private List<Action<T>>  _Actions = new List<Action<T>>();
        /// <summary>
        /// 保存目标类型的构造方法
        /// </summary>
        private Func<T> _generateDestination;

        /// <summary>
        /// 这个类不能直接创建,必须从FakerFactory来创建
        /// </summary>
        /// <param name="destination"></param>
        internal Faker(Func<T> destination)
        {
            this._generateDestination = destination;
        
        }

        /// <summary>
        /// 提供新的FO对象,用户可以手动更新目标对象
        /// </summary>
        /// <typeparam name="FO">一个Fake对象,比如FakeUser</typeparam>
        /// <param name="updateTarget">用户提供的更新目标对象的方法</param>
        /// <returns>返回Faker本身</returns>
        public Faker<T> Map<FO>(Action<T,FO> updateTarget)
            where FO:FakeObject,new()
        {
            _Actions.Add((T obj) => updateTarget(obj, new FO()));
            return this;
        }

        /// <summary>
        /// 用于获取指定数量的模拟目标对象,默认返回一个
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public List<T> Range(int num=1)
        {
            List<T> ret = new List<T>();

            for (int i = 0; i < num; i++)
            {
                T tmp = _generateDestination();
                ret.Add(tmp);
                _Actions.ForEach(r => r(tmp));
            }

            return ret;
        }
    }
}

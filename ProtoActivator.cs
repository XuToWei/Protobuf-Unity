using System;

namespace ProtoBuf
{
    /// <summary>
    /// 用于创建ProtoBuf的实例
    /// </summary>
    public static class ProtoActivator
    {
        private static Func<Type, bool, object> customInstanceFactory;
        /// <summary>
        /// 创建ProtoBuf的实例
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="nonPublic">是否非公共</param>
        /// <returns>实例</returns>
        /// <remarks>
        /// 如果自定义实例工厂不为空，则使用自定义实例工厂创建实例
        /// 否则使用Activator.CreateInstance创建实例
        /// </remarks>
        internal static object CreateInstance(Type type, bool nonPublic = false)
        {
            if (customInstanceFactory != null)
            {
                object instance = customInstanceFactory(type, nonPublic);
                if (instance != null)
                {
                    return instance;
                }
            }
            return Activator.CreateInstance(type, nonPublic);
        }

        /// <summary>
        /// 注册自定义实例工厂
        /// </summary>
        /// <param name="factory">工厂</param>  
        /// <remarks>
        /// 如果自定义实例工厂不为空，则使用自定义实例工厂创建实例
        /// 否则使用Activator.CreateInstance创建实例
        /// </remarks>
        public static void RegisterCustomFactory(Func<Type, bool, object> factory)
        {
            customInstanceFactory = factory;
        }
        
        /// <summary>
        /// 清除自定义实例工厂
        /// </summary>
        public static void ClearCustomFactory()
        {
            customInstanceFactory = null;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign {
    public abstract class Architecture<T> where T :Architecture<T>,new()
    {
        #region 类似单例模式 但是仅在内部访问使用
        private static T mArchitecture = null;

        // 确保Container是有实例的
        static void MakeSureArchitecture() {
            if (mArchitecture == null) {
                mArchitecture = new T();
                mArchitecture.Init();
            }
        }
        #endregion

        private IOCContainer mContainer = new IOCContainer();

        // 留给子类注册模块
        protected abstract void Init();

        // 提供一个注册模块的API
        public void Register<T>(T instance) { 
            MakeSureArchitecture();
            mArchitecture.mContainer.Register<T>(instance);
        }

        // 从容器中获取模块
        public static T Get<T>() where T :class { 
            MakeSureArchitecture ();
            return mArchitecture.mContainer.Get<T>();
        }
    }

}

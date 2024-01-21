using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign {
    public abstract class Architecture<T> where T :Architecture<T>,new()
    {
        #region ���Ƶ���ģʽ ���ǽ����ڲ�����ʹ��
        private static T mArchitecture = null;

        // ȷ��Container����ʵ����
        static void MakeSureArchitecture() {
            if (mArchitecture == null) {
                mArchitecture = new T();
                mArchitecture.Init();
            }
        }
        #endregion

        private IOCContainer mContainer = new IOCContainer();

        // ��������ע��ģ��
        protected abstract void Init();

        // �ṩһ��ע��ģ���API
        public void Register<T>(T instance) { 
            MakeSureArchitecture();
            mArchitecture.mContainer.Register<T>(instance);
        }

        // �������л�ȡģ��
        public static T Get<T>() where T :class { 
            MakeSureArchitecture ();
            return mArchitecture.mContainer.Get<T>();
        }
    }

}

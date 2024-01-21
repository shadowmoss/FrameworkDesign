using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example {
    public interface ICanSayHello {
        void SayHello();
        void SayOther();
    }
    public class InterfaceDesignExample : MonoBehaviour, ICanSayHello
    {
        public void SayHello()
        {
            Debug.Log("Hello");
        }

        // 显示实现的接口方法，必须将对象转为对应接口类型才可以调用
        void ICanSayHello.SayOther()
        {
            Debug.Log("Other");
        }
        private void Start()
        {
            this.SayHello();
            (this as ICanSayHello).SayOther();
        }
    }
}


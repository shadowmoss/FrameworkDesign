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

        // ��ʾʵ�ֵĽӿڷ��������뽫����תΪ��Ӧ�ӿ����Ͳſ��Ե���
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


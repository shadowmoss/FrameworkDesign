using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace FrameworkDesign.Example {
    public class InterfaceStructExample : MonoBehaviour
    {
        public interface ICustomScript {
            void Start();
            void Update();
            void Destroy();
        }
        // ��ʱ����ϣ��������ֱ�ӷ���,Start()��Update()��Destroy()�ȹؼ�������
        // ���������ṩ�м䷽��OnStart()��OnUpdate()��OnDestroy()
        public abstract class CustomScript : ICustomScript
        {
            protected bool mStarted {
                get;private set;
            }
            protected bool mDestroyed {
                get;private set;
            }
            public void Destroy()
            {
                OnDestroy();
                mDestroyed = true;
            }

            public void Start()
            {
                OnStart();
                mStarted = true;
            }

            public void Update()
            {
                OnUpdate(); 
            }

            protected abstract void OnStart();
            protected abstract void OnDestroy();
            protected abstract void OnUpdate();
        }

        // ������ֻʵ���м䷽������Ҫ�����ڳ����൱�б�����
        public class MyScript : CustomScript
        {
            protected override void OnDestroy()
            {
                Debug.Log("MyScript:OnDestroy");
            }

            protected override void OnStart()
            {
                Debug.Log("MyScript:OnStart");
            }

            protected override void OnUpdate()
            {
                Debug.Log("MySCript:OnUpdate");
            }
            
        }
        private void Start()
        {
            ICustomScript script = new MyScript();
            script.Start();
            script.Destroy();
            script.Update();
        }
    }

}

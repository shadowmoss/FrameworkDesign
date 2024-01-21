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
        // 有时，不希望子类能直接访问,Start()、Update()、Destroy()等关键方法。
        // 而向子类提供中间方法OnStart()、OnUpdate()、OnDestroy()
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

        // 子类中只实现中间方法，主要方法在抽象类当中被隐藏
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

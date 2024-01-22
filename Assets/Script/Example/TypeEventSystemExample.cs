using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example {
    public class TypeEventSystemExample : MonoBehaviour
    {
        public struct EventA { 
        
        }

        public struct EventB {
            public int ParamB;
        }

        public interface IEventGroup { 
            
        }

        public struct EventC : IEventGroup { 
            
        }

        public struct EventD : IEventGroup { 
            
        }

        private ITypeEventSystem mTypeEventSystem = null;
        private void Start()
        {
            mTypeEventSystem = new TypeEventSystem();
            mTypeEventSystem.Register<EventA>(eA =>
            {
                Debug.Log("OnEventA");
            }).UnRegisterWhenGameObjectDestroyed(gameObject);// 当GameObject触发OnDetroy事件时，自动注销监听

            mTypeEventSystem.Register<EventB>(OnEventB);

            mTypeEventSystem.Register<IEventGroup>(group =>
            {
                Debug.Log(group.GetType());
            }).UnRegisterWhenGameObjectDestroyed(gameObject);
        }

        private void OnEventB(EventB b)
        {
            Debug.Log("OnEventB");
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) {
                mTypeEventSystem.Send<EventA>();
            }
            if (Input.GetMouseButtonDown(1)) {
                mTypeEventSystem.Send(new EventB()
                {
                    ParamB = 123
                });
            }
            if (Input.GetKeyDown(KeyCode.Space)) {
                mTypeEventSystem.Send<IEventGroup>(new EventC());
                mTypeEventSystem.Send<IEventGroup>(new EventD());
            }
        }
    }
}


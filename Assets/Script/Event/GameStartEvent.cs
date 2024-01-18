using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example {
    public static class GameStartEvent
    {
        private static Action mOnEventTrigger;

        // 事件注册
        public static void Register(Action action)
        {
            mOnEventTrigger += action;
        }
        // 事件注销
        public static void Unregister(Action action)
        {
            mOnEventTrigger -= action;
        }

        // 触发事件
        public static void Trigger()
        {
            mOnEventTrigger?.Invoke();
        }
    }
}
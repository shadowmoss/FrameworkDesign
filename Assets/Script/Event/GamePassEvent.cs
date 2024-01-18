using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example {
    public static class GamePassEvent
    {
        private static Action mOnGamePassEvent;

        public static void Register(Action action) {
            mOnGamePassEvent += action;
        }
        public static void Unregister(Action action)
        {
            mOnGamePassEvent -= action;
        }
        public static void Trigger() {
            mOnGamePassEvent?.Invoke();
        }
    }
}

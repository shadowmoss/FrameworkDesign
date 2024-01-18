using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example {
    public static class GameStartEvent
    {
        private static Action mOnEventTrigger;

        // �¼�ע��
        public static void Register(Action action)
        {
            mOnEventTrigger += action;
        }
        // �¼�ע��
        public static void Unregister(Action action)
        {
            mOnEventTrigger -= action;
        }

        // �����¼�
        public static void Trigger()
        {
            mOnEventTrigger?.Invoke();
        }
    }
}
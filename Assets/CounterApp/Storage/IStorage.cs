using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
namespace CounterApp {
    public interface IStorage:IUtility
    {
        void SaveInt(string key,int value);
        int LoadInt(string key, int defaultValue = 0);
    }
    // ����ʱ�洢ʵ��
    public class PlayerPrefsStorage : IStorage
    {
        public int LoadInt(string key, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        public void SaveInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
        }

    }
    // �༭���洢ʵ��
    public class EditorPrefsStorage : IStorage
    {
        public int LoadInt(string key, int defaultValue = 0)
        {
#if UNITY_EDITOR
            return EditorPrefs.GetInt(key, defaultValue);
#else
            return 0;
#endif
        }

        public void SaveInt(string key, int value)
        {
            EditorPrefs.SetInt(key, value);
        }
    }
}


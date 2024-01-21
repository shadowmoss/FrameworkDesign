using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
namespace FrameworkDesign.Example{

    public class DIPExample : MonoBehaviour
    {
        public interface IStorage {
            void SaveString(string key,string value);
            string LoadString(string key,string defaultValue = "");
        }

        // 2.ʵ�ֽӿ�
        // ����ʱ�洢
        public class PlayerPrefsStorage : IStorage
        {
            public string LoadString(string key, string defaultValue = "")
            {
               return  PlayerPrefs.GetString(key,defaultValue);
            }

            public void SaveString(string key, string value)
            {
                PlayerPrefs.SetString(key, value);
            }
        }

        // 3.ʵ�ֽӿ�
        // �༭���洢
        public class EditorPrefsStorage : IStorage
        {
            public string LoadString(string key, string defaultValue = "")
            {
#if UNITY_EDITOR
                return EditorPrefs.GetString(key, defaultValue);
#else
                return ""
#endif
            }

            public void SaveString(string key, string value)
            {
#if UNITY_EDITOR
                EditorPrefs.SetString(key, value);
#endif
            }
        }

        // 4.ʹ��
        private void Start()
        {
            // ����һ��IOC����
            IOCContainer iOCContainer = new IOCContainer();

            // ע������ʱģ��
            iOCContainer.Register<IStorage>(new PlayerPrefsStorage());

            // �������л�ȡ�洢��
            IStorage storage = iOCContainer.Get<IStorage>();
            storage.SaveString("name","����ʱ�洢");
            Debug.Log(storage.LoadString("name"));

            // �л��洢��ʵ��
            iOCContainer.Register<IStorage>(new EditorPrefsStorage());

            storage = iOCContainer.Get<IStorage>();
            storage.SaveString("name","����");
            Debug.Log(storage.LoadString("name"));
        }
    }
}


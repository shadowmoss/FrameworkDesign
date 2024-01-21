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

        // 2.实现接口
        // 运行时存储
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

        // 3.实现接口
        // 编辑器存储
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

        // 4.使用
        private void Start()
        {
            // 创建一个IOC容器
            IOCContainer iOCContainer = new IOCContainer();

            // 注册运行时模块
            iOCContainer.Register<IStorage>(new PlayerPrefsStorage());

            // 从容器中获取存储器
            IStorage storage = iOCContainer.Get<IStorage>();
            storage.SaveString("name","运行时存储");
            Debug.Log(storage.LoadString("name"));

            // 切换存储器实现
            iOCContainer.Register<IStorage>(new EditorPrefsStorage());

            storage = iOCContainer.Get<IStorage>();
            storage.SaveString("name","测试");
            Debug.Log(storage.LoadString("name"));
        }
    }
}


using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CounterApp {
    public class EditorCounterApp : EditorWindow,IController
    {

        [MenuItem("EditorCounterApp/Open")]
        static void Open() {
            // ��Ϊ�Ǳ༭����չ����,����Counterֵ�Ĵ洢��Ҫ��ͬ��ʵ��
            CounterApp.OnRegisterPatch += (app) =>
            {
                app.RegisterUtility<IStorage>(new EditorPrefsStorage());
            };
            EditorCounterApp editorCounterApp =  GetWindow<EditorCounterApp>();
            editorCounterApp.name = nameof(EditorCounterApp);
            editorCounterApp.position = new Rect(100, 100, 100, 100);
            editorCounterApp.Show();
        }

        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return CounterApp.Instance;
        }

        private void OnGUI()
        {
            // +��ť
            if (GUILayout.Button("+")) {
                this.SendCommand<AddCountCommand>();
            }
            // ����ʵʱˢ�£�����ֱ�Ӿ���Ⱦ���ݼ���
            GUILayout.Label(CounterApp.Get<ICounterModel>().Count.Value.ToString());
            // -��ť
            if (GUILayout.Button("-")) {
                this.SendCommand(new AddCountCommand());
            }
        }
    }

}

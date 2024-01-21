using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CounterApp {
    public class EditorCounterApp : EditorWindow
    {

        [MenuItem("EditorCounterApp/Open")]
        static void Open() {
           EditorCounterApp editorCounterApp =  GetWindow<EditorCounterApp>();
            editorCounterApp.name = nameof(EditorCounterApp);
            editorCounterApp.position = new Rect(100, 100, 100, 100);
            editorCounterApp.Show();
        }

        private void OnGUI()
        {
            // +��ť
            if (GUILayout.Button("+")) {
                new AddCountCommand().Execute();
            }
            // ����ʵʱˢ�£�����ֱ�Ӿ���Ⱦ���ݼ���
            GUILayout.Label(CounterApp.Get<CounterModel>().Count.Value.ToString());
            // -��ť
            if (GUILayout.Button("-")) { 
                new SubCountCommand().Execute();
            }
        }
    }

}

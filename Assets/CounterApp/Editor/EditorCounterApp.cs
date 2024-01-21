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
            // +按钮
            if (GUILayout.Button("+")) {
                new AddCountCommand().Execute();
            }
            // 由于实时刷新，所以直接就渲染数据即可
            GUILayout.Label(CounterApp.Get<CounterModel>().Count.Value.ToString());
            // -按钮
            if (GUILayout.Button("-")) { 
                new SubCountCommand().Execute();
            }
        }
    }

}

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
            // 因为是编辑器扩展对象,对于Counter值的存储需要不同的实现
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
            // +按钮
            if (GUILayout.Button("+")) {
                this.SendCommand<AddCountCommand>();
            }
            // 由于实时刷新，所以直接就渲染数据即可
            GUILayout.Label(CounterApp.Get<ICounterModel>().Count.Value.ToString());
            // -按钮
            if (GUILayout.Button("-")) {
                this.SendCommand(new AddCountCommand());
            }
        }
    }

}

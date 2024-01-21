using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            CounterApp.Get<CounterModel>().Count.OnValueChanged += OnCountChanged;
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() => {
                // 交互逻辑:会自动触发表现逻辑
                // 现在以命令模式执行交互逻辑
                new AddCountCommand().Execute();
            });
            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                // 交互逻辑
                // 现在以命令模式执行交互逻辑
                new SubCountCommand().Execute();
            });
        }
        private void OnCountChanged(int newValue) {
            transform.Find("Count").GetComponent<Text>().text = newValue.ToString();
        }
        private void OnDestroy()
        {
            CounterApp.Get<CounterModel>().Count.OnValueChanged -= OnCountChanged;
        }
        
    }
    public class CounterModel
    { 
        // 通过泛型BindableProperty类型实现简单的双向绑定
        public  BindableProperty<int> Count = new BindableProperty<int>() { 
            Value = 0
        };
    }
}


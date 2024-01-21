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
                // �����߼�:���Զ����������߼�
                // ����������ģʽִ�н����߼�
                new AddCountCommand().Execute();
            });
            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                // �����߼�
                // ����������ģʽִ�н����߼�
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
        // ͨ������BindableProperty����ʵ�ּ򵥵�˫���
        public  BindableProperty<int> Count = new BindableProperty<int>() { 
            Value = 0
        };
    }
}


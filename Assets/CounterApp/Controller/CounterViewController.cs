using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CounterApp
{
    public class CounterViewController : MonoBehaviour,IController
    {
        private ICounterModel mCounterModel;

        // Start is called before the first frame update
        void Start()
        {
            mCounterModel = GetArchitecture().GetModel<ICounterModel>();
            mCounterModel.Count.OnValueChanged += OnCountChanged;
            transform.Find("BtnAdd").GetComponent<Button>().onClick.AddListener(() => {
                // �����߼�:���Զ����������߼�
                // ����������ģʽִ�н����߼�
                GetArchitecture().SendCommand<AddCountCommand>();
            });
            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                // �����߼�
                // ����������ģʽִ�н����߼�
                GetArchitecture().SendCommand<SubCountCommand>();
            });
            OnCountChanged(mCounterModel.Count.Value);
        }
        private void OnCountChanged(int newValue) {
            transform.Find("Count").GetComponent<Text>().text = newValue.ToString();
        }
        private void OnDestroy()
        {
            mCounterModel.Count.OnValueChanged -= OnCountChanged;
        }
        // IController��ȡ��ܶ���Ĵ���
        public IArchitecture GetArchitecture()
        {
            return CounterApp.Instance;
        }
    }
    // ����һ��ӵ��BindableProertyֻ�����Ե�ICounterModel�ӿ�
    public interface ICounterModel :IModel{ 
        BindableProperty<int> Count { get; }
    }
    public class CounterModel :AbstractModel,ICounterModel
    {
        // ��ʼ������
        protected override void OnInit()
        {
            IStorage storage = GetArchitecture().GetUtility<IStorage>();
            Count.Value = storage.LoadInt("COUNTER_COUNT", 0);
            Count.OnValueChanged += count =>
            {
                storage.SaveInt("COUNTER_COUNT", Count.Value);
            };
        }

        public CounterModel() {
            // �ڴ˴�ֱ��ͨ��CounterApp�ľ�̬��������ȡstorage�ᴥ�����޵ݹ����

            // ���new CounterModel() -> CounterApp.Get -> Architeture.Init() ->new CounterModel()-> CounterApp.Get()
            // ���������޵ݹ顣��ʹ��ջ���
            // ������������޵ݹ����⣬ͨ��ʹ�ã�CounterModel��CounterApp�����࣬������и��ԵĶ�����ʹ�ã���������ֱ�Ӳ�Ҫ������ø��Եĳ�ʼ��������
            
            //IStorage storage = CounterApp.Get<IStorage>();
        }

        // ͨ������BindableProperty����ʵ�ּ򵥵�˫���
        public  BindableProperty<int> Count { get; } = new BindableProperty<int>() { 
            Value = 0
        };
    }
}


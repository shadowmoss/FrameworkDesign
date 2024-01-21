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
                // 交互逻辑:会自动触发表现逻辑
                // 现在以命令模式执行交互逻辑
                GetArchitecture().SendCommand<AddCountCommand>();
            });
            transform.Find("BtnSub").GetComponent<Button>().onClick.AddListener(() =>
            {
                // 交互逻辑
                // 现在以命令模式执行交互逻辑
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
        // IController获取框架对象的代码
        public IArchitecture GetArchitecture()
        {
            return CounterApp.Instance;
        }
    }
    // 定义一个拥有BindableProerty只读属性的ICounterModel接口
    public interface ICounterModel :IModel{ 
        BindableProperty<int> Count { get; }
    }
    public class CounterModel :AbstractModel,ICounterModel
    {
        // 初始化方法
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
            // 在此处直接通过CounterApp的静态方法，获取storage会触发无限递归调用

            // 造成new CounterModel() -> CounterApp.Get -> Architeture.Init() ->new CounterModel()-> CounterApp.Get()
            // 上述的无限递归。致使堆栈溢出
            // 解决上述的无限递归问题，通过使得，CounterModel和CounterApp两个类，互相持有各自的对象来使得，两个对象直接不要互相调用各自的初始化方法。
            
            //IStorage storage = CounterApp.Get<IStorage>();
        }

        // 通过泛型BindableProperty类型实现简单的双向绑定
        public  BindableProperty<int> Count { get; } = new BindableProperty<int>() { 
            Value = 0
        };
    }
}


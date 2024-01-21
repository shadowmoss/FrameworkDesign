using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example
{
    public class StartPanel : MonoBehaviour,IController
    {
        public IArchitecture GetArchitecture()
        {
            return PointGame.Instance;
        }

        private void Start()
        {
            // 视图中的父节点获取子节点，注册委托。
            this.transform.Find("BtnStart").GetComponent<Button>().onClick.AddListener(() => {
                // 将开始Panel自身隐藏
                gameObject.SetActive(false);
                // 事件由系统层向表现层发送
                GetArchitecture().SendCommand<GameStartCommand>();
            });
        }
    }
}


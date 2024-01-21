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
            // ��ͼ�еĸ��ڵ��ȡ�ӽڵ㣬ע��ί�С�
            this.transform.Find("BtnStart").GetComponent<Button>().onClick.AddListener(() => {
                // ����ʼPanel��������
                gameObject.SetActive(false);
                // �¼���ϵͳ������ֲ㷢��
                GetArchitecture().SendCommand<GameStartCommand>();
            });
        }
    }
}


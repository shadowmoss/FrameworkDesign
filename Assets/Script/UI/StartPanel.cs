using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FrameworkDesign.Example
{
    public class StartPanel : MonoBehaviour
    {
        private void Start()
        {
            // ��ͼ�еĸ��ڵ��ȡ�ӽڵ㣬ע��ί�С�
            this.transform.Find("BtnStart").GetComponent<Button>().onClick.AddListener(() => {
                // ����ʼPanel��������
                gameObject.SetActive(false);
                // ��ע���ί�е��д����¼���
                GameStartEvent.Trigger();
            });
        }
    }
}


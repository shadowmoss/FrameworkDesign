using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example {
    public class Enemy : MonoBehaviour
    {
        private void OnMouseDown()
        {
            Destroy(this.gameObject);
            // �����߼�,�滻ΪCommandʵ�ֽ����߼�
            new KillEnemyCommand().Execute();
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example {
    public class Enemy : MonoBehaviour,IController
    {
        public IArchitecture GetArchitecture()
        {
            return PointGame.Instance;
        }

        private void OnMouseDown()
        {
            Destroy(this.gameObject);
            // �����߼�,�滻ΪCommandʵ�ֽ����߼�
            GetArchitecture().SendCommand<KillEnemyCommand>();
        }
    }
}

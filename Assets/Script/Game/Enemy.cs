using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example {
    public class Enemy : MonoBehaviour,IController
    {
        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return PointGame.Instance;
        }

        private void OnMouseDown()
        {
            Destroy(this.gameObject);
            // 交互逻辑,替换为Command实现交互逻辑
            this.SendCommand<KillEnemyCommand>();
        }
    }
}

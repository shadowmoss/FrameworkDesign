using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example {
    public class Enemy : MonoBehaviour
    {
        private static int enemyDown = 0;
        public GameObject EndPanel;
        private void OnMouseDown()
        {
            enemyDown++;
            Destroy(this.gameObject);
            if (enemyDown >= 10)
            {
                EndPanel.SetActive(true);
            }
        }

    }
}

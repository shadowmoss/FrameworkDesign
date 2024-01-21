using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example {
    public class UI : MonoBehaviour
    {
        private void Start()
        {
            GamePassEvent.Register(OnPassEvent);
        }
        private void OnDestroy()
        {
            GamePassEvent.UnRegister(OnPassEvent);
        }
        private void OnPassEvent() { 
            this.transform.Find("Canvas/EndPanel").gameObject.SetActive(true);
        }
    }

}

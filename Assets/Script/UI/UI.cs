using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example {
    public class UI : MonoBehaviour,IController
    {
        private void Start()
        {
            this.RegisterEvent<GamePassEvent>(OnPassEvent);
            //GamePassEvent.Register(OnPassEvent);
        }
        private void OnDestroy()
        {
            this.RegisterEvent<GamePassEvent>(OnPassEvent);
            //GamePassEvent.UnRegister(OnPassEvent);
        }
        private void OnPassEvent(GamePassEvent eventData) { 
            this.transform.Find("Canvas/EndPanel").gameObject.SetActive(true);
        }
        
        IArchitecture IBelongToArchitecture.GetArchitecture()
        {
            return PointGame.Instance;
        }
    }

}

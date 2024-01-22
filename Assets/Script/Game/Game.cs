using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example {
    public class Game : MonoBehaviour,IController
    {
        private void Start()
        {
            this.RegisterEvent<GameStartEvent>(OnStart);
            //GameStartEvent.Register(OnStart);
        }
        private void OnDestroy()
        {
            this.UnRegisterEvent<GameStartEvent>(OnStart);
            //GameStartEvent.Unregister(OnStart);
        }
        private void OnStart(GameStartEvent eventData) { 
            this.transform.Find("Enemies").gameObject.SetActive(true);
        }

        public IArchitecture GetArchitecture()
        {
            return PointGame.Instance;
        }
    }
}
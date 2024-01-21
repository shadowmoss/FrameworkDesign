using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FrameworkDesign.Example {
    public class Game : MonoBehaviour
    {
        private void Start()
        {
            GameStartEvent.Register(OnStart);
        }
        private void OnDestroy()
        {
            GameStartEvent.Unregister(OnStart);
        }
        private void OnStart() { 
            this.transform.Find("Enemies").gameObject.SetActive(true);
        }
    }
}
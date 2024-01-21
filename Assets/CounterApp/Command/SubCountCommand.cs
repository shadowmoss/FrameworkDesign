using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CounterApp {
    public struct SubCountCommand : ICommand
    {
        public void Execute()
        {
            CounterApp.Get<CounterModel>().Count.Value--;
        }
    }
}


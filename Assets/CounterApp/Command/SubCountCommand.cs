using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CounterApp {
    public class SubCountCommand : AbstractCommand, ICommand
    {

        protected override void OnExecute()
        {
            CounterApp.Get<ICounterModel>().Count.Value--;
        }
    }
}


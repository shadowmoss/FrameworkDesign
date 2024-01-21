using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FrameworkDesign;
namespace CounterApp
{
    public class AddCountCommand : AbstractCommand,ICommand
    {

        protected override void OnExecute()
        {
            CounterApp.Get<ICounterModel>().Count.Value++;
        }
    }
}


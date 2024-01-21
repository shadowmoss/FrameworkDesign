using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

namespace FrameworkDesign.Example {
    public class GameStartCommand : AbstractCommand,ICommand
    {
        protected override void OnExecute()
        {
            GameStartEvent.Trigger();
        }
    }
}


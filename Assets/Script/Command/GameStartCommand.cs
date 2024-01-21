using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using UnityEngine;

namespace FrameworkDesign.Example {
    public class GameStartCommand : ICommand
    {
        public void Execute()
        {
            GameStartEvent.Trigger();
        }
    }
}


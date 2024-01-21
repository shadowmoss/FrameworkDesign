using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class PassGameCommand : AbstractCommand, ICommand
    { 
        protected override void OnExecute()
        {
            GamePassEvent.Trigger();
        }
    }
}
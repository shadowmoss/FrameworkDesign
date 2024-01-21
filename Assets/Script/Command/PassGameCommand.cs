using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example
{
    public class PassGameCommand : ICommand
    {
        public void Execute()
        {
            GamePassEvent.Trigger();
        }
    }
}
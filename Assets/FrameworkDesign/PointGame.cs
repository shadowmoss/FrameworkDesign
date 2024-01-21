using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace FrameworkDesign.Example{
    public class PointGame : Architecture<PointGame>
    {
        protected override void Init()
        {
            Register(new GameModel());
        }
    }
}


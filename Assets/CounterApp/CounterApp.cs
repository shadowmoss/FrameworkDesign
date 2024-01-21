using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace CounterApp {
    public class CounterApp : Architecture<CounterApp>
    {
        protected override void Init()
        {
            Register(new CounterModel());
        }
    }

}

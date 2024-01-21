using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example {
    public class CanDoEveryThing
    {
        public void DoSomething()
        {
            Debug.Log("DoSomething1");
        }
        public void DoSomething2()
        {
            Debug.Log("DoSomething2");
        }
        public void DoSomething3() {
            Debug.Log("DoSomething3");
        }
    }
    public interface IHasEveryThing { 
        CanDoEveryThing CanDoEveryThing { get; }
    }
    public interface ICanDoSomeThing1 : IHasEveryThing { 
        
    }
    public static class ICanDoSomeThing1Extensions {
        public static void DoSomething1(this ICanDoSomeThing1 self) { 
            self.CanDoEveryThing.DoSomething();
        }
    }
    public interface ICanDoSomeThing2 : IHasEveryThing
    {

    }
    public static class ICanDoSomeThing2Extensions
    {
        public static void DoSomething2(this ICanDoSomeThing2 self)
        {
            self.CanDoEveryThing.DoSomething2();
        }
    }
    public interface ICanDoSomeThing3 : IHasEveryThing
    {

    }
    public static class ICanDoSomeThing3Extensions
    {
        public static void DoSomething3(this ICanDoSomeThing3 self)
        {
            self.CanDoEveryThing.DoSomething3();
        }
    }
    public class InterfaceRuleExample : MonoBehaviour
    {
        public class OnlyCanDo1 : ICanDoSomeThing1
        {
            CanDoEveryThing IHasEveryThing.CanDoEveryThing { get; } = new CanDoEveryThing();
        }
        public class OnlyCanDo23 : ICanDoSomeThing2, ICanDoSomeThing3 {
            CanDoEveryThing IHasEveryThing.CanDoEveryThing { get; } = new CanDoEveryThing();
        }
        private void Start()
        {
            OnlyCanDo1 onlyCanDo1 = new OnlyCanDo1();

            onlyCanDo1.DoSomething1();

            OnlyCanDo23 onlyCanDo23 = new OnlyCanDo23();
            onlyCanDo23.DoSomething2();
            onlyCanDo23.DoSomething3();
        }
    }

}

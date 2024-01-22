using FrameworkDesign;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CounterApp {
    public interface IAchievement :ISystem{ 
    
    }
    public class AchievementSystem : AbstractSystem,IAchievement
    {
        protected override void OnInit()
        {
            // 通过Count计算当前点击了多少次
            ICounterModel counterModel = this.GetModel<ICounterModel>();
            int preCount = counterModel.Count.Value;
            counterModel.Count.OnValueChanged += (newCount) =>
            {
                if (preCount < 10 && newCount >= 10)
                {
                    Debug.Log("解锁了点击10次成就");
                }
                if (preCount < 20 && newCount >= 20)
                {
                    Debug.Log("解锁了点击20次成就");
                }
                preCount = newCount;
            };
        }
    }
}


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
            // ͨ��Count���㵱ǰ����˶��ٴ�
            ICounterModel counterModel = this.GetModel<ICounterModel>();
            int preCount = counterModel.Count.Value;
            counterModel.Count.OnValueChanged += (newCount) =>
            {
                if (preCount < 10 && newCount >= 10)
                {
                    Debug.Log("�����˵��10�γɾ�");
                }
                if (preCount < 20 && newCount >= 20)
                {
                    Debug.Log("�����˵��20�γɾ�");
                }
                preCount = newCount;
            };
        }
    }
}


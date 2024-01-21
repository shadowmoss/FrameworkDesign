using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example {
    public class KillEnemyCommand : ICommand
    {
        public void Execute()
        {
            PointGame.Get<GameModel>().KillCount.Value++;

            if(PointGame.Get<GameModel>().KillCount.Value >= 10 )
            {
                // 发送 结束事件。
                GamePassEvent.Trigger();
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign.Example {
    public class KillEnemyCommand : AbstractCommand, ICommand
    {
        protected override void OnExecute()
        {
            this.GetModel<IGameModel>().KillCount.Value++;

            if (PointGame.Get<IGameModel>().KillCount.Value >= 10)
            {
                // 发送 结束事件。
                this.SendEvent<GamePassEvent>();
                //GamePassEvent.Trigger();
            }
        }
    }

}

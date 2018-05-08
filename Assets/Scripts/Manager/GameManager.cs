using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : BaseManager {

    public GameManager(GameFacade facade) : base(facade)
    {

    }
    //TODO 控制游戏整个流程，游戏得分，游戏时间限制
    public override void OnInit()
    {
        base.OnInit();

    }
    /// <summary>
    /// 游戏开始需要初始化的一些数据
    /// 1.随机布置人物的位置
    /// 2.初始化人物拥有道具数量
    /// 3.计时器开始计时
    /// 4.能量系统启动
    /// </summary>
    public void StartGame()
    {
        mGameFacade.InitPlayerData();//1,2
        StartTimer();//3
        mGameFacade.StartEnergySystem();//4

    }
    /// <summary>
    /// 游戏结束
    /// 1.统计并显示得分面板
    /// </summary>
    public void GameOver()
    {
        
    }
    /// <summary>
    /// 开始计时
    /// </summary>
    private void StartTimer()
    {
        
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : BaseManager
{
    private Role p1;
    private Role p2;
    private GameObject p1Prefab;
    private GameObject p2Prefab;
    public PlayerManager(GameFacade facade) : base(facade)
    {

    }

    public override void OnInit()
    {
        base.OnInit();
        p1Prefab = GameObject.Find("Player");
        p2Prefab=GameObject.Find("Player2");
    }

    /// <summary>
    /// 初始化角色类型，道具数量
    /// </summary>
    public void InitRole()
    {
        //p1=new Role(RoleType.P1);
        //p2=new Role(RoleType.P2);
    }

    public void RandomPos(RoleType roleType)
    {
        if (roleType == RoleType.P1)
        {
            //TODO 随机P1位置 p1Prefab.tranform.position=Random....
        }else if (roleType == RoleType.P2)
        {
            //TODO 随机P2位置 p2Prefab.tranform.position=Random....
        }
    }
}

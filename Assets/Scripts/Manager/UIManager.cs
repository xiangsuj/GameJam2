﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : BaseManager {

    
    private Transform canvasTransform;
    private Transform CanvasTransform
    {
        get
        {
            if (canvasTransform == null)
            {
                canvasTransform = GameObject.Find("Canvas").transform;
            }
            return canvasTransform;
        }
    }
    private Dictionary<UIPanelType, string> panelPathDict;//存储所有面板Prefab的路径
    private Dictionary<UIPanelType, BasePanel> panelDict;//保存所有实例化面板的游戏物体身上的BasePanel组件
    private Stack<BasePanel> panelStack;
    private P1MessagePanel p1MessagePanel;
    private P2MessagePanel p2MessagePanel;
    private UIPanelType panelTypeToPush = UIPanelType.None;

    public UIManager(GameFacade facade) : base(facade)
    {
        ParseUIPanelTypeJson();
    }

    public override void OnInit()
    {
        base.OnInit();
       
        PushPanel(UIPanelType.Start);

    }

    public override void Update()
    {
        if (panelTypeToPush != UIPanelType.None)
        {
            PushPanel(panelTypeToPush);
            panelTypeToPush = UIPanelType.None;

        }
    }

    /// <summary>
    /// 异步调用UIpanel
    /// </summary>
    /// <param name="panelType"></param>
    public void PushPanelSync(UIPanelType panelType)
    {
        panelTypeToPush = panelType;
    }
    /// <summary>
    /// 把某个页面入栈，  把某个页面显示在界面上
    /// </summary>
    public BasePanel PushPanel(UIPanelType panelType)
    {
        if (panelStack == null)
            panelStack = new Stack<BasePanel>();

        //判断一下栈里面是否有页面
        if (panelStack.Count > 0)
        {
            BasePanel topPanel = panelStack.Peek();
            topPanel.OnPause();
        }

        BasePanel panel = GetPanel(panelType);
        panel.OnEnter();
        panelStack.Push(panel);
        return panel;
    }
    /// <summary>
    /// 出栈 ，把页面从界面上移除
    /// </summary>
    public void PopPanel()
    {
        if (panelStack == null)
            panelStack = new Stack<BasePanel>();

        if (panelStack.Count <= 0) return;

        //关闭栈顶页面的显示
        BasePanel topPanel = panelStack.Pop();
        topPanel.OnExit();

        if (panelStack.Count <= 0) return;
        BasePanel topPanel2 = panelStack.Peek();
        topPanel2.OnResume();

    }

    /// <summary>
    /// 根据面板类型 得到实例化的面板
    /// </summary>
    /// <returns></returns>
    private BasePanel GetPanel(UIPanelType panelType)
    {
        
        if (panelDict == null)
        {
            panelDict = new Dictionary<UIPanelType, BasePanel>();
        }

        //BasePanel panel;
        //panelDict.TryGetValue(panelType, out panel);//TODO

        BasePanel panel = panelDict.TryGet(panelType);

        if (panel == null)
        {
            //如果找不到，那么就找这个面板的prefab的路径，然后去根据prefab去实例化面板
            //string path;
            //panelPathDict.TryGetValue(panelType, out path);
            string path = panelPathDict.TryGet(panelType);
            GameObject instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            instPanel.transform.SetParent(CanvasTransform, false);
            instPanel.GetComponent<BasePanel>().UIMgr = this;
            instPanel.GetComponent<BasePanel>().Facade = mGameFacade;
            panelDict.Add(panelType, instPanel.GetComponent<BasePanel>());
            return instPanel.GetComponent<BasePanel>();
        }
        else
        {
            return panel;
        }

    }

    [Serializable]
    class UIPanelTypeJson
    {
        public List<UIPanelInfo> infoList;
    }
    private void ParseUIPanelTypeJson()
    {
        panelPathDict = new Dictionary<UIPanelType, string>();

        TextAsset ta = Resources.Load<TextAsset>("UIPanelType");

        UIPanelTypeJson jsonObject = JsonUtility.FromJson<UIPanelTypeJson>(ta.text);

        foreach (UIPanelInfo info in jsonObject.infoList)
        {
            //Debug.Log(info.panelType);
            panelPathDict.Add(info.panelType, info.path);
        }
    }
    //TODO 修改
    //public void InjectMessagePanel(P1MessagePanel msgPanel)
    //{
    //    this.p1MessagePanel = msgPanel;
    //}
    //public void ShowMessage(string msg)
    //{
    //    if (p1MessagePanel == null)
    //    {
    //        Debug.LogWarning("无法显示提示信息，MessagePanel为空");
    //        return;
    //    }
    //    p1MessagePanel.ShowMessage(msg);
    //}

    //public void ShowMessageSync(string msg)
    //{
    //    if (p1MessagePanel == null)
    //    {
    //        Debug.LogWarning("无法显示提示信息，MessagePanel为空");
    //        return;
    //    }
    //    p1MessagePanel.ShowMessageSync(msg);
    //}
}

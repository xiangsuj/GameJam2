using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : BasePanel
{
    private Button starButton;
    
    public override void OnEnter()
    {
        base.OnEnter();
        starButton = transform.Find("StartButton").GetComponent<Button>();
        starButton.onClick.AddListener(OnStartButtonClick);

    }

    private void OnStartButtonClick()
    {
        mFacade.StartGame();
        mUIMgr.PopPanel();
        mUIMgr.PushPanel(UIPanelType.P1Info);
        mUIMgr.PushPanel(UIPanelType.P2Info);
        mUIMgr.PushPanel(UIPanelType.Timer);
    }

    public override void OnExit()
    {
        base.OnExit();
        gameObject.SetActive(false);
    }
}

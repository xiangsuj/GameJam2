using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class P1InfoPanel : BasePanel
{
    private Text TransDoorText;
    private Text InnerDoorKeyText;
    private Text MarkPenText;
    private Text LightText;
    private Text EnergyText;
    private Role P1Role;
    public override void OnEnter()
    {
        base.OnEnter();
        P1Role=GameObject.Find("Player").GetComponent<Role>();
        TransDoorText = transform.Find("TransDoor").GetComponent<Text>();
        InnerDoorKeyText = transform.Find("InnerDoorKey").GetComponent<Text>();
        MarkPenText = transform.Find("MarkPen").GetComponent<Text>();
        LightText = transform.Find("Light").GetComponent<Text>();
        EnergyText = transform.Find("Energy").GetComponent<Text>();
        InitPanel();

    }

    private void InitPanel()
    {
        TransDoorText.text = "传送器:0";
        InnerDoorKeyText.text = "钥匙:0";
        MarkPenText.text = "标记笔:0";
        LightText.text = "灯:0";
        EnergyText.text = "能量:100/100";
    }

    public void UpdateInfo()
    {
        Debug.Log(P1Role.TransDoorCount);
        TransDoorText.text = "传送器:"+P1Role.TransDoorCount.ToString();
        InnerDoorKeyText.text = "钥匙:"+P1Role.InnerTransDoorKey.ToString();
        MarkPenText.text = "标记笔:"+P1Role.MarkPenCount.ToString();
        LightText.text = "灯:"+P1Role.LightCount.ToString();
        //TODO EnergyText.text = "能量:100/100";

    }

}

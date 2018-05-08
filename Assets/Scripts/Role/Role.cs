using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public enum RoleType
{
    P1,
    P2
}
public class Role:MonoBehaviour
{

    public RoleType RoleType;
    public int TransDoorCount;
    public int MarkPenCount;
    public int LightCount;
    public int InnerTransDoorKey;
    public Transform currentGrid;
    private P1InfoPanel p1InfoPanel;
    private P2InfoPanel p2InfoPanel;
    
    public Role(RoleType roleType)
    {
        RoleType = roleType;
        TransDoorCount = 0;
        MarkPenCount = 0;
        LightCount = 0;
        InnerTransDoorKey = 0;
    }

    private void Start()
    {

        

    }
    //TODO 各个道具数量的增减
    public void AddItem(ItemType itemType)
    {
        
        switch (itemType)
        {
            case ItemType.InnerDoorKey:
                InnerTransDoorKey++;
                break;
            case ItemType.Light:
                LightCount++;
                break;
            case ItemType.MarkPen:
                MarkPenCount++;
                break;
            case ItemType.TransDoor:
                TransDoorCount++;
                break;
        }
        if (p1InfoPanel == null)
        {
            p1InfoPanel = GameObject.Find("Canvas").transform.Find("P1InfoPanel(Clone)").GetComponent<P1InfoPanel>();
            
        }
        if (p2InfoPanel == null)
        {
            p2InfoPanel = GameObject.Find("Canvas").transform.Find("P2InfoPanel(Clone)").GetComponent<P2InfoPanel>();
            
        }
        if (this.RoleType == RoleType.P1)
        {
            p1InfoPanel.UpdateInfo();
        }
        if (this.RoleType == RoleType.P2)
        {
            p2InfoPanel.UpdateInfo();
        }


    }

    public bool IsHaveItem(ItemType itemType)
    {
        
        switch (itemType)
        {
            case ItemType.InnerDoorKey:
                if (InnerTransDoorKey > 0)
                {
                    
                    return true;
                }
                return false;


            case ItemType.Light:
                if (LightCount > 0)
                {
                    
                    return true;
                }
                return false;

            case ItemType.MarkPen:
                if (MarkPenCount > 0)
                {
                    
                    return true;
                }
                return false;

            case ItemType.TransDoor:
                if (TransDoorCount > 0)
                {
                    
                    return true;
                }
                return false;

        }


        return false;
    }
    private bool ReduceItem(ItemType itemType)
    {
        if (p1InfoPanel == null)
        {
            p1InfoPanel = GameObject.Find("Canvas").transform.Find("P1InfoPanel(Clone)").GetComponent<P1InfoPanel>();

        }
        if (p2InfoPanel == null)
        {
            p2InfoPanel = GameObject.Find("Canvas").transform.Find("P2InfoPanel(Clone)").GetComponent<P2InfoPanel>();
        }
        switch (itemType)
        {
            case ItemType.InnerDoorKey:
                if (InnerTransDoorKey > 0)
                {
                    InnerTransDoorKey--;
                    if (this.RoleType == RoleType.P1)
                    {
                        p1InfoPanel.UpdateInfo();
                    }
                    if (this.RoleType == RoleType.P2)
                    {
                        p2InfoPanel.UpdateInfo();
                    }
                    return true;
                }
                return false;
                
                
            case ItemType.Light:
                if (LightCount > 0)
                {
                    LightCount--;
                    if (this.RoleType == RoleType.P1)
                    {
                        p1InfoPanel.UpdateInfo();
                    }
                    if (this.RoleType == RoleType.P2)
                    {
                        p2InfoPanel.UpdateInfo();
                    }
                    return true;
                }
                return false;
                
            case ItemType.MarkPen:
                if (MarkPenCount > 0)
                {
                    MarkPenCount--;
                    if (this.RoleType == RoleType.P1)
                    {
                        p1InfoPanel.UpdateInfo();
                    }
                    if (this.RoleType == RoleType.P2)
                    {
                        p2InfoPanel.UpdateInfo();
                    }
                    return true;
                }
                return false;
                
            case ItemType.TransDoor:
                if (TransDoorCount > 0)
                {
                    TransDoorCount--;
                    if (this.RoleType == RoleType.P1)
                    {
                        p1InfoPanel.UpdateInfo();
                    }
                    if (this.RoleType == RoleType.P2)
                    {
                        p2InfoPanel.UpdateInfo();
                    }
                    return true;
                }
                return false;
                
        }
        
        
        return false;
    }

    public bool UseItem(ItemType itemType)
    {
        
        return ReduceItem(itemType);
    }
    
}

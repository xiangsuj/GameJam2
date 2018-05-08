using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None,
    TransDoor,//传送器
    Light,//灯
    MarkPen,//标记笔
    InnerDoorKey,//固定传送门钥匙
    EnergyBottle//能量瓶
}
public class Item : MonoBehaviour
{
    public ItemType ItemType=ItemType.None;

    private void  OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (this.ItemType != ItemType.EnergyBottle)
            {
               
                coll.GetComponent<Role>().AddItem(this.ItemType);
            }

            Destroy(this.gameObject);
        }
        
    }

    
}

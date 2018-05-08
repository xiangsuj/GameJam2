using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerDoor : MonoBehaviour
{
    public Transform innerDoorTrans;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            innerDoorTrans.GetComponent<BoxCollider2D>().isTrigger = true;
        }

    }
    
}

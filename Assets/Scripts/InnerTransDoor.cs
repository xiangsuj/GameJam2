using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerTransDoor : MonoBehaviour {

    private float timer = 2f;
    private bool startTime = false;
    public Transform targetDoorPos;
    public bool isLocked = true;
    private Collider2D collider;
    // Use this for initialization
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            
            
                timer = 2f;
                collider = coll;
                startTime = true;

            
           
        }




    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            collider = null;
            startTime = false;
        }




    }

    void Update()
    {
        if (startTime)
        {
            timer -= Time.deltaTime;
            
        }
        if (timer <= 0)
        {
            startTime = false;
            timer = 2f;
            if (isLocked)
            {
                
                if (collider.GetComponent<Role>().UseItem(ItemType.InnerDoorKey))
                {
                    isLocked = false;
                    targetDoorPos.GetComponent<InnerTransDoor>().isLocked = false;
                    collider.transform.position = targetDoorPos.position;
                }
            }
            else
            {
                collider.transform.position = targetDoorPos.position;

                
            }
            
        }
    }
}

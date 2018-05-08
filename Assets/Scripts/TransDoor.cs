using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransDoor : MonoBehaviour {

    private float timer = 2f;
    private bool startTime = false;
    
    public Transform targetDoorPos;

    private Collider2D collider;

    // Use this for initialization
    void Start()
    {
       
    }
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
            collider.transform.localPosition = targetDoorPos.localPosition;

            startTime = false;
            timer = 2f;
        }
    }
}

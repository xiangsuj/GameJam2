using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private float timer=2f;
    private bool startTime = false;
    public Transform targetDoorPos;

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
            coll.GetComponent<Role>().currentGrid=transform.parent;//当玩家离开这个门的时候，意味着玩家处于这个grid中。
            coll.transform.SetParent(transform.parent);
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
            collider.transform.position = targetDoorPos.position;
            
            startTime = false;
            timer = 2f;
        }
    }
}

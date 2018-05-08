using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        //if (cother.tag == "Player")
        other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
}

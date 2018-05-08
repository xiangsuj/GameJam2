using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour {

    private Animator WalkAnimator;

    public float moveSpeed = 0.1f;
    // Use this for initialization
    void Start()
    {
        WalkAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = 0;
        float v = 0;
        h = Input.GetAxis("Horizontal2");
        v = Input.GetAxis("Vertical2");
        if (h == 0 && v == 0)
        {
            WalkAnimator.SetBool("Idle", true);
        }
        else
        {
            WalkAnimator.SetBool("Idle", false);
            WalkAnimator.SetFloat("DirectX", h);
            WalkAnimator.SetFloat("DirectY", v);
            //Debug.Log(new Vector2(h, v) * moveSpeed);
            transform.Translate(new Vector2(h, v) * moveSpeed);
        }

    }
}

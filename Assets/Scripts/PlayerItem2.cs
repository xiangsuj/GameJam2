using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem2 : MonoBehaviour {

    public GameObject transDoor0;

    public GameObject transDoor1;

   

    private Camera p1Camera;

    private bool openLight = false;
    private bool closeLight = false;

    private float openLightViewSize = 10f;
    private float closeLightViewSize = 5f;

    private float changeViewSpeed = 1f;

    private float lightedTime = 4f;

    private Role role;
    // Use this for initialization
    void Start()
    {
        p1Camera = GameObject.Find("Main Camera2").GetComponent<Camera>();
        role = transform.GetComponent<Role>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            if (role.IsHaveItem(ItemType.TransDoor))
            {
                UseTransDoor(false);
            }
            else
            {
                //TODO 提示道具不足
            }

        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            if (role.IsHaveItem(ItemType.TransDoor))
            {
                UseTransDoor(true);
            }
            else
            {
                //TODO 提示道具不足
            }

        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            if (role.UseItem(ItemType.Light))
            {
                StartCoroutine(UseLight());
            }
            else
            {
                //TODO 提示道具不足
            }


        }
        if (openLight)
        {
            p1Camera.orthographicSize = Mathf.Lerp(p1Camera.orthographicSize, openLightViewSize, Time.deltaTime * changeViewSpeed);
        }
        if (closeLight)
        {
            p1Camera.orthographicSize = Mathf.Lerp(p1Camera.orthographicSize, closeLightViewSize, Time.deltaTime * changeViewSpeed);
        }
    }

    private void UseTransDoor(bool isUp)
    {
        RaycastHit2D[] rayinfos;
        if (isUp)
        {
            rayinfos = Physics2D.RaycastAll(transform.position, Vector2.up, 4f);
        }
        else
        {
            rayinfos = Physics2D.RaycastAll(transform.position, Vector2.down, 4f);
        }

        bool canTrans = true;

        foreach (RaycastHit2D rayinfo in rayinfos)
        {
            if (rayinfo.collider.tag == "BackGroundWall")
            {
                canTrans = false;
            }
        }


        if (canTrans)
        {
            role.UseItem(ItemType.TransDoor);
            if (isUp)
            {
                InstTransDoor((transform.localPosition - Vector3.up * 0.5f), (transform.localPosition - Vector3.up * 0.5f + Vector3.up * 4));
            }
            else
            {
                InstTransDoor((transform.localPosition - Vector3.up * 0.5f), (transform.localPosition - Vector3.up * 0.5f - Vector3.up * 4));
            }


        }

    }

    private IEnumerator UseLight()
    {

        closeLight = false;
        openLight = true;
        yield return new WaitForSeconds(lightedTime);
        openLight = false;
        closeLight = true;
    }


    private void InstTransDoor(Vector3 pos1, Vector3 pos2)
    {
        GameObject door0 = Instantiate(transDoor0);
        
        door0.transform.SetParent(transform.GetComponent<Role>().currentGrid, false);
        door0.transform.localPosition = pos1;
        GameObject door1 = Instantiate(transDoor1);
        door1.transform.SetParent(transform.GetComponent<Role>().currentGrid, false);
        door1.transform.localPosition = pos2;
        door0.GetComponent<TransDoor>().targetDoorPos = door1.transform;
        door1.GetComponent<TransDoor>().targetDoorPos = door0.transform;
    }
}

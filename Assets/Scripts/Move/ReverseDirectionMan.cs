using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReverseDirectionMan : Dush {

     private ItemFloorCtrl itemFloorCtrl;

    private float speed = 0.2f;
    private float speedX = 0.0f;
    private float speedY = 0.0f;

    private bool Reverse = false;

    void Start()
    {
        GameObject itemFloor = GameObject.Find("ItemFloorCtrl");
        itemFloorCtrl = itemFloor.GetComponent<ItemFloorCtrl>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Reverse)
        {
            speed = -speed;

            Reverse = false;
        }


        speedX = 0.0f;
        if (horizontal > 0)
        {
            speedX = speed;
        }
        else if (horizontal < 0)
        {
            speedX = -speed;
        }


        speedY = 0.0f;
        if (vertical > 0)
        {
            speedY = speed;
        }
        else if (vertical < 0)
        {
            speedY = -speed;
        }

        transform.position += new Vector3(speedX, speedY, 0.0f);

        if (transform.position.x < -itemFloorCtrl.GetScreenWidth())
        {
            transform.position += new Vector3(itemFloorCtrl.GetScreenWidth() * 2, 0.0f, 0.0f);
        }

        if (transform.position.x > itemFloorCtrl.GetScreenWidth())
        {
            transform.position -= new Vector3(itemFloorCtrl.GetScreenWidth() * 2, 0.0f, 0.0f);
        }

        if (transform.position.y < -itemFloorCtrl.GetScreenHeight())
        {
            transform.position += new Vector3(0.0f, itemFloorCtrl.GetScreenHeight() * 2, 0.0f);
        }

        if (transform.position.y > itemFloorCtrl.GetScreenHeight())
        {
            transform.position -= new Vector3(0.0f, itemFloorCtrl.GetScreenHeight() * 2, 0.0f);
        }

        List<Item> itemList = itemFloorCtrl.GetItemList();

        bool get_item = false;

        for (int i = 0; i < itemList.Count; i++)
        {
            Item item = itemList[i];
            if (itemFloorCtrl.CheckHit(this, item))
            {
               itemFloorCtrl.RemoveItem(item);
               itemFloorCtrl.CreateItem();

               Reverse = true;

               break;
            }
        }

        if (Reverse)
        {
            if (transform.localScale.y > 0)
            {
                transform.localScale = new Vector3(1.0f, -1.0f, 1.0f);
            }
            else
            {
                transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }
        
    }
}


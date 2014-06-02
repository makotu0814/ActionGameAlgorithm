using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloorControl : MonoBehaviour
{
    public Camera camera;
    public Floor floor;
    public Dush dush;
    public Item item;

    private int num = 3;
    private int index = 0;
    private float width = 0.0f;
    private float distance = 0.0f;
    private Vector3 oldCameraPos;
    private List<Floor> floors = new List<Floor>();
    private List<Item> items = new List<Item>();
    private Vector3 oldItemPos;

    void Start()
    {
        oldCameraPos = camera.transform.position;

        CreateFloors();

        SetCharaOnFloor();
    }

    void Update()
    {
        distance += (camera.transform.position.x - oldCameraPos.x);
        if ((width / num) < distance)
        {
            Floor floor = floors[index++ % floors.Count];
            floor.transform.localPosition += new Vector3(width, 0.0f, 0.0f);

            SetItemOnFloor(floor);

            distance = 0.0f;
        }

        for (int i = 0; i < items.Count; i++)
        {
            Item item = items[i];

            if (CheckHit(dush, item))
            {
                ((SpeedUpItemDush)dush).SetSpeedUpTime(item.useTime);

                RemoveItem(item);
            }
        }

        oldCameraPos = camera.transform.position;
    }

    protected virtual void SetCharaOnFloor()
    {
        dush.SetPosition(new Vector3(0.0f, -Camera.main.orthographicSize + floor.GetFloorHeight() + dush.GetHeight() / 2));
    }

    protected virtual void CreateFloors()
    {
        for (int i = 0; i < num; i++)
        {
            Floor floorObj = Instantiate(floor) as Floor;
            floorObj.transform.parent = transform;
            floorObj.transform.localPosition = new Vector3(floorObj.GetScreenwWidth() * i, 0.0f, 0.0f);
            width += floorObj.GetScreenwWidth();

            floors.Add(floorObj);

            if (i != 0)
            {
                SetItemOnFloor(floorObj);
            }
        }
    }

    protected virtual void SetItemOnFloor(Floor floor)
    {
        if (item != null)
        {
            RemoveOldItems(floor);

            Item itemObj = Instantiate(item) as Item;
            itemObj.transform.parent = floor.transform;
            itemObj.transform.localPosition = new Vector2(Random.Range(-floor.GetScreenwWidth() / 2 + itemObj.GetWidth() / 2, floor.GetScreenwWidth() / 2 - itemObj.GetWidth() / 2), -Camera.main.orthographicSize + floor.GetFloorHeight() + itemObj.GetHeight() / 2);
            items.Add(itemObj);
        }
    }


    protected virtual void RemoveOldItems(Floor floor)
    {
        foreach (Transform child in floor.transform)
        {
            if (child.GetComponent<Item>() != null)
            {
                RemoveItem(child.GetComponent<Item>());
            }
        }
    }

    protected virtual void RemoveItem(Item item)
    {
        items.Remove(item);
        Destroy(item.gameObject);
    }

    protected virtual bool CheckHit(Dush dushMan, Item item)
    {
        float man_left = dushMan.transform.position.x - dushMan.GetWidth() / 2;
        float man_right = dushMan.transform.position.x + dushMan.GetWidth() / 2;
        float man_top = dushMan.transform.position.y + dushMan.GetHeight() / 2;
        float man_buttom = dushMan.transform.position.y - dushMan.GetHeight() / 2;

        float item_left = item.transform.position.x - item.GetWidth() / 2;
        float item_right = item.transform.position.x + item.GetWidth() / 2;
        float item_top = item.transform.position.y + item.GetHeight() / 2;
        float item_buttom = item.transform.position.y - item.GetHeight() / 2;

        if ((man_right > item_left) && (man_left < item_right))
        {
            if ((man_buttom < item_top) && (man_top > item_buttom)) {
                return true;
            }
        }
        return false;
    }

    public virtual float GetScreenWidth()
    {
        return floors[0].GetScreenwWidth();
    }

    public virtual float GetScreenHeight()
    {
        return floors[0].GetScreenHeight();
    }
}

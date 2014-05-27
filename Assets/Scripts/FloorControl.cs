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

        oldCameraPos = camera.transform.position;
    }

    private void SetCharaOnFloor()
    {
        dush.SetPosition(new Vector3(0.0f, -Camera.main.orthographicSize + floor.GetHeight() + dush.GetHeight() / 2));
    }

    private void CreateFloors()
    {
        for (int i = 0; i < num; i++)
        {
            Floor floorObj = Instantiate(floor) as Floor;
            floorObj.transform.parent = transform;
            floorObj.transform.localPosition = new Vector3(floorObj.GetWidth() * i, 0.0f, 0.0f);
            width += floorObj.GetWidth();

            floors.Add(floorObj);

            if (i != 0)
            {
                SetItemOnFloor(floorObj);
            }
        }
    }

    private void SetItemOnFloor(Floor floor)
    {
        if (item != null)
        {
            RemoveOldItems(floor);

            Item itemObj = Instantiate(item) as Item;
            itemObj.transform.parent = floor.transform;
            itemObj.transform.localPosition = new Vector2(Random.Range(-floor.GetWidth() / 2 + itemObj.GetWidth() / 2, floor.GetWidth() / 2 - itemObj.GetWidth() / 2), -Camera.main.orthographicSize + floor.GetHeight() + itemObj.GetHeight() / 2);
            items.Add(itemObj);
        }
    }


    private void RemoveOldItems(Floor floor)
    {
        foreach (Transform child in floor.transform)
        {
            if (child.GetComponent<Item>() != null)
            {
                items.Remove(child.GetComponent<Item>());
                Destroy(child.gameObject);
            }
        }
    }
}

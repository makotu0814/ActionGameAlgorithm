using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemFloorCtrl : FloorControl
{
    public int itemNum = 5;

    private float screenWidth = 0.0f;
    private float screenHeight = 0.0f;

    private List<Item> itemList = new List<Item>();

    protected override void CreateFloors()
    {
        screenWidth = CameraCtrl.GetCameraCtrl().need_width;
        screenHeight = CameraCtrl.GetCameraCtrl().GetHeight();

        for (int i = 0; i < itemNum; i++)
        {
            CreateItem();
        }
    }

    public void CreateItem()
    {
        float x = Random.Range(-screenWidth / 2, screenWidth / 2);
        float y = Random.Range(-screenHeight / 2, screenHeight / 2);

        Item itemObj = Instantiate(item) as Item;
        itemObj.transform.parent = transform;
        itemObj.transform.localPosition = new Vector3(x, y, 0.0f);

        itemList.Add(itemObj);
    }


    public void RemoveItem(Item item)
    {
        itemList.Remove(item);

        Destroy(item.gameObject);
    }

    protected override void SetCharaOnFloor()
    {
        Vector3 position = new Vector3(0.0f, -screenHeight / 2 + dush.GetHeight() / 2);
    }

    public override float GetScreenWidth()
    {
        return screenWidth;
    }

    public override float GetScreenHeight()
    {
        return screenHeight;
    }

    public List<Item> GetItemList()
    {
        return itemList;
    }
}

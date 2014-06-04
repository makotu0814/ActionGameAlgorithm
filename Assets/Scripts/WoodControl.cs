using UnityEngine;
using System.Collections;

public class WoodControl : FloorControl
{
    public GameObject tree;
    public int treeNum = 10;

    private float screenWidth = 0.0f;
    private float screenHeight = 0.0f;

    protected override void CreateFloors()
    {
        Floor floorObj = Instantiate(floor) as Floor;
        screenWidth = floorObj.GetScreenwWidth();
        screenHeight = floorObj.GetScreenHeight();

        for (int i = 0; i < treeNum; i++)
        {
            float x = Random.Range(-screenWidth / 2, screenWidth / 2);
            float y = Random.Range(-screenHeight / 2, screenHeight / 2);

            GameObject woodObj = Instantiate(tree) as GameObject;
            woodObj.transform.parent = transform;
            woodObj.transform.localPosition = new Vector3(x, y, 0.0f);
        }

        // フロアを生成しない
        Destroy(floorObj.gameObject);
    }


    protected override void SetCharaOnFloor()
    {
        Vector3 position = new Vector3(0.0f, -screenHeight / 2 + dush.GetHeight() / 2);

        CreateMan(position);
        CreateMan(position + new Vector3(screenWidth, 0.0f, 0.0f));
        CreateMan(position + new Vector3(0.0f, -screenHeight, 0.0f));
        CreateMan(position + new Vector3(screenWidth, -screenHeight, 0.0f));
    }

    private void CreateMan(Vector3 position)
    {
        Dush man = Instantiate(dush) as Dush;
        man.SetPosition(position);
    }

    public override float GetScreenWidth()
    {
        return screenWidth;
    }

    public override float GetScreenHeight()
    {
        return screenHeight;
    }
}

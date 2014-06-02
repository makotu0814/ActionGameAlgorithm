using UnityEngine;
using System.Collections;

public class WaterControl : FloorControl {

    private float screenWidth = 0.0f;
    private float screenHeight = 0.0f;

    protected override void CreateFloors()
    {
        Floor floorObj = Instantiate(floor) as Floor;
        screenWidth = floorObj.GetScreenwWidth();
        screenHeight = floorObj.GetScreenHeight();

        // フロアを生成しない
        Destroy(floorObj.gameObject);
    }


    protected override void SetCharaOnFloor()
    {
        dush.SetPosition(new Vector3(0.0f, -Camera.main.orthographicSize + dush.GetHeight() / 2));
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

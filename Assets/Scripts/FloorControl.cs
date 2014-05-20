using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FloorControl : MonoBehaviour
{
    public Camera camera;
    public Floor floor;
    public ButtonDushMan buttonDush;

    private int num = 3;
    private int index = 0;
    private float width = 0.0f;
    private float distance = 0.0f;
    private Vector3 oldCameraPos;
    private List<Floor> floors = new List<Floor>();

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

            distance = 0.0f;
        }
        oldCameraPos = camera.transform.position;
    }

    private void SetCharaOnFloor()
    {
        buttonDush.SetPosition(new Vector3(0.0f, -Camera.main.orthographicSize + floor.GetHeight() + buttonDush.GetHeight() / 2));
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
        }
    }
}

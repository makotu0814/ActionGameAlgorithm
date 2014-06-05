using UnityEngine;
using System.Collections;

public class CameraCtrl : MonoBehaviour
{
    public float need_width = 0.0f;

    private float height = 0.0f;
    private float camSize = 0.0f;

    private static CameraCtrl camCtrl = null;

    void Awake()
    {
        height = 1 / Camera.main.aspect * need_width;

        camSize = height / 2;

        Camera.main.orthographicSize = camSize;
    }

    public static CameraCtrl GetCameraCtrl()
    {
        camCtrl = camCtrl ?? GameObject.Find("Main Camera").GetComponent<CameraCtrl>();

        return camCtrl;
    }

    public float GetCamSize()
    {
        return camSize;
    }

    public float GetHeight()
    {
        return height;
    }
}

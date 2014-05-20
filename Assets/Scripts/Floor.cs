using UnityEngine;
using System.Collections;

public class Floor : MonoBehaviour
{
    public GameObject tile;
    public static readonly int num = 8;
    public static float camSize = 0.0f;

    private float size = 0.0f;
    private float width = 0.0f;
    private float height = 0.0f;

    void Awake()
    {
        size = tile.GetComponent<BoxCollider>().size.x * transform.localScale.x;
        width = size * num;

        height = 1 / Camera.main.aspect * width;

        camSize = height / 2;

        Camera.main.orthographicSize = camSize;
    }

    void Start()
    {
        for (int i = 0; i < num; i++)
        {
            GameObject tileObj = Instantiate(tile) as GameObject;
            tileObj.transform.parent = transform;
            tileObj.transform.localPosition = new Vector3(-width / 2 + size / 2 + size * i , -height / 2 + size / 2, 0.0f);
        }
    }

    public float GetWidth()
    {
        return width;
    }

    public float GetHeight()
    {
       return tile.GetComponent<BoxCollider>().size.y;
    }
}

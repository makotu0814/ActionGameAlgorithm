using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    public float useTime = 60;

    public float GetWidth()
    {
        float width = GetComponent<BoxCollider2D>().size.x * transform.transform.localScale.x;

        return width;
    }

    public float GetHeight()
    {
        float height = GetComponent<BoxCollider2D>().size.y * transform.transform.localScale.y;

        return height;
    }
}

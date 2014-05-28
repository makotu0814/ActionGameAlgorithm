using UnityEngine;
using System.Collections;

public class Dush : MonoBehaviour {

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public float GetHeight()
    {
        return GetComponent<BoxCollider2D>().size.y;
    }

    public float GetWidth()
    {
        return GetComponent<BoxCollider2D>().size.x;
    }
}

using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour
{
    public Camera Cam;
    public GameObject Tile;

    private float accel = 0.01f;
    private float maxSpeed = 1.0f;
    private float speed = 0.0f;
    private float downRate = 0.5f;

    void Start()
    {
        Debug.Log("cam.size : " + Floor.camSize);
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {
            // 右入力
            speed += accel;
        }
        else if (horizontal < 0)
        {
            // 左入力
            speed -= accel;
        }
        else
        {
            // 入力なし
            speed -= accel * downRate;
        }

        if (speed < 0)
        {
            speed = 0.0f;
        }

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        transform.position += new Vector3(speed, 0.0f, 0.0f);

        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -15.0f * (speed / maxSpeed)));
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public float GetHeight()
    {
        return GetComponent<BoxCollider>().size.y;
    }
}

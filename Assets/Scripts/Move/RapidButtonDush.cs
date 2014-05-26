using UnityEngine;
using System.Collections;

public class RapidButtonDush : Dush {

    private float speed = 0.0f;
    private float accel = 0.05f;
    private float maxSpeed = 0.5f;
    private bool prevButton = false;

    void Update()
    {
        if (!prevButton && Input.GetKey(KeyCode.Space))
        {
            speed += accel;
        }
        else
        {
            speed -= accel * 0.1f;
        }

        if (speed < 0)
        {
            speed = 0;
        }

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }

        prevButton = Input.GetKey(KeyCode.Space);

        transform.position += new Vector3(speed, 0.0f, 0.0f);

        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -15.0f * (speed / (maxSpeed))));
    }
}

using UnityEngine;
using System.Collections;

public class DoubleLeverDush : Dush {

    private bool Dash;
    private bool PrevRight;
    private int dashFrame = 30;
    private int frame = 100;
    private float speed = 0.0f;
    private float normalSpeed = 0.2f;
    private float dashSpeed = 0.5f;
    private float downRate = 0.5f;

    void Update()
    {
        if (Dash)
        {
            if (!isRight())
            {
                Dash = false;
                speed = 0.0f;
            }
        }
        else
        {
            if (isRight())
            {
                if (!PrevRight)
                {
                    if (frame < dashFrame)
                    {
                        Dash = true;
                        speed = dashSpeed;
                    }
                    else
                    {
                        speed = normalSpeed;
                    }
                    frame = 0;
                }
            }
            else
            {
                speed = 0.0f;
            }
        }

        frame++;

        PrevRight = isRight();

        transform.position += new Vector3(speed, 0.0f, 0.0f);

        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -15.0f * speed / dashSpeed));
    }

    private bool isRight()
    {
        float horizontal = Input.GetAxis("Horizontal");
        return horizontal > 0;
    }
}
using UnityEngine;
using System.Collections;

public class ButtonDush : Dush
{
    private float buttonAccel = 0.005f;
    private float buttonMaxSeepd = 0.5f;

    private float leverAccel = 0.002f;
    private float leverMaxSpeed = 0.4f;
    private float speed = 0.0f;
    private float leverSpeed = 0.0f;
    private float buttonSpeed = 0.0f;
    private float downRate = 0.5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {
            // 右入力なら加速する
            leverSpeed += leverAccel;
        }
        else if (horizontal < 0)
        {
            // 左入力なら減速する
            leverSpeed -= leverAccel;
        }
        else
        {
            // 入力なしの場合は、緩やかに減速する
            leverSpeed -= leverAccel * downRate;
        }

        if (leverSpeed < 0)
        {
            leverSpeed = 0.0f;
        }

        if (leverSpeed > leverMaxSpeed)
        {
            leverSpeed = leverMaxSpeed;
        }


        if (Input.GetKey(KeyCode.Space))
        {
            buttonSpeed += buttonAccel;
        }
        else
        {
            buttonSpeed -= buttonAccel;
        }

        if (buttonSpeed < 0)
        {
            buttonSpeed = 0;
        }

        if (buttonSpeed > buttonMaxSeepd)
        {
            buttonSpeed = buttonMaxSeepd;
        }

        speed = leverSpeed + buttonSpeed;

        transform.position += new Vector3(speed, 0.0f, 0.0f);

        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -15.0f * (speed / (leverMaxSpeed + buttonMaxSeepd))));
    }
}

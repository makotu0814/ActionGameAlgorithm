using UnityEngine;
using System.Collections;

public class SlipOnIceMan : Dush
{
    public FloorControl floorCtrl;

    private float speed = 0.0f;
    private float normalSpeed = 0.3f;

    private int time = 0;
    private int slipTime = 30;
    private float angle = 15.0f;

    void Update()
    {
        if (time > 0)
        {
            time--;

            if (time == 0)
            {
                speed = 0.0f;
            }
        }
        else
        {
            if (speed > 0)
            {
                // 右に移動
                if (Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D))
                {
                    time = slipTime;
                }
            }
            else if (speed < 0)
            {
                if (Input.GetKey(KeyCode.D) || !Input.GetKey(KeyCode.A))
                {
                    time = slipTime;
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.A))
                {
                    speed = -normalSpeed;
                }

                if (Input.GetKey(KeyCode.D))
                {
                    speed = normalSpeed;
                }
            }
        }

        float x = transform.position.x + speed;

        float screenWidth = floorCtrl.GetScreenWidth();

        if (x < (-screenWidth / 2 + GetWidth() / 2))
        {
            x = -screenWidth / 2 + GetWidth() / 2;
        }

        if (x > (screenWidth / 2 - GetWidth() / 2))
        {
            x = screenWidth / 2 - GetWidth() / 2;
        }

        if (time > 0.0f)
        {
            // 揺れる処理
            angle = -angle;
            transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, angle));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, angle * -speed));
        }

        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}

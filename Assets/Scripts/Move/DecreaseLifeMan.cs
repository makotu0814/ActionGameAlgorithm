using UnityEngine;
using System.Collections;

public class DecreaseLifeMan : Dush {

    public Life life;

    private float speedX = 0.00f;
    private float speedY = 0.0f;
    private float speed = 0.1f;

    private float Life = 1;
    private float dec_life = 0.005f;
    private float add_life = 0.007f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        speedX = 0.0f;

        if (horizontal > 0)
        {
            // 右入力
            speedX = speed;
        }
        else if (horizontal < 0)
        {
            // 左入力
            speedX = -speed;
        }
       

        float vertical = Input.GetAxis("Vertical");

        speedY = 0.0f;

        if (vertical > 0)
        {
            speedY = speed;
        }
        else if (vertical < 0)
        {
            speedY = -speed;
        }

        if (Life > 0)
        {
            float x = transform.position.x + speedX;

            float screenWidth = CameraCtrl.GetCameraCtrl().need_width;

            if (x < (-screenWidth / 2 + GetWidth() / 2))
            {
                x = -screenWidth / 2 + GetWidth() / 2;
            }

            if (x > (screenWidth / 2 - GetWidth() / 2))
            {
                x = screenWidth / 2 - GetWidth() / 2;
            }

            float y = transform.position.y + speedY;

            float screenHeight = CameraCtrl.GetCameraCtrl().GetHeight();

            if (y < (-screenHeight / 2 + GetHeight() / 2))
            {
                y = -screenHeight / 2 + GetHeight() / 2;
            }

            if (y > (screenHeight / 2 - GetHeight() / 2))
            {
                y = screenHeight / 2 - GetHeight() / 2;
            }

            transform.position = new Vector3(x, y, 0.0f);
        }


        if (speedX != 0 || speedY != 0)
        {
            Life -= dec_life;
        }
        else
        {
            Life += add_life;
        }

        if (Life < 0)
        {
            Life = 0;
        }

        if (Life > 1)
        {
            Life = 1;
        }

        life.Draw(Life);
    }
}


using UnityEngine;
using System.Collections;

public class SwimmingMan : Dush {

    public WaterControl waterCtrl;

    private float speedX = 0.00f;
    private float speedY = 0.0f;
    private float VX = 0.05f;
    private float up_speed = 0.10f;
    private float down_speed = -0.05f;
    private bool prevButton = false;
    private int time = 0;
    private int up_time = 20;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {
            // 右入力
            speedX = VX;
        }
        else if (horizontal < 0)
        {
            // 左入力
            speedX = -VX;
        }
        else
        {
            speedX = 0.0f;
        }

        if (!prevButton && Input.GetKey(KeyCode.Space))
        {
            time = up_time;
        }

        prevButton = Input.GetKey(KeyCode.Space);

        if (time > 0)
        {
            speedY = up_speed;
            time--;
        }
        else
        {
            speedY = down_speed;
        }

        float x = transform.position.x + speedX;

        float screenWidth = waterCtrl.GetScreenWidth();

        if (x < (-screenWidth / 2 + GetWidth() / 2))
        {
            x = -screenWidth / 2 + GetWidth() / 2;
        }

        if (x > (screenWidth / 2 - GetWidth() / 2))
        {
            x = screenWidth / 2 - GetWidth() / 2;
        }

        float y = transform.position.y + speedY;

        float screenHeight = waterCtrl.GetScreenHeight();

        if (y < (-screenHeight / 2 + GetHeight() / 2))
        {
            y = -screenHeight / 2 + GetHeight() / 2;
        }

        if (y > (screenHeight / 2 - GetHeight() / 2))
        {
            y = screenHeight / 2 - GetHeight() / 2;
        }


        if (speedX > 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        if (speedX < 0.0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }

        transform.position = new Vector3(x, y, 0.0f);
    }
}

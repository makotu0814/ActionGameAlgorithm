﻿using UnityEngine;
using System.Collections;

public class SpeedUpItemDush : Dush {

    private float normalSpeed = 0.3f;
    private float itemSpeed = 0.5f;
    private float speed = 0.0f;
    private float downRate = 0.5f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal > 0)
        {
            // 右入力
            speed = normalSpeed;
        }
        else
        {
            // 入力なし
            speed = 0.0f;
        }

        if (speed < 0)
        {
            speed = 0.0f;
        }

        transform.position += new Vector3(speed, 0.0f, 0.0f);

        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, -15.0f * (speed / itemSpeed)));
    }
}

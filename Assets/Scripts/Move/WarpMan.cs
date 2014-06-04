using UnityEngine;
using System.Collections;

public class WarpMan : Dush {

    private WoodControl woodCtrl;

    private float speed = 0.1f;
    private float speedX = 0.0f;
    private float speedY = 0.0f;

    void Start()
    {
        GameObject wood = GameObject.Find("WoodControl");
        woodCtrl = wood.GetComponent<WoodControl>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        speedX = 0.0f;
        if (horizontal > 0)
        {
            speedX = speed;
        }
        else if (horizontal < 0)
        {
            speedX = -speed;
        }


        speedY = 0.0f;
        if (vertical > 0)
        {
            speedY = speed;
        }
        else if (vertical < 0)
        {
            speedY = -speed;
        }

        transform.position += new Vector3(speedX, speedY, 0.0f);

        if (transform.position.x < -woodCtrl.GetScreenWidth())
        {
            transform.position += new Vector3(woodCtrl.GetScreenWidth() * 2, 0.0f, 0.0f);
        }

        if (transform.position.x > woodCtrl.GetScreenWidth())
        {
            transform.position -= new Vector3(woodCtrl.GetScreenWidth() * 2, 0.0f, 0.0f);
        }

        if (transform.position.y < -woodCtrl.GetScreenHeight())
        {
            transform.position += new Vector3(0.0f, woodCtrl.GetScreenHeight() * 2, 0.0f);
        }

        if (transform.position.y > woodCtrl.GetScreenHeight())
        {
            transform.position -= new Vector3(0.0f, woodCtrl.GetScreenHeight() * 2, 0.0f);
        }
    }
}

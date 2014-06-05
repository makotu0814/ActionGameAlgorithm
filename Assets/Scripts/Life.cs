using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour
{
    public TextMesh lifeText;

    private float size_x = 0.0f;

    void Start()
    {
        float screenWidth = CameraCtrl.GetCameraCtrl().need_width;

        float width = GetComponent<BoxCollider2D>().size.x;

        size_x = screenWidth / width;

        transform.localScale = new Vector3(size_x, transform.localScale.y);

        transform.position = new Vector3(-screenWidth / 2, -CameraCtrl.GetCameraCtrl().GetCamSize() / 1.2f);

        float text_Width = lifeText.GetComponent<BoxCollider2D>().size.x;
        float text_height = lifeText.GetComponent<BoxCollider2D>().size.y;

        lifeText.transform.position = new Vector3(-screenWidth / 2 + text_Width / 2, transform.position.y + GetComponent<BoxCollider2D>().size.y / 2 + text_height / 2);
    }

    public void Draw(float life)
    {
        transform.localScale = new Vector3(size_x * life, transform.localScale.y);
    }
}

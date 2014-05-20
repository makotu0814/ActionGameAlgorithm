using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{

    public GameObject target;

    private Vector3 oldPosition;
    private Vector3 addPosition = new Vector3(0.0f, 0.0f, 0.0f);


    void Start()
    {
        oldPosition = target.transform.position;
    }

    void Update()
    {
        if (oldPosition != target.transform.position)
        {
            addPosition = target.transform.position - oldPosition;

            transform.position += addPosition;

            oldPosition = target.transform.position;
        }
    }

}

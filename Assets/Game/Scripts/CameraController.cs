using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    Vector3 pos;

    void Start()
    {
        pos = Camera.main.gameObject.transform.position;
    }

    void Update()
    {
        Vector3 cameraPos = target.transform.position;

        if (target.transform.position.x < 0)
        {
            cameraPos.x = 0;
        }
        if (target.transform.position.x > 27)
        {
            cameraPos.x = 27;
        }

        if (target.transform.position.y < 0)
        {
            cameraPos.y = 0;
        }

        if (target.transform.position.y > 0)
        {
            if (target.transform.position.y > 1)
            {
                cameraPos.y = 1;
            }
            else
            {
                cameraPos.y = target.transform.position.y;
            }
        }


        cameraPos.z = -10;
        Camera.main.gameObject.transform.position = cameraPos;
    }
}
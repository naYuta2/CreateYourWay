using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCTR3 : MonoBehaviour
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
        if (target.transform.position.x > 55)
        {
            cameraPos.x = 55;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroyCTR : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "DetectionBar" || col.gameObject.name == "DetectionBar2")
        {
            Destroy(this.gameObject);
        }
    }
}

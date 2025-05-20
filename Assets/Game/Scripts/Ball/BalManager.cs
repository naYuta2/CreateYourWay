using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalManager : MonoBehaviour
{
    private bool isTrigger = false;

    public GameObject target;
    public GameObject ball;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" && !isTrigger)
        {
            Instantiate(ball, target.transform.position, Quaternion.identity);
            isTrigger = true;
        }
    }
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BreakedBlockCTR : MonoBehaviour
{
    public GameObject effect;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Explosion"))
        {
            Destroy(this.gameObject);
        }
    }
}
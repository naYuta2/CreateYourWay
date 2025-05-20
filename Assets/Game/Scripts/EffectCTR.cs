using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectCTR : MonoBehaviour
{
    private bool isDestroied = false;

    // Update is called once per frame
    void Update()
    {
        if (!isDestroied)
        {
            isDestroied = true;
            StartCoroutine("Destroying");
        }
    }

    public IEnumerator Destroying()
    {
        yield return new WaitForSeconds(0.7f);
        Destroy(this.gameObject);
    }
}

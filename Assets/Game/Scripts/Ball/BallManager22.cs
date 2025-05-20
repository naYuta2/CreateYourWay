using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManager22 : MonoBehaviour
{
    public GameObject ball;
    private bool isTrigger = false;
    // Update is called once per frame
    void Update()
    {
        if (!isTrigger)
        {
            isTrigger = true;
            Instantiate(ball, this.transform.position, Quaternion.identity);
            StartCoroutine("Trigger");
        }
    }

    public IEnumerator Trigger()
    {
        yield return new WaitForSeconds(8f);
        isTrigger = false;
    }
}

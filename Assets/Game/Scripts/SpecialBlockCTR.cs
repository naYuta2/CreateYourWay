using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBlockCTR : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 initialPosition;

    public GameObject target;

    Vector3 forceDirection = new Vector3(0.6f, 0.3f, 0f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    public void BringMessage()
    {
        rb.velocity = Vector3.zero;
        Vector3 blockPos = target.transform.position;
        blockPos.x = target.transform.position.x;
        blockPos.y = target.transform.position.y + 1;

        gameObject.transform.position = blockPos;
    }

    public void ThrowMessage()
    {
        Vector3 scale = target.transform.localScale;
        if (scale.x > 0)
        {
            forceDirection.x = 0.6f;
        }
        else
        {
            forceDirection.x = -0.6f;
        }

        float forceMagnitude = 10.0f;
        Vector3 force = forceDirection * forceMagnitude;

        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public void ReleaseMessage()
    {
        Vector3 scale = target.transform.localScale;
        Vector3 blockPos = target.transform.position;
        if (scale.x > 0)
        {
            blockPos.x = target.transform.position.x + 1;
        }
        else
        {
            blockPos.x = target.transform.position.x - 1;
        }
        blockPos.y = target.transform.position.y;

        gameObject.transform.position = blockPos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "DetectionBar" || col.CompareTag("Explosion"))
        {
            Destroy(this.gameObject);
        }
    }
}

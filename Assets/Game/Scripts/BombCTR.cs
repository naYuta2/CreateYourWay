using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCTR : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 initialPosition;
    private bool isTrigger = false;
    private bool isBringing = false;

    public GameObject target;
    public GameObject effect;
    public CircleCollider2D effectCol;
    public CircleCollider2D col;

    public float waitSeconds;

    public Animator animator;

    Vector3 forceDirection = new Vector3(0.6f, 0.3f, 0f);

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        animator.SetBool("IsTrigger", isTrigger);
    }

    public void BringMessage()
    {
        isBringing = true;
        rb.velocity = Vector3.zero;
        Vector3 blockPos = target.transform.position;
        blockPos.x = target.transform.position.x;
        blockPos.y = target.transform.position.y + 1;

        gameObject.transform.position = blockPos;
    }

    public void ThrowMessage()
    {
        isBringing = false;
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

        if (!isTrigger)
        {
            StartCoroutine("Bomb1");
            isTrigger = true;
            col.enabled = false;
        }

        rb.AddForce(force, ForceMode2D.Impulse);
    }

    public void ReleaseMessage()
    {
        isBringing = false;
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
        if (!isTrigger)
        {
            StartCoroutine("Bomb1");
            isTrigger = true;
            col.enabled = false;
        }

        gameObject.transform.position = blockPos;
    }

    public IEnumerator Bomb1()
    {
        yield return new WaitForSeconds(waitSeconds);
        if (isBringing)
        {
            target.SendMessage("isDestroying");
        }
        Destroy(this.gameObject);
        Instantiate(effect, this.transform.position, Quaternion.identity);

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Explosion"))
        {
            StopCoroutine("Bomb1");
            StartCoroutine("Bomb2");
        }
    }
    public IEnumerator Bomb2()
    {
        yield return new WaitForSeconds(0f);
        if (isBringing)
        {
            target.SendMessage("isDestroying");
        }
        Destroy(this.gameObject);
        Instantiate(effect, this.transform.position, Quaternion.identity);
    }
}

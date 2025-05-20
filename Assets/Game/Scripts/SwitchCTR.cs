using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCTR : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;

    public GameObject target;

    private bool isTrigger = false;
    public bool isPushed = false;

    void Start()
    {
    }

    void Update()
    {
        if (isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.X) && !isPushed)
            {
                target.SendMessage("Pushed");
            }
            else if (Input.GetKeyDown(KeyCode.X) && isPushed)
            {
                target.SendMessage("Pushed");
            }
        }

        animator.SetBool("IsPushed", isPushed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Explosion") && !isPushed)
        {
            target.SendMessage("Pushed");
        }
        else if (col.CompareTag("Explosion") && isPushed)
        {
            target.SendMessage("Pushed");
        }
        if (col.gameObject.name == "Player")
        {
            isTrigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            isTrigger = false;
        }
    }

    void Trigger()
    {
        if (isPushed)
        {
            isPushed = false;
        }
        else
        {
            isPushed = true;
        }
    }
}

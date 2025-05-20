using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockCTR : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rb;

    private bool isTrigger = false;
    private bool isPushed = false;

    public float waitSeconds;
    public GameObject gameManager;

    void Start()
    {
        
    }

    void Update()
    {
        if (isTrigger)
        {
            if (Input.GetKeyDown(KeyCode.X) && !isPushed)
            {
                isPushed = true;
                gameManager.SendMessage("Slow");
                StartCoroutine("Trigger");
            }
        }
        animator.SetBool("IsPushed", isPushed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Explosion") && !isPushed)
        {
            isPushed = true;
            gameManager.SendMessage("Slow");
            StartCoroutine("Trigger");
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
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

    public IEnumerator Trigger()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(waitSeconds);
        Time.timeScale = 1f;
        isPushed = false;
        gameManager.SendMessage("Slow");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCTR1 : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    [SerializeField] private int moveSpeed;
    [SerializeField] private int jumpForce;

    private bool isJumping = false;
    private bool isMoving = false;
    private bool isFalling = false;
    private bool isBringing = false;
    private bool Trigger = false;
    private bool isThrowing = false;

    private GameObject nearObj;
    private GameObject BringObj;
    private float searchTime = 0;

    public GameObject gameManager;

    void Start()
    {
        nearObj = serchTag(gameObject, "SpecialBlock", "Bomb");
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isMoving = horizontal != 0;
        isFalling = rb.velocity.y < -0.5f;

        if (isMoving)
        {
            Vector3 scale = gameObject.transform.localScale;

            if (horizontal < 0 && scale.x > 0 || horizontal > 0 && scale.x < 0)
            {
                scale.x *= -1;
            }
            gameObject.transform.localScale = scale;
        }

        if (Trigger)
        {
            if (Input.GetKeyDown(KeyCode.Z) && !isJumping && !isFalling && (Mathf.Approximately(Time.timeScale, 1f) || Mathf.Approximately(Time.timeScale, 0.5f)))
            {
                isBringing = true;
            }

            if (Input.GetKey(KeyCode.Z) && isBringing && (Mathf.Approximately(Time.timeScale, 1f) || Mathf.Approximately(Time.timeScale, 0.5f)))
            {
                nearObj.SendMessage("BringMessage");
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    nearObj.SendMessage("ThrowMessage");
                    isThrowing = true;
                    isBringing = false;
                    Trigger = false;
                }
            }
            else if (Input.GetKeyUp(KeyCode.Z) && isBringing && (Mathf.Approximately(Time.timeScale, 1f) || Mathf.Approximately(Time.timeScale, 0.5f)) || Mathf.Approximately(Time.timeScale, 0f) && isBringing)
            {
                nearObj.SendMessage("ReleaseMessage");
                isBringing = false;
                Trigger = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !isFalling && !isBringing && !isThrowing && (Mathf.Approximately(Time.timeScale, 1f) || Mathf.Approximately(Time.timeScale, 0.5f)))
        {
            Jump();
        }
        else if (isThrowing)
        {
            isThrowing = false;
        }

        searchTime += Time.deltaTime;

        if (searchTime >= 0.2f && !isBringing)
        {
            nearObj = serchTag(gameObject, "SpecialBlock", "Bomb");
            searchTime = 0;
        }

        rb.velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y);

        animator.SetBool("IsMoving", isMoving);
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsFalling", isFalling);
        animator.SetBool("IsBringing", isBringing);

    }

    void Jump()
    {
        isJumping = true;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    GameObject serchTag(GameObject nowObj, string tagName1, string tagName2)
    {
        float tmpDis = 0;
        float nearDis = 0;

        GameObject targetObj = null;

        foreach (GameObject target in GameObject.FindGameObjectsWithTag(tagName2))
        {
            tmpDis = Vector3.Distance(target.transform.position, nowObj.transform.position);

            if (nearDis == 0 || nearDis > tmpDis)
            {
                nearDis = tmpDis;
                targetObj = target;
            }
        }

        return targetObj;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "DetectionBar" || col.CompareTag("Explosion") || col.CompareTag("Thorn"))
        {
            SceneManager.LoadScene (SceneManager.GetActiveScene().name);
        }
        if (col.CompareTag("Stage") || col.CompareTag("SpecialBlock") || col.CompareTag("Switch") || col.CompareTag("Bomb"))
        {
            isJumping = false;
        }
        if (col.gameObject.name == "Door")
        {
            gameManager.SendMessage("IsClear");
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("SpecialBlock") || col.CompareTag("Bomb"))
        {
            Trigger = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("SpecialBlock") && Trigger)
        {
            Trigger = false;
        }
    }

    public void isDestroying()
    {
        isBringing = false;
    }
}
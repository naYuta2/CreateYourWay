using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject clearUI;
    [SerializeField] private GameObject howUI;

    private bool isCleared = false;
    private bool pause = false;
    private bool how = false;
    private bool becameSlow = false;

    void Start()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        clearUI.SetActive(false);
        howUI.SetActive(false);

    }

    void Update()
    {
        if (Input.GetButtonDown("Pause") && !isCleared)
        {
            if (!pause && !how)
            {
                Time.timeScale = 0f;
                pauseUI.SetActive(true);
                pause = true;
            }
            else if (pause && !how)
            {
                if (becameSlow)
                {
                    Time.timeScale = 0.5f;
                }
                else
                {
                    Time.timeScale = 1f;
                }
                
                pauseUI.SetActive(false);
                pause = false;
            }
            else if (pause && how)
            {
                pauseUI.SetActive(true);
                howUI.SetActive(false);
                how = false;
            }
        }
    }

    void IsClear()
    {
        isCleared = true;
        Time.timeScale = 0f;
        clearUI.SetActive(true);
    }
    
    void Continue()
    {
        pause = false;
        if (becameSlow)
        {
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    void HowToPlay()
    {
        pauseUI.SetActive(false);
        howUI.SetActive(true);
        how = true;
    }

    void ExitHow()
    {
        pauseUI.SetActive(true);
        howUI.SetActive(false);
        how = false;
    }

    public void Slow()
    {
        if (!becameSlow)
        {
            becameSlow = true;
        }
        else
        {
            becameSlow = false;
        }
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCTR : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    public GameObject gameManager;

    public void StartGame()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void EndGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #elif UNITY_WEBPLAYER
        Application.OpenURL("http://www.yahoo.co.jp/");
    #else
        Application.Quit();
    #endif
    }

    public void SelectStage()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void Continue()
    {
        pauseUI.SetActive(false);
        gameManager.SendMessage("Continue");
    }

    public void HowToPlay()
    {
        gameManager.SendMessage("HowToPlay");
    }

    public void Return()
    {
        gameManager.SendMessage("ExitHow");
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

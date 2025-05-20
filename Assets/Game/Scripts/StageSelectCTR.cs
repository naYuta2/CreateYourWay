using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelectCTR : MonoBehaviour
{
    public void Return()
    {
        SceneManager.LoadScene("Title");
    }
    public void Stage11()
    {
        SceneManager.LoadScene("1-1");
    }
    public void Stage12()
    {
        SceneManager.LoadScene("1-2");
    }
    public void Stage13()
    {
        SceneManager.LoadScene("1-3");
    }
    public void Stage21()
    {
        SceneManager.LoadScene("2-1");
    }
    public void Stage22()
    {
        SceneManager.LoadScene("2-2");
    }
    public void Stage23()
    {
        SceneManager.LoadScene("2-3");
    }
    public void Stage31()
    {
        SceneManager.LoadScene("3-1");
    }
}
